// *********************************************************************
// Created by : Latebound Constants Generator 1.2020.2.1 for XrmToolBox
// Author     : Jonas Rapp https://twitter.com/rappen
// GitHub     : https://github.com/rappen/LCG-UDG
// Source Org : https://devsos.crm4.dynamics.com
// Filename   : C:\Dev\GitHub\EntityPermissionVisualizer\Rappen.XTB.EntityPermissionVisualizer\EPVEntities.cs
// Created    : 2021-01-07 22:30:34
// *********************************************************************

namespace Rappen.XTB.EPV
{
    /// <summary>DisplayName: Entitetsbehörighet, OwnershipType: OrganizationOwned, IntroducedVersion: 7.0.0</summary>
    public static class EntitypeRmission
    {
        public const string EntityName = "adx_entitypermission";
        public const string EntityCollectionName = "adx_entitypermissions";

        #region Attributes

        /// <summary>Type: String, RequiredLevel: ApplicationRequired, MaxLength: 400, Format: Text</summary>
        public const string PrimaryName = "adx_entityname";
        /// <summary>Type: String, RequiredLevel: ApplicationRequired, MaxLength: 250, Format: Text</summary>
        public const string EntityLogicalName = "adx_entitylogicalname";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 1000, Format: Text</summary>
        public const string ContactRelationship = "adx_contactrelationship";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 1000, Format: Text</summary>
        public const string AccountRelationship = "adx_accountrelationship";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        public const string Append = "adx_append";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        public const string Read = "adx_read";
        /// <summary>Type: Picklist, RequiredLevel: ApplicationRequired, DisplayName: Omfattning, OptionSetType: Picklist, DefaultFormValue: -1</summary>
        public const string Scope = "adx_scope";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: adx_entitypermission</summary>
        public const string ParentEntitypeRmission = "adx_parententitypermission";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 200, Format: Text</summary>
        public const string ParentRelationship = "adx_parentrelationship";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        public const string Create = "adx_create";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        public const string Write = "adx_write";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        public const string Delete = "adx_delete";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        public const string Appendto = "adx_appendto";
        /// <summary>Type: Lookup, RequiredLevel: ApplicationRequired, Targets: adx_website</summary>
        public const string WebsiteId = "adx_websiteid";

        #endregion Attributes

        #region Relationships

        /// <summary>Parent: "Website" Child: "EntitypeRmission" Lookup: "WebsiteId"</summary>
        public const string RelM1_WebsiteAdxEntitypeRmission = "adx_website_adx_entitypermission";
        /// <summary>Parent: "EntitypeRmission" Child: "EntitypeRmission" Lookup: "ParentEntitypeRmission"</summary>
        public const string Rel1M_EntitypeRmissionParentEntiTyPeRmission = "adx_entitypermission_parententitypermission";
        /// <summary>Entity 1: "EntitypeRmission" Entity 2: "Webrole"</summary>
        public const string RelMM_EntitypeRmissionWebrole = "adx_entitypermission_webrole";

        #endregion Relationships

        #region OptionSets

        public enum Scope_OptionSet
        {
            Global = 756150000,
            Kontakt = 756150001,
            Konto = 756150002,
            Overordnad = 756150003,
            Sjalv = 756150004
        }

        #endregion OptionSets
    }

    /// <summary>DisplayName: Webbplats, OwnershipType: UserOwned, IntroducedVersion: 1.0.21</summary>
    public static class Website
    {
        public const string EntityName = "adx_website";
        public const string EntityCollectionName = "adx_websites";

        #region Attributes

        /// <summary>Type: String, RequiredLevel: ApplicationRequired, MaxLength: 100, Format: Text</summary>
        public const string PrimaryName = "adx_name";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 253, Format: Text</summary>
        public const string PrimaryDomainName = "adx_primarydomainname";

        #endregion Attributes

        #region Relationships

        /// <summary>Parent: "Website" Child: "Webrole" Lookup: "WebsiteId"</summary>
        public const string Rel1M_WebsiteWebrole = "adx_website_webrole";
        /// <summary>Parent: "Website" Child: "EntitypeRmission" Lookup: "WebsiteId"</summary>
        public const string Rel1M_WebsiteAdxEntitypeRmission = "adx_website_adx_entitypermission";

        #endregion Relationships
    }

    /// <summary>DisplayName: Webbroll, OwnershipType: UserOwned, IntroducedVersion: 1.0.21</summary>
    public static class Webrole
    {
        public const string EntityName = "adx_webrole";
        public const string EntityCollectionName = "adx_webroles";

        #region Attributes

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
}
