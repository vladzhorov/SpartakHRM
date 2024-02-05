using static SpartakHRM.UserService.DAL.Entities.EnumsEntity;

namespace SpartakHRM.UserService.DAL.Entities
{

    public class EmployeePersonalInfoDraftEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly BirthDate { get; set; }
        public Gender Gender { get; set; }
    }
}
