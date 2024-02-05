using static SpartakHRM.UserService.DAL.Entities.EnumsEntity;

namespace SpartakHRM.UserService.DAL.Entities
{
    public class EmployeeBusinessInfoDraftEntity
    {
        public string Email { get; set; }
        public string Position { get; set; }
        public DateOnly AcceptanceDate { get; set; }
        public string Location { get; set; }
        public WorkFormat WorkFormat { get; set; }
        public string OfficeId { get; set; }
    }
}
