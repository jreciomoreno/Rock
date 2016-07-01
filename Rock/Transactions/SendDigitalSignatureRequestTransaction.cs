// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Rock Community License (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.rockrms.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
using Rock.Data;
using Rock.Model;
using Rock.Security;

namespace Rock.Transactions
{
    /// <summary>
    /// Writes entity audits 
    /// </summary>
    public class SendDigitalSignatureRequestTransaction : ITransaction
    {
        /// <summary>
        /// Gets or sets the signature document type identifier.
        /// </summary>
        /// <value>
        /// The signature document type identifier.
        /// </value>
        public int SignatureDocumentTypeId { get; set; }

        /// <summary>
        /// Gets or sets the applies to person alias identifier.
        /// </summary>
        /// <value>
        /// The applies to person alias identifier.
        /// </value>
        public int AppliesToPersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the assigned to person alias identifier.
        /// </summary>
        /// <value>
        /// The assigned to person alias identifier.
        /// </value>
        public int AssignedToPersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the name of the document.
        /// </summary>
        /// <value>
        /// The name of the document.
        /// </value>
        public string DocumentName { get; set; }

        /// <summary>
        /// Execute method to write transaction to the database.
        /// </summary>
        public void Execute()
        {
            using ( var rockContext = new RockContext() )
            {
                var signatureDocumentType = new SignatureDocumentTypeService( rockContext ).Get( SignatureDocumentTypeId );
                var assignedPerson = new PersonAliasService( rockContext ).GetPerson( AssignedToPersonAliasId );
                if ( signatureDocumentType != null && assignedPerson != null )
                {
                    var provider = DigitalSignatureContainer.GetComponent( signatureDocumentType.ProviderEntityType.Name );
                    if ( provider != null && provider.IsActive )
                    {
                        string documentKey = provider.SendDocument( rockContext, signatureDocumentType, assignedPerson );

                        var signatureDocument = new SignatureDocument();
                        signatureDocument.SignatureDocumentTypeId = SignatureDocumentTypeId;
                        signatureDocument.Name = DocumentName;
                        signatureDocument.DocumentKey = documentKey;
                        signatureDocument.AppliesToPersonAliasId = AppliesToPersonAliasId;
                        signatureDocument.AssignedToPersonAliasId = AssignedToPersonAliasId;
                        signatureDocument.RequestDate = RockDateTime.Now;
                        signatureDocument.Status = SignatureDocumentStatus.Sent;
                        signatureDocument.LastStatusDate = signatureDocument.RequestDate;

                        var documentService = new SignatureDocumentService( rockContext );
                        documentService.Add( signatureDocument );

                        rockContext.SaveChanges();
                    }
                }
            }
        }
    }
}