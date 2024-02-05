using SpartakHRM.UserService.BLL.Models;
using static SpartakHRM.UserService.DAL.Entities.EnumsEntity;

namespace SpartakHRM.Test.TestHelper
{
    public static class DraftControllerTestHelper
    {
        public static Draft CreateDraft(DraftType type)
        {
            return new Draft { Id = Guid.NewGuid().ToString(), Type = type };
        }

        public static (string draftId, Draft draft) CreateExistingDraft(DraftType type)
        {
            var draftId = Guid.NewGuid().ToString();
            var draft = new Draft { Id = draftId, Type = type };
            return (draftId, draft);
        }

        public static EmployeePersonalInfoDraft CreatePersonalInfoDraftModel(string name, string surname)
        {
            return new EmployeePersonalInfoDraft { Name = name, Surname = surname };
        }

        public static EmployeeBusinessInfoDraft CreateBusinessInfoDraftModel(string email, string position)
        {
            return new EmployeeBusinessInfoDraft { Email = email, Position = position };
        }
    }
}
