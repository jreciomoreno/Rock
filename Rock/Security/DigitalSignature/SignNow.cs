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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;
using Rock.Attribute;
using Rock.Data;
using Rock.Model;
using Rock.Web.Cache;

namespace Rock.Security.BackgroundCheck
{
    /// <summary>
    /// SignNow Digital Signature Provider
    /// </summary>
    [Description( "SignNow Digital Signature Provider" )]
    [Export( typeof( DigitalSignatureComponent ) )]
    [ExportMetadata( "ComponentName", "SignNow" )]

    [TextField( "API Key", "The SignNow API Key", true, "", "", 0 )]
    public class SignNow : DigitalSignatureComponent
    {
        /// <summary>
        /// Sends the document.
        /// </summary>
        /// <param name="rockContext">The rock context.</param>
        /// <param name="documentType">Type of the document.</param>
        /// <param name="person">The person.</param>
        /// <returns></returns>
        public override string SendDocument( RockContext rockContext, SignatureDocumentType documentType, Person person )
        {
            return "documentKey";
        }

        /// <summary>
        /// Resends the document.
        /// </summary>
        /// <param name="rockContext">The rock context.</param>
        /// <param name="document">The document.</param>
        /// <param name="person">The person.</param>
        /// <returns></returns>
        public override string ResendDocument( RockContext rockContext, SignatureDocument document, Person person )
        {
            return string.Empty;
        }


        /// <summary>
        /// Cancels the document.
        /// </summary>
        /// <param name="rockContext">The rock context.</param>
        /// <param name="document">The document.</param>
        /// <returns></returns>
        public override string CancelDocument( RockContext rockContext, SignatureDocument document )
        {
            return string.Empty;
        }

    }
}