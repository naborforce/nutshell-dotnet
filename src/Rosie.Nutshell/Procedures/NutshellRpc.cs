using Rosie.Nutshell.Types.Account;
using Rosie.Nutshell.Types.Activity;
using Rosie.Nutshell.Types.Common;
using Rosie.Nutshell.Types.Contact;
using Rosie.Nutshell.Types.Endpoint;
using Rosie.Nutshell.Types.Lead;
using Rosie.Nutshell.Types.Note;
using Rosie.Nutshell.Types.Product;
using Rosie.Nutshell.Types.Tag;
using Rosie.Nutshell.Types.Task;
using Rosie.Nutshell.Types.Team;
using Rosie.Nutshell.Types.Test;
using Rosie.Nutshell.Types.User;

// ReSharper disable once CheckNamespace
namespace Rosie.Nutshell;

// ReSharper disable once InconsistentNaming
public abstract class NutshellRpc : Enumeration
{
    protected NutshellRpc(string name) : base(name)
    {
    }

    public static readonly NutshellRpc<Endpoint, GetEndpointRequest> GetApiForUsername = new("getApiForUsername");
    public static readonly NutshellRpc<int, AddRequest> Add = new("add");

    public static class Accounts
    {
        public static readonly NutshellRpc<NutshellAccount[], FindRequest> FindAccounts = new("findAccounts"); 
        public static readonly NutshellRpc<NutshellEntityStub[], FindRequest> FindAccountTypes = new("findAccountTypes");
        public static readonly NutshellRpc<NutshellAccount[], SearchRequest> SearchAccounts = new("searchAccounts");
        public static readonly NutshellRpc<NutshellAccount, GetAccountRequest> GetAccount = new("getAccount");
        public static readonly NutshellRpc<bool, GetAccountRequest> DeleteAccount = new("deleteAccount");
        public static readonly NutshellRpc<NutshellAccount, PatchAccountRequest> EditAccount = new("editAccount");
        // public static readonly NutshellMethods<NutshellAccount, CreateAccountRequest> NewAccount = new("newAccount");
    }

    public static class Activity
    {
        public static readonly NutshellRpc<NutshellActivity, GetActivityRequest> GetActivity = new("getActivity");
        public static readonly NutshellRpc<NutshellActivity[], FindRequest> FindActivities = new("findActivities");
        public static readonly NutshellRpc<NutshellActivity, PatchActivityRequest> NewActivity = new("newActivity");
        public static readonly NutshellRpc<bool, GetActivityRequest> DeleteActivity = new("deleteActivity");
        public static readonly NutshellRpc<NutshellActivity, PatchActivityRequest> EditActivity = new("editActivity");
    }

    public static class Analytics
    {
        // public static readonly NutshellMethods<NutshellAnalyticsReport,GetAnalyticsReportRequest> GetAnalyticsReport = new("getAnalyticsReport");
    }

    public static class Audiences
    {
        public static readonly NutshellRpc<NutshellIdNamePair[], FindRequest> FindAudiences = new("findAudiences");
    }

    public static class Backups
    {
        // public static readonly NutshellMethods<NutshellBackup,CreateBackupRequest> NewBackup = new("newBackup");
    }

    public static class Common
    {
        public static readonly NutshellRpc<UniversalSearchResults, SearchRequest> SearchUniversal = new("searchUniversal");
        public static readonly NutshellRpc<UniversalSearchResults, EmailAddressQuery> SearchByEmail = new("searchByEmail");
    }

    public static class Competitors
    {
        public static readonly NutshellRpc<NutshellEntityStub[], FindRequest> FindCompetitors = new("findCompetitors");
        public static readonly NutshellRpc<NutshellEntityStub[], SearchRequest> SearchCompetitors = new("searchCompetitors");
    }

    public static class Contacts
    {
        public static readonly NutshellRpc<NutshellContact[], FindRequest> FindContacts = new("findContacts");
        public static readonly NutshellRpc<NutshellContact, EditContactRequest> EditContact = new("editContact");
        public static readonly NutshellRpc<NutshellContact, PatchContactRequest> NewContact = new("newContact");
        public static readonly NutshellRpc<NutshellContact, GetContactRequest> GetContact = new("getContact");
        public static readonly NutshellRpc<NutshellContact[], SearchRequest> SearchContacts = new("searchContacts");
        public static readonly NutshellRpc<bool, GetContactRequest> DeleteContact = new("deleteContact");
        public static readonly NutshellRpc<dynamic, SearchRequest> SearchContactsAndUsers = Users.SearchContactsAndUsers;
    }

    public static class Delays
    {
        public static readonly NutshellRpc<NutshellDelay[], FindRequest> FindDelays = new("findDelays");
    }

    public static class Emails
    {
        // public static readonly NutshellMethods<NutshellEmail, CreateEmailRequest> NewEmail = new("newEmail");
        // public static readonly NutshellMethods<NutshellEmail, GetEmailRequest> GetEmail = new("getEmail");
    }

    public static class Industries
    {
        // public static readonly NutshellMethods<NutshellIndustry[], FindRequest> FindIndustries = new("findIndustries");
    }

    public static class LeadOutcomes
    {
        public static readonly NutshellRpc<NutshellLeadOutcome[], FindRequest> FindLeadOutcomes = new("findLead_Outcomes");
    }

