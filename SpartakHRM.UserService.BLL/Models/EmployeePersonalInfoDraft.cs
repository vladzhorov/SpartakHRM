using static SpartakHRM.UserService.DAL.Entities.EnumsEntity;

namespace SpartakHRM.UserService.BLL.Models
{
    public class EmployeePersonalInfoDraft
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly BirthDate { get; set; }
        public Gender Gender { get; set; }
    }
}