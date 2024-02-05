using static SpartakHRM.UserService.DAL.Entities.EnumsEntity;

namespace SpartakHRM.UserService.API.ViewModel.Draft
{
    public class CreateDraft
    {
        public string Id { get; set; }

        public DraftType Type { get; set; }
        public string Email { get; set; }

        public EmployeePosition Position { get; set; }

        public string Location { get; set; }
        public WorkFormat WorkFormat { get; set; }

    }
}
