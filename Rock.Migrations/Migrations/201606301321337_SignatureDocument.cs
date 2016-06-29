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
namespace Rock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    /// <summary>
    ///
    /// </summary>
    public partial class SignatureDocument : Rock.Migrations.RockMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            CreateTable(
                "dbo.SignatureDocumentType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                        ProviderTemplateKey = c.String(maxLength: 100),
                        BinaryFileTypeId = c.Int(),
                        RequestEmailTemplateFromName = c.String(),
                        RequestEmailTemplateFromAddress = c.String(),
                        RequestEmailTemplateSubject = c.String(),
                        RequestEmailTemplateBody = c.String(),
                        CreatedDateTime = c.DateTime(),
                        ModifiedDateTime = c.DateTime(),
                        CreatedByPersonAliasId = c.Int(),
                        ModifiedByPersonAliasId = c.Int(),
                        Guid = c.Guid(nullable: false),
                        ForeignId = c.Int(),
                        ForeignGuid = c.Guid(),
                        ForeignKey = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BinaryFileType", t => t.BinaryFileTypeId)
                .ForeignKey("dbo.PersonAlias", t => t.CreatedByPersonAliasId)
                .ForeignKey("dbo.PersonAlias", t => t.ModifiedByPersonAliasId)
                .Index(t => t.BinaryFileTypeId)
                .Index(t => t.CreatedByPersonAliasId)
                .Index(t => t.ModifiedByPersonAliasId)
                .Index(t => t.Guid, unique: true)
                .Index(t => t.ForeignId)
                .Index(t => t.ForeignGuid)
                .Index(t => t.ForeignKey);
            
            CreateTable(
                "dbo.SignatureDocument",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SignatureDocumentTypeId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250),
                        DocumentKey = c.String(maxLength: 200),
                        RequestDate = c.DateTime(),
                        AppliesToPersonAliasId = c.Int(),
                        AssignedToPersonAliasId = c.Int(),
                        Status = c.Int(nullable: false),
                        LastStatusDate = c.DateTime(),
                        BinaryFileId = c.Int(),
                        SignedByPersonAliasId = c.Int(),
                        CreatedDateTime = c.DateTime(),
                        ModifiedDateTime = c.DateTime(),
                        CreatedByPersonAliasId = c.Int(),
                        ModifiedByPersonAliasId = c.Int(),
                        Guid = c.Guid(nullable: false),
                        ForeignId = c.Int(),
                        ForeignGuid = c.Guid(),
                        ForeignKey = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonAlias", t => t.AppliesToPersonAliasId)
                .ForeignKey("dbo.PersonAlias", t => t.AssignedToPersonAliasId)
                .ForeignKey("dbo.BinaryFile", t => t.BinaryFileId)
                .ForeignKey("dbo.PersonAlias", t => t.CreatedByPersonAliasId)
                .ForeignKey("dbo.PersonAlias", t => t.ModifiedByPersonAliasId)
                .ForeignKey("dbo.SignatureDocumentType", t => t.SignatureDocumentTypeId, cascadeDelete: true)
                .ForeignKey("dbo.PersonAlias", t => t.SignedByPersonAliasId)
                .Index(t => t.SignatureDocumentTypeId)
                .Index(t => t.AppliesToPersonAliasId)
                .Index(t => t.AssignedToPersonAliasId)
                .Index(t => t.BinaryFileId)
                .Index(t => t.SignedByPersonAliasId)
                .Index(t => t.CreatedByPersonAliasId)
                .Index(t => t.ModifiedByPersonAliasId)
                .Index(t => t.Guid, unique: true)
                .Index(t => t.ForeignId)
                .Index(t => t.ForeignGuid)
                .Index(t => t.ForeignKey);
            
            AddColumn("dbo.Group", "RequiredSignatureDocumentTypeId", c => c.Int());
            AddColumn("dbo.RegistrationTemplate", "RequiredSignatureDocumentTypeId", c => c.Int());
            AddColumn("dbo.RegistrationTemplate", "SignatureDocumentAction", c => c.Int(nullable: false));
            CreateIndex("dbo.Group", "RequiredSignatureDocumentTypeId");
            CreateIndex("dbo.RegistrationTemplate", "RequiredSignatureDocumentTypeId");
            AddForeignKey("dbo.RegistrationTemplate", "RequiredSignatureDocumentTypeId", "dbo.SignatureDocumentType", "Id");
            AddForeignKey("dbo.Group", "RequiredSignatureDocumentTypeId", "dbo.SignatureDocumentType", "Id");
        }
        
        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            DropForeignKey("dbo.Group", "RequiredSignatureDocumentTypeId", "dbo.SignatureDocumentType");
            DropForeignKey("dbo.RegistrationTemplate", "RequiredSignatureDocumentTypeId", "dbo.SignatureDocumentType");
            DropForeignKey("dbo.SignatureDocumentType", "ModifiedByPersonAliasId", "dbo.PersonAlias");
            DropForeignKey("dbo.SignatureDocument", "SignedByPersonAliasId", "dbo.PersonAlias");
            DropForeignKey("dbo.SignatureDocument", "SignatureDocumentTypeId", "dbo.SignatureDocumentType");
            DropForeignKey("dbo.SignatureDocument", "ModifiedByPersonAliasId", "dbo.PersonAlias");
            DropForeignKey("dbo.SignatureDocument", "CreatedByPersonAliasId", "dbo.PersonAlias");
            DropForeignKey("dbo.SignatureDocument", "BinaryFileId", "dbo.BinaryFile");
            DropForeignKey("dbo.SignatureDocument", "AssignedToPersonAliasId", "dbo.PersonAlias");
            DropForeignKey("dbo.SignatureDocument", "AppliesToPersonAliasId", "dbo.PersonAlias");
            DropForeignKey("dbo.SignatureDocumentType", "CreatedByPersonAliasId", "dbo.PersonAlias");
            DropForeignKey("dbo.SignatureDocumentType", "BinaryFileTypeId", "dbo.BinaryFileType");
            DropIndex("dbo.SignatureDocument", new[] { "ForeignKey" });
            DropIndex("dbo.SignatureDocument", new[] { "ForeignGuid" });
            DropIndex("dbo.SignatureDocument", new[] { "ForeignId" });
            DropIndex("dbo.SignatureDocument", new[] { "Guid" });
            DropIndex("dbo.SignatureDocument", new[] { "ModifiedByPersonAliasId" });
            DropIndex("dbo.SignatureDocument", new[] { "CreatedByPersonAliasId" });
            DropIndex("dbo.SignatureDocument", new[] { "SignedByPersonAliasId" });
            DropIndex("dbo.SignatureDocument", new[] { "BinaryFileId" });
            DropIndex("dbo.SignatureDocument", new[] { "AssignedToPersonAliasId" });
            DropIndex("dbo.SignatureDocument", new[] { "AppliesToPersonAliasId" });
            DropIndex("dbo.SignatureDocument", new[] { "SignatureDocumentTypeId" });
            DropIndex("dbo.SignatureDocumentType", new[] { "ForeignKey" });
            DropIndex("dbo.SignatureDocumentType", new[] { "ForeignGuid" });
            DropIndex("dbo.SignatureDocumentType", new[] { "ForeignId" });
            DropIndex("dbo.SignatureDocumentType", new[] { "Guid" });
            DropIndex("dbo.SignatureDocumentType", new[] { "ModifiedByPersonAliasId" });
            DropIndex("dbo.SignatureDocumentType", new[] { "CreatedByPersonAliasId" });
            DropIndex("dbo.SignatureDocumentType", new[] { "BinaryFileTypeId" });
            DropIndex("dbo.RegistrationTemplate", new[] { "RequiredSignatureDocumentTypeId" });
            DropIndex("dbo.Group", new[] { "RequiredSignatureDocumentTypeId" });
            DropColumn("dbo.RegistrationTemplate", "SignatureDocumentAction");
            DropColumn("dbo.RegistrationTemplate", "RequiredSignatureDocumentTypeId");
            DropColumn("dbo.Group", "RequiredSignatureDocumentTypeId");
            DropTable("dbo.SignatureDocument");
            DropTable("dbo.SignatureDocumentType");
        }
    }
}
