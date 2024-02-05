using SpartakHRM.UserService.BLL.Models;

namespace SpartakHRM.Test.TestHelper
{
    public static class UserControllerTestHelper
    {
        public static List<User> CreateUserModels()
        {
            return new List<User>
            {
                new User { Id = Guid.NewGuid(), Name = "John" },
                new User { Id = Guid.NewGuid(), Name = "Jane" }
            };
        }

        public static User CreateUserModel(Guid userId, string name)
        {
            return new User { Id = userId, Name = name };
        }

        public static (Guid userId, User user) CreateExistingUser()
        {
            var userId = Guid.NewGuid();
            var user = new User { Id = userId, Name = "John" };
            return (userId, user);
        }
    }
}
