namespace SpartakHRM.UserService.API.Helpers
{
    static class Routes
    {
        public const string BaseDraft = "{draftId}";
        public const string BaseDraftPersonal = BaseDraft + "/personal-info";
        public const string BaseDraftBusiness = BaseDraft + "/business-info";
    }
}
