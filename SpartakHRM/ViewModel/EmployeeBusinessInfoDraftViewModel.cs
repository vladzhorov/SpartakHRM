using static SpartakHRM.UserService.DAL.Entities.EnumsEntity;

namespace SpartakHRM.UserService.API.ViewModel
{
    public class EmployeeBusinessInfoDraftViewModel
    {
        public string Email { get; set; }
        public string Position { get; set; }
        public DateTime AcceptanceDate { get; set; }
        public string Location { get; set; }
        public WorkFormat WorkFormat { get; set; }
        public string OfficeId { get; set; }
    }
}