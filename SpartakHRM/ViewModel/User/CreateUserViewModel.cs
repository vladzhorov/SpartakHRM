using static SpartakHRM.UserService.DAL.Entities.EnumsEntity;

namespace SpartakHRM.UserService.API.ViewModel.NewFolder
{
    public class CreateUserViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public EmployeePosition Position { get; set; }
        public Gender? Gender { get; set; }
        public WorkStatus WorkStatus { get; set; }
        public WorkFormat WorkFormat { get; set; }
        public DateTime BirthDate { get; set; }
        public string Location { get; set; }
        public string AvatarURL { get; set; }
    }
}
