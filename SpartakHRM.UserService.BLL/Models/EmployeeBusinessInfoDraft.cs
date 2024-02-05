using static SpartakHRM.UserService.DAL.Entities.EnumsEntity;

namespace SpartakHRM.UserService.BLL.Models
{
    public class EmployeeBusinessInfoDraft
    {
        public string Email { get; set; }
        public string Position { get; set; }
        public DateOnly AcceptanceDate { get; set; }
        public string Location { get; set; }
        public WorkFormat WorkFormat { get; set; }
        public string OfficeId { get; set; }
    }
}