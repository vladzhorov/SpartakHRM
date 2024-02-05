using SpartakHRM.UserService.BLL.Models;
using SpartakHRM.UserService.DAL.Entities;

public static class UsersTestData
{
    public static (List<UserEntity> users, List<User> userModels) TestGetAllUsers()
    {
        var userId1 = Guid.NewGuid();
        var userId2 = Guid.NewGuid();

        var users = new List<UserEntity>
    {
        new UserEntity { Id = userId1, Name = "John" },
        new UserEntity { Id = userId2, Name = "Jane" }
    };

        var userModels = new List<User>
    {
        new User { Id = userId1, Name = "John" },
        new User { Id = userId2, Name = "Jane" }
    };

        return (users, userModels);
    }


    public static (Guid userId, UserEntity user, User userModel) CreateUser()
    {
        var userId = Guid.NewGuid();
        var user = new UserEntity { Id = userId, Name = "John" };
        var userModel = new User { Id = userId, Name = "John" }; // Change "Jane" to "John"

        return (userId, user, userModel);
    }


    public static (User newUserModel, UserEntity newUser) CreateNewUser()
    {
        var newUserModel = new User { Name = "John" };
        var newUser = new UserEntity { Name = "John" };

        return (newUserModel, newUser);
    }

    public static (Guid userId, UserEntity existingUser, User updatedUserModel) CreateExistingUser()
    {
        var userId = Guid.NewGuid();
        var existingUser = new UserEntity { Id = userId, Name = "John" };
        var updatedUserModel = new User { Id = userId, Name = "John" };

        return (userId, existingUser, updatedUserModel);
    }

    public static (Guid userId, User updatedUserModel) CreateNonExistingUser()
    {
        var userId = Guid.NewGuid();
        var updatedUserModel = new User { Id = userId, Name = "John" };

        return (userId, null);
    }
}