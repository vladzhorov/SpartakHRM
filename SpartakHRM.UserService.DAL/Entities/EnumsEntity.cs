namespace SpartakHRM.UserService.DAL.Entities
{
    public class EnumsEntity
    {
        public enum Gender
        {
            Male,
            Female
        }

        public enum EmployeePosition
        {
            Developer,
            Director
        }

        public enum WorkStatus
        {
            Active,
            InVacation,
            OnSickLeave,
            Idle
        }

        public enum WorkFormat
        {
            Office,
            Remotely,
            Hybrid
        }

        public enum ContactType
        {
            Email,
            Phone,
            Telegram
        }

        public enum DocumentType
        {
            Vacation = 0,
            EmployeeHire = 1,
            SickDay = 2,
            EmployeeLeave = 3
        }

        public enum DocumentStatus
        {
            Pending = 0,
            Rejected = 1,
            Approved = 2
        }

        public enum DraftType
        {
            AddUser
        }
    }
}
