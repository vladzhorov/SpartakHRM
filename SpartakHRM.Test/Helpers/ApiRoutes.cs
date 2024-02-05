namespace SpartakHRM.IntegrationTest.Helpers
{
    static class ApiRoutes
    {

        public const string Base = "api";
        public const string Drafts = Base + "/drafts";
        public const string Users = Base + "/users";
        public const string exisDraftId = "{draftId}";
        public const string NonExisDraftId = "non_existing_draft_id";
    }
}