    public static class Leads
    {
        public static readonly NutshellRpc<NutshellLead[], FindLeadsRequest> FindLeads = new("findLeads");
        public static readonly NutshellRpc<NutshellMilestone[], FindRequest> FindMilestones = new("findMilestones");
        public static readonly NutshellRpc<NutshellLead, EditLeadRequest> EditLead = new("editLead");
        public static readonly NutshellRpc<NutshellLead, GetLeadRequest> GetLead = new("getLead");
        public static readonly NutshellRpc<NutshellLeadStub, PatchLeadRequest> NewLead = new("newLead");
        public static readonly NutshellRpc<bool, GetLeadRequest> DeleteLead = new("deleteLead");
    }

    public static class Markets
    {
        public static readonly NutshellRpc<NutshellEntityStub[], FindRequest> FindMarkets = new("findMarkets");
    }
    
    public static class Meta
    {
        public static readonly NutshellRpc<NutshellActivityType[], FindRequest> FindActivityTypes = new("findActivityTypes");
        public static readonly NutshellRpc<NutshellIdNamePair[], FindRequest> FindOrigins = new("findOrigins");
        public static readonly NutshellRpc<NutshellIdNamePair[], FindRequest> FindSources = new("findSources");
        // public static readonly NutshellMethods<NutshellProduct[],FindRequest> FindProducts = new("findProducts");
    }

    public static class Notes
    {
        public static readonly NutshellRpc<NutshellNote, GetNoteRequest> GetNote = new("getNote");
        public static readonly NutshellRpc<bool, GetNoteRequest> DeleteNote = new("deleteNote");
        public static readonly NutshellRpc<NutshellNote, PatchNoteRequest> EditNote = new("editNote");
        // public static readonly NutshellMethods<NutshellNote, CreateNoteRequest> NewNote = new("newNote");
    }

    public static class Products
    {
        // public static readonly NutshellMethods<NutshellProduct,PatchProductRequest> EditProduct = new("editProduct");
        // public static readonly NutshellMethods<NutshellProduct,GetProductRequest> GetProduct = new("getProduct");
        // public static readonly NutshellMethods<NutshellProduct,CreateProductRequest> NewProduct = new("newProduct");
        // public static readonly NutshellMethods<NutshellProduct[],SearchRequest> SearchProducts = new("searchProducts");
        public static readonly NutshellRpc<bool, GetProductRequest> DeleteProduct = new("deleteProduct");
    }

    public static class Settings
    {
        // public static readonly NutshellMethods<NutshellSetting[],FindRequest> FindSettings = new("findSettings");
    }

    public static class Sources
    {
        // public static readonly NutshellMethods<NutshellSource, CreateSourceRequest> NewSource = new("newSource");
        // public static readonly NutshellMethods<NutshellSource[],SearchRequest> SearchSources = new("searchSources");
    }

    public static class Steps
    {
        // public static readonly NutshellMethods<NutshellStep,PatchStepRequest> EditStep = new("editStep");
    }

    public static class Tasks
    {
        // public static readonly NutshellMethods<NutshellTask,PatchTaskRequest> EditTask = new("editTask");
        // public static readonly NutshellMethods<NutshellTask,GetTaskRequest> GetTask = new("getTask");
        public static readonly NutshellRpc<bool, GetTaskRequest> DeleteTask = new("deleteTask");
    }

    public static class Teams
    {
        public static readonly NutshellRpc<NutshellEntityStub[], FindRequest> FindTeams = new("findTeams");
        public static readonly NutshellRpc<bool, GetTeamRequest> DeleteTeam = new("deleteTeam");
        public static readonly NutshellRpc<dynamic, SearchRequest> SearchUsersAndTeams = Users.SearchUsersAndTeams;
        // public static readonly NutshellMethods<NutshellTeam,GetTeamRequest> GetTeam = new("getTeam");
        // public static readonly NutshellMethods<NutshellTeam,PatchTeamRequest> EditTeam = new("editTeam");
    }

    public static class UpdateTimes
    {
        // public static readonly NutshellMethods<NutshellUpdateTimes,GetUpdateTimesRequest> GetUpdateTimes = new("getUpdateTimes");
    }

    public static class Users
    {
        public static readonly NutshellRpc<NutshellEntityStub[], FindRequest> FindUsers = new("findUsers");
        // todo: discover what the return type is for this method
        public static readonly NutshellRpc<dynamic, SearchRequest> SearchUsersAndTeams = new("searchUsersAndTeams");
        public static readonly NutshellRpc<bool, GetUserRequest> DeleteUser = new("deleteUser");
        // public static readonly NutshellMethods<NutshellUser,PatchUserRequest> EditUser = new("editUser");
        // public static readonly NutshellMethods<NutshellUserInstanceData,GetUserInstanceDataRequest> GetUserInstanceData = new("getUserinstanceData");
        // todo: discover what the return type is for this method
        public static readonly NutshellRpc<dynamic, SearchRequest> SearchContactsAndUsers = new("searchContactsAndUsers");
    }

    public static class Tags
    {
        public static readonly NutshellRpc<NutshellTag, PatchTagRequest> NewTag = new("newTag");
    }
}
