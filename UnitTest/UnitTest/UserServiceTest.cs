using AutoMapper;
using Microsoft.CodeAnalysis;
using Moq;
using SpartakHRM.UserService.API.Mapper;
using SpartakHRM.UserService.BLL.Models;
using SpartakHRM.UserService.BLL.Services;
using SpartakHRM.UserService.DAL.Entities;
using SpartakHRM.UserService.DAL.Interface;
using static SpartakHRM.UserService.DAL.Entities.EnumsEntity;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly IMapper _mapper;
    private readonly UserService _userService;

    public UserServiceTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ViewModelMappingProfile>();
        });
        _mapper = config.CreateMapper();
        _userService = new UserService(_userRepositoryMock.Object, _mapper);
    }

    [Fact]
    public async Task GetAllUsers_ReturnsListOfUserModels()
    {
        int pageNumber = 1;
        int pageSize = 10;
        string Name = "";
        WorkStatus WorkStatus = 0;
        string Location = "";
        // Arrange
        var (users, userModels) = UsersTestData.TestGetAllUsers();
        _userRepositoryMock.Setup(x => x.GetAllAsync(pageNumber, pageSize, Name, WorkStatus, Location, It.IsAny<CancellationToken>())).ReturnsAsync(users);


        // Act
        var result = await _userService.GetAllAsync(pageNumber, pageSize, Name, WorkStatus, Location, CancellationToken.None);

        // Assert
        Assert.Equal(userModels.Count, result.Count());
        Assert.Equal(userModels[0].Id, result.ElementAt(0).Id);
        Assert.Equal(userModels[1].Name, result.ElementAt(1).Name);
        //... and so on for other properties
    }

    [Fact]

    public async Task GetUserById_ExistingUserId_ReturnsUserModel()
    {
        // Arrange
        var (userId, user, userModel) = UsersTestData.CreateUser();
        _userRepositoryMock.Setup(x => x.GetByIdAsync(userId, CancellationToken.None)).ReturnsAsync(user);

        // Act
        var result = await _userService.GetByIdAsync(userId, cancellationToken: CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(userModel.Id, result.Id);
        Assert.Equal(userModel.Name, result.Name);
        // ... and so on for other properties
    }

    [Fact]
    public async Task GetUserById_NonExistingUserId_ReturnsNull()
    {
        var userId = Guid.NewGuid();
        _userRepositoryMock.Setup(x => x.GetByIdAsync(userId, CancellationToken.None)).ReturnsAsync((UserEntity)null);
        await Assert.ThrowsAsync<NotFoundException>(async () =>
        {
            await _userService.GetByIdAsync(userId, CancellationToken.None);
        });
    }

    [Fact]

    public async Task CreateUser_ValidUserModel_CallsAddAsyncWithCorrectUserEntity()
    {
        // Arrange
        var (newUserModel, newUser) = UsersTestData.CreateNewUser();
        _userRepositoryMock.Setup(x => x.AddAsync(It.IsNotNull<UserEntity>(), CancellationToken.None)).ReturnsAsync(newUser);

        // Act
        await _userService.CreateAsync(newUserModel, CancellationToken.None);

        // Assert
        _userRepositoryMock.Verify(x => x.AddAsync(It.IsNotNull<UserEntity>(), CancellationToken.None), Times.Once);
    }

    [Fact]

    public async Task UpdateUser_ExistingUserId_ValidUserModel_CallsUpdateAsyncWithCorrectUserEntity()
    {
        // Arrange
        var (userId, existingUser, updatedUserModel) = UsersTestData.CreateExistingUser();
        _userRepositoryMock.Setup(x => x.GetByIdAsync(userId, CancellationToken.None)).ReturnsAsync(existingUser);
        _userRepositoryMock.Setup(x => x.UpdateAsync(It.IsNotNull<UserEntity>(), CancellationToken.None)).ReturnsAsync(existingUser);

        // Act
        await _userService.UpdateAsync(updatedUserModel, CancellationToken.None);

        // Assert
        _userRepositoryMock.Verify(x => x.UpdateAsync(It.IsNotNull<UserEntity>(), CancellationToken.None), Times.Once);
        Assert.Equal(updatedUserModel.Name, existingUser.Name);
    }


    [Fact]
    public async Task UpdateUser_NonExistingUserId_ThrowsException()
    {
        _userRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<UserEntity>(), CancellationToken.None)).ReturnsAsync((UserEntity?)null);

        await Assert.ThrowsAsync<NotFoundException>(async () =>
        {
            await _userService.UpdateAsync(It.IsAny<User>(), CancellationToken.None);
        });

        _userRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<UserEntity>(), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task DeleteUser_ExistingUserId_CallsDeleteAsyncWithCorrectUserEntity()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var existingUser = new UserEntity { Id = userId, Name = "John" };
        _userRepositoryMock.Setup(x => x.GetByIdAsync(userId, CancellationToken.None)).ReturnsAsync(existingUser);
        _userRepositoryMock.Setup(x => x.DeleteAsync(existingUser, CancellationToken.None)).Returns(Task.CompletedTask);

        // Act
        await _userService.DeleteAsync(userId, CancellationToken.None);

        // Assert
        _userRepositoryMock.Verify(x => x.DeleteAsync(existingUser, CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task DeleteUser_NonExistingUserId_ThrowsException()
    {
        // Arrange
        var userId = Guid.NewGuid();
        _userRepositoryMock.Setup(x => x.GetByIdAsync(userId, CancellationToken.None)).ReturnsAsync((UserEntity)null);

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(async () => await _userService.DeleteAsync(userId, CancellationToken.None));
        _userRepositoryMock.Verify(x => x.DeleteAsync(It.IsAny<UserEntity>(), CancellationToken.None), Times.Never);
    }
}

