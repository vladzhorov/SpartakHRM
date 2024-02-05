using static SpartakHRM.UserService.DAL.Entities.EnumsEntity;

namespace SpartakHRM.UserService.DAL.Entities
{
    public class ContactEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public ContactType Type { get; set; }
        public string Value { get; set; }
        public bool IsPrimary { get; set; }

        public bool IsDelete { get; set; }

        // Navigation property for User
        public UserEntity User { get; set; }
    }
}
