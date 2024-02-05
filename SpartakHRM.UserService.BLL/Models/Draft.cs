using static SpartakHRM.UserService.DAL.Entities.EnumsEntity;

namespace SpartakHRM.UserService.BLL.Models
{
    public class Draft
    {
        public string Id { get; set; }


        public DraftType Type { get; set; }
        public EmployeePersonalInfoDraft PersonalInfo { get; set; }
        public EmployeeBusinessInfoDraft BusinessInfo { get; set; }
        public string Email { get; set; }
        public EmployeePosition Position { get; set; }
        public DateOnly AcceptanceDate { get; set; }
        public string Location { get; set; }
        public WorkFormat WorkFormat { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid? OfficeId { get; set; }
    }
}
