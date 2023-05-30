using System.Linq;
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
using Rosie.Nutshell.Types.User;
using Rosie.Platform.Abstractions.Enumerations;
using Rosie.Platform.Abstractions.Unions;
using Rosie.Platform.Extensions;

namespace Rosie.Nutshell;

public abstract class NutshellMethods : Enumeration
{
    internal static readonly UnionType TypeGuard = UnionType.Create(s
        => s.DisallowNull()
            .DisallowAllTypeValues()
            .WithoutTypeConstraints()
            .AllowValues(values: methods.Cast<object>().ToArray())
            .WithValueConstraints(v => v?.ToString().IsIn(methods) == true)
            .Build());

    private static readonly string[] methods = GetAll<NutshellMethods>().Select(e => e.Name).ToArray();

    protected internal NutshellMethods(string name) : base(name)
    {
    }

    public static readonly NutshellMethods<Endpoint, GetEndpointRequest> GetApiForUsername = new("getApiForUsername");

    public static readonly NutshellMethods<NutshellAccount[], FindRequest> FindAccounts = new("findAccounts");

    public static readonly NutshellMethods<NutshellEntityStub[], FindRequest>
        FindAccountTypes = new("findAccountTypes");

    public static readonly NutshellMethods<NutshellActivity[], FindRequest> FindActivities = new("findActivities");

    public static readonly NutshellMethods<NutshellActivityType[], FindRequest> FindActivityTypes =
        new("findActivityTypes");

    public static readonly NutshellMethods<NutshellEntityStub[], FindRequest> FindCompetitors = new("findCompetitors");
    public static readonly NutshellMethods<NutshellContact[], FindRequest> FindContacts = new("findContacts");
    public static readonly NutshellMethods<NutshellDelay[], FindRequest> FindDelays = new("findDelays");

    // public static readonly NutshellMethods<NutshellIndustry[],FindRequest> FindIndustries = new("findIndustries");
    public static readonly NutshellMethods<NutshellLeadOutcome[], FindRequest> FindLeadOutcomes =
        new("findLead_Outcomes");

    public static readonly NutshellMethods<NutshellLead[], FindRequest> FindLeads = new("findLeads");
    public static readonly NutshellMethods<NutshellEntityStub[], FindRequest> FindMarkets = new("findMarkets");
    public static readonly NutshellMethods<NutshellIdNamePair[], FindRequest> FindAudiences = new("findAudiences");
    public static readonly NutshellMethods<NutshellMilestone[], FindRequest> FindMilestones = new("findMilestones");

    public static readonly NutshellMethods<NutshellIdNamePair[], FindRequest> FindOrigins = new("findOrigins");

    // public static readonly NutshellMethods<NutshellProduct[],FindRequest> FindProducts = new("findProducts");
    // public static readonly NutshellMethods<NutshellSetting[],FindRequest> FindSettings = new("findSettings");
    public static readonly NutshellMethods<NutshellIdNamePair[], FindRequest> FindSources = new("findSources");
    public static readonly NutshellMethods<NutshellEntityStub[], FindRequest> FindTeams = new("findTeams");
    public static readonly NutshellMethods<NutshellEntityStub[], FindRequest> FindUsers = new("findUsers");
    public static readonly NutshellMethods<NutshellAccount[], SearchRequest> SearchAccounts = new("searchAccounts");

    public static readonly NutshellMethods<NutshellEntityStub[], SearchRequest> SearchCompetitors =
        new("searchCompetitors");

    public static readonly NutshellMethods<NutshellContact[], SearchRequest> SearchContacts = new("searchContacts");

    // todo: discover what the return type is for this method
    public static readonly NutshellMethods<dynamic, SearchRequest> SearchContactsAndUsers =
        new("searchContactsAndUsers");

    // public static readonly NutshellMethods<NutshellProduct[],SearchRequest> SearchProducts = new("searchProducts");
    // public static readonly NutshellMethods<NutshellSource[],SearchRequest> SearchSources = new("searchSources");
    // todo: discover what the return type is for this method
    public static readonly NutshellMethods<dynamic, SearchRequest> SearchUniversal = new("searchUniversal");

    // todo: discover what the return type is for this method
    public static readonly NutshellMethods<dynamic, SearchRequest> SearchUsersAndTeams = new("searchUsersAndTeams");

    public static readonly NutshellMethods<bool, GetAccountRequest> DeleteAccount = new("deleteAccount");
    public static readonly NutshellMethods<bool, GetActivityRequest> DeleteActivity = new("deleteActivity");
    public static readonly NutshellMethods<bool, GetContactRequest> DeleteContact = new("deleteContact");
    public static readonly NutshellMethods<bool, GetLeadRequest> DeleteLead = new("deleteLead");
    public static readonly NutshellMethods<bool, GetNoteRequest> DeleteNote = new("deleteNote");
    public static readonly NutshellMethods<bool, GetProductRequest> DeleteProduct = new("deleteProduct");
    public static readonly NutshellMethods<bool, GetTaskRequest> DeleteTask = new("deleteTask");
    public static readonly NutshellMethods<bool, GetTeamRequest> DeleteTeam = new("deleteTeam");

    public static readonly NutshellMethods<bool, GetUserRequest> DeleteUser = new("deleteUser");

    public static readonly NutshellMethods<NutshellAccount, PatchAccountRequest> EditAccount = new("editAccount");
    public static readonly NutshellMethods<NutshellActivity, PatchActivityRequest> EditActivity = new("editActivity");
    public static readonly NutshellMethods<NutshellContact, PatchContactRequest> EditContact = new("editContact");
    public static readonly NutshellMethods<NutshellLead, PatchLeadRequest> EditLead = new("editLead");
    public static readonly NutshellMethods<NutshellNote, PatchNoteRequest> EditNote = new("editNote");

    // public static readonly NutshellMethods<NutshellProduct,PatchProductRequest> EditProduct = new("editProduct");
    // public static readonly NutshellMethods<NutshellStep,PatchStepRequest> EditStep = new("editStep");
    // public static readonly NutshellMethods<NutshellTask,PatchTaskRequest> EditTask = new("editTask");
    // public static readonly NutshellMethods<NutshellTeam,PatchTeamRequest> EditTeam = new("editTeam");
    // public static readonly NutshellMethods<NutshellUser,PatchUserRequest> EditUser = new("editUser");
    public static readonly NutshellMethods<NutshellAccount, GetAccountRequest> GetAccount = new("getAccount");

    public static readonly NutshellMethods<NutshellActivity, GetActivityRequest> GetActivity = new("getActivity");

    // public static readonly NutshellMethods<NutshellAnalyticsReport,GetAnalyticsReportRequest> GetAnalyticsReport = new("getAnalyticsReport");
    public static readonly NutshellMethods<NutshellContact, GetContactRequest> GetContact = new("getContact");

    // public static readonly NutshellMethods<NutshellEmail, GetEmailRequest> GetEmail = new("getEmail");
    public static readonly NutshellMethods<NutshellLead, GetLeadRequest> GetLead = new("getLead");

    public static readonly NutshellMethods<NutshellNote, GetNoteRequest> GetNote = new("getNote");

    // public static readonly NutshellMethods<NutshellProduct,GetProductRequest> GetProduct = new("getProduct");
    // public static readonly NutshellMethods<NutshellTask,GetTaskRequest> GetTask = new("getTask");
    // public static readonly NutshellMethods<NutshellTeam,GetTeamRequest> GetTeam = new("getTeam");
    // public static readonly NutshellMethods<NutshellUpdateTimes,GetUpdateTimesRequest> GetUpdateTimes = new("getUpdateTimes");
    // public static readonly NutshellMethods<NutshellUserInstanceData,GetUserInstanceDataRequest> GetUserInstanceData = new("getUserinstanceData");
    // public static readonly NutshellMethods<NutshellAccount, CreateAccountRequest> NewAccount = new("newAccount");

    public static readonly NutshellMethods<NutshellActivity, PatchActivityRequest> NewActivity = new("newActivity");

    // public static readonly NutshellMethods<NutshellBackup,CreateBackupRequest> NewBackup = new("newBackup");
    public static readonly NutshellMethods<NutshellContact, PatchContactRequest> NewContact = new("newContact");

    // public static readonly NutshellMethods<NutshellEmail, CreateEmailRequest> NewEmail = new("newEmail");
    public static readonly NutshellMethods<NutshellLead, PatchLeadRequest> NewLead = new("newLead");

    // public static readonly NutshellMethods<NutshellNote, CreateNoteRequest> NewNote = new("newNote");

    // public static readonly NutshellMethods<NutshellProduct,CreateProductRequest> NewProduct = new("newProduct");
    // public static readonly NutshellMethods<NutshellSource, CreateSourceRequest> NewSource = new("newSource");

    public static readonly NutshellMethods<NutshellTag, PatchTagRequest> NewTag = new("newTag");
    // public static readonly NutshellMethods<NutshellTask,CreateTaskRequest> NewTask = new("newTask");
    // public static readonly NutshellMethods<NutshellTeam,CreateTeamRequest> NewTeam = new("newTeam");
    // public static readonly NutshellMethods<NutshellUser,CreateUserRequest> NewUser = new("newUser");
}