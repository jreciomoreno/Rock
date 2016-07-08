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
using System.Collections.Generic;

using Rock.Data;
using Rock.Model;
using Rock.Extension;
using Rock.Web.Cache;

namespace Rock.Security
{
    /// <summary>
    /// The base class for all digital signature methods
    /// </summary>
    public abstract class DigitalSignatureComponent : Component
    {
        /// <summary>
        /// Abstract method for requesting a document be sent to recipient for signature
        /// </summary>
        /// <param name="rockContext">The rock context.</param>
        /// <param name="documentType">Type of the document.</param>
        /// <param name="email">The email.</param>
        /// <param name="errors">The errors.</param>
        /// <returns></returns>
        public abstract string SendDocument( RockContext rockContext, SignatureDocumentType documentType, string email, out List<string> errors );

        /// <summary>
        /// Resends the document.
        /// </summary>
        /// <param name="rockContext">The rock context.</param>
        /// <param name="document">The document.</param>
        /// <param name="email">The email.</param>
        /// <param name="errors">The errors.</param>
        /// <returns></returns>
        public abstract string ResendDocument( RockContext rockContext, SignatureDocument document, string email, out List<string> errors );


        /// <summary>
        /// Cancels the document.
        /// </summary>
        /// <param name="rockContext">The rock context.</param>
        /// <param name="document">The document.</param>
        /// <param name="errors">The errors.</param>
        /// <returns></returns>
        public abstract string CancelDocument( RockContext rockContext, SignatureDocument document, out List<string> errors );
    }

}
