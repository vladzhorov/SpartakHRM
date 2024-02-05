using static SpartakHRM.UserService.DAL.Entities.EnumsEntity;

namespace SpartakHRM.UserService.DAL.Entities
{

    public class UserEntity : BaseEntity
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public EmployeePosition Position { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateOnly AcceptanceDate { get; set; }
        public Gender? Gender { get; set; }
        public string Location { get; set; }
        public WorkStatus WorkStatus { get; set; }
        public WorkFormat WorkFormat { get; set; }
        public string AvatarURL { get; set; }
        public Guid? OfficeId { get; set; }
        public List<ContactEntity> Contacts { get; set; } = new();
        public List<DocumentEntity> Documents { get; set; } = new();

        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        //public string Role { get; internal set; }

    }
}

