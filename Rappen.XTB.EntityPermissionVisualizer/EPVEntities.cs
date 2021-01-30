// *********************************************************************
// Created by : Latebound Constants Generator 1.2021.1.2 for XrmToolBox
// Author     : Jonas Rapp https://jonasr.app/
// GitHub     : https://github.com/rappen/LCG-UDG/
// Source Org : https://jonasbells.crm4.dynamics.com/
// Filename   : C:\Dev\GitHub\EntityPermissionVisualizer\Rappen.XTB.EntityPermissionVisualizer\EPVEntities.cs
// Created    : 2021-01-30 12:46:08
// *********************************************************************

namespace Rappen.XTB.EPV
{
    /// <summary>DisplayName: Entity Permission, OwnershipType: OrganizationOwned, IntroducedVersion: 7.0.0</summary>
    public static class Entitypermission
    {
        public const string EntityName = "adx_entitypermission";
        public const string EntityCollectionName = "adx_entitypermissions";

        #region Attributes

        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string PrimaryKey = "adx_entitypermissionid";
        /// <summary>Type: String, RequiredLevel: ApplicationRequired, MaxLength: 400, Format: Text</summary>
        public const string PrimaryName = "adx_entityname";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 1000, Format: Text</summary>
        public const string AccountRelationship = "adx_accountrelationship";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        public const string Append = "adx_append";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        public const string Appendto = "adx_appendto";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 1000, Format: Text</summary>
        public const string ContactRelationship = "adx_contactrelationship";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        public const string Create = "adx_create";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        public const string Delete = "adx_delete";
        /// <summary>Type: String, RequiredLevel: ApplicationRequired, MaxLength: 250, Format: Text</summary>
        public const string EntityLogicalName = "adx_entitylogicalname";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: adx_entitypermission</summary>
        public const string ParentEntitypermission = "adx_parententitypermission";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 200, Format: Text</summary>
        public const string ParentRelationship = "adx_parentrelationship";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        public const string Read = "adx_read";
        /// <summary>Type: Picklist, RequiredLevel: ApplicationRequired, DisplayName: Scope, OptionSetType: Picklist, DefaultFormValue: -1</summary>
        public const string Scope = "adx_scope";
        /// <summary>Type: Lookup, RequiredLevel: ApplicationRequired, Targets: adx_website</summary>
        public const string WebsiteId = "adx_websiteid";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        public const string Write = "adx_write";

        #endregion Attributes

        #region Relationships

        /// <summary>Parent: "Website" Child: "Entitypermission" Lookup: "WebsiteId"</summary>
        public const string RelM1_WebsiteAdxEntitypermission = "adx_website_adx_entitypermission";
        /// <summary>Parent: "Entitypermission" Child: "Entitypermission" Lookup: "ParentEntitypermission"</summary>
        public const string Rel1M_EntitypermissionParentEntiTyPeRmission = "adx_entitypermission_parententitypermission";
        /// <summary>Entity 1: "Entitypermission" Entity 2: "Webrole"</summary>
        public const string RelMM_EntitypermissionWebrole = "adx_entitypermission_webrole";

        #endregion Relationships

        #region OptionSets

        public enum Scope_OptionSet
        {
            Global = 756150000,
            Contact = 756150001,
            Account = 756150002,
            Parent = 756150003,
            Self = 756150004
        }

        #endregion OptionSets
    }

    /// <summary>DisplayName: Web Role, OwnershipType: UserOwned, IntroducedVersion: 1.0.21</summary>
    public static class Webrole
    {
        public const string EntityName = "adx_webrole";
        public const string EntityCollectionName = "adx_webroles";

        #region Attributes

        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string PrimaryKey = "adx_webroleid";
        /// <summary>Type: String, RequiredLevel: ApplicationRequired, MaxLength: 100, Format: Text</summary>
        public const string PrimaryName = "adx_name";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        public const string AnonymousUserSrole = "adx_anonymoususersrole";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        public const string AuthenticatedUserSrole = "adx_authenticatedusersrole";
        /// <summary>Type: Memo, RequiredLevel: None, MaxLength: 2000</summary>
        public const string Description = "adx_description";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string Key = "adx_key";
        /// <summary>Type: Lookup, RequiredLevel: ApplicationRequired, Targets: adx_website</summary>
        public const string WebsiteId = "adx_websiteid";

        #endregion Attributes

        #region Relationships

        /// <summary>Parent: "Website" Child: "Webrole" Lookup: "WebsiteId"</summary>
        public const string RelM1_WebsiteWebrole = "adx_website_webrole";
        /// <summary>Entity 1: "Websiteaccess" Entity 2: "Webrole"</summary>
        public const string RelMM_WebsiteaccessWebrole = "adx_websiteaccess_webrole";

        #endregion Relationships
    }

    /// <summary>OwnershipType: UserOwned, IntroducedVersion: 1.0.21</summary>
    public static class Website
    {
        public const string EntityName = "adx_website";
        public const string EntityCollectionName = "adx_websites";

        #region Attributes

        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string PrimaryKey = "adx_websiteid";
        /// <summary>Type: String, RequiredLevel: ApplicationRequired, MaxLength: 100, Format: Text</summary>
        public const string PrimaryName = "adx_name";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 253, Format: Text</summary>
        public const string PrimaryDomainName = "adx_primarydomainname";

        #endregion Attributes

        #region Relationships

        /// <summary>Parent: "Website" Child: "Webrole" Lookup: "WebsiteId"</summary>
        public const string Rel1M_WebsiteWebrole = "adx_website_webrole";
        /// <summary>Parent: "Website" Child: "Entitypermission" Lookup: "WebsiteId"</summary>
        public const string Rel1M_WebsiteAdxEntitypermission = "adx_website_adx_entitypermission";

        #endregion Relationships
    }
}


/***** LCG-configuration-BEGIN *****\
<?xml version="1.0" encoding="utf-16"?>
<Settings xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Version>1.2021.1.2</Version>
  <NameSpace>Rappen.XTB.EPV</NameSpace>
  <UseCommonFile>true</UseCommonFile>
  <SaveConfigurationInCommonFile>true</SaveConfigurationInCommonFile>
  <FileName>DisplayName</FileName>
  <ConstantName>LogicalName</ConstantName>
  <ConstantCamelCased>true</ConstantCamelCased>
  <DoStripPrefix>true</DoStripPrefix>
  <StripPrefix>adx_</StripPrefix>
  <XmlProperties>true</XmlProperties>
  <XmlDescription>false</XmlDescription>
  <Regions>true</Regions>
  <RelationShips>true</RelationShips>
  <RelationshipLabels>false</RelationshipLabels>
  <OptionSets>true</OptionSets>
  <GlobalOptionSets>false</GlobalOptionSets>
  <Legend>false</Legend>
  <CommonAttributes>None</CommonAttributes>
  <AttributeSortMode>None</AttributeSortMode>
  <SelectedEntities>
    <SelectedEntity>
      <Name>adx_entitypermission</Name>
      <Attributes>
        <string>adx_accountrelationship</string>
        <string>adx_append</string>
        <string>adx_appendto</string>
        <string>adx_contactrelationship</string>
        <string>adx_create</string>
        <string>adx_delete</string>
        <string>adx_entitylogicalname</string>
        <string>adx_entitypermissionid</string>
        <string>adx_entityname</string>
        <string>adx_parententitypermission</string>
        <string>adx_parentrelationship</string>
        <string>adx_read</string>
        <string>adx_scope</string>
        <string>adx_websiteid</string>
        <string>adx_write</string>
      </Attributes>
      <Relationships>
        <string>adx_entitypermission_parententitypermission</string>
        <string>adx_website_adx_entitypermission</string>
        <string>adx_entitypermission_webrole</string>
      </Relationships>
    </SelectedEntity>
    <SelectedEntity>
      <Name>adx_webrole</Name>
      <Attributes>
        <string>adx_anonymoususersrole</string>
        <string>adx_authenticatedusersrole</string>
        <string>adx_description</string>
        <string>adx_key</string>
        <string>adx_name</string>
        <string>adx_webroleid</string>
        <string>adx_websiteid</string>
      </Attributes>
      <Relationships>
        <string>adx_website_webrole</string>
        <string>adx_webrole_contact</string>
        <string>adx_webrole_account</string>
        <string>adx_webrole_systemuser</string>
        <string>adx_websiteaccess_webrole</string>
      </Relationships>
    </SelectedEntity>
    <SelectedEntity>
      <Name>adx_website</Name>
      <Attributes>
        <string>adx_name</string>
        <string>adx_primarydomainname</string>
        <string>adx_websiteid</string>
      </Attributes>
      <Relationships>
        <string>adx_website_webrole</string>
        <string>adx_website_adx_entitypermission</string>
      </Relationships>
    </SelectedEntity>
  </SelectedEntities>
</Settings>
\***** LCG-configuration-END   *****/
