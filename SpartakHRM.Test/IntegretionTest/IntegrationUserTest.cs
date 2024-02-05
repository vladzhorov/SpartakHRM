using SpartakHRM.IntegrationTest.Helpers;
using SpartakHRM.UserService.API.ViewModel.NewFolder;
using SpartakHRM.UserService.API.ViewModel.User;
using System.Net;
using System.Net.Http.Json;
using static SpartakHRM.UserService.DAL.Entities.EnumsEntity;

namespace SpartakHRM.Test.IntegrationTest
{
    public class IntegrationUserTest : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;
        private readonly HttpClient _httpClient;

        public IntegrationUserTest(DatabaseFixture fixture)
        {
            _fixture = fixture;
            _httpClient = _fixture.CreateClient();
        }

        [Fact]
        public async Task UserController_GetAllUsers_ReturnsOk()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, ApiRoutes.Users);

            // Act
            var response = await _httpClient.SendAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetUserById_ExistingUserId_ReturnsOkResultWithUser()
        {
            // Arrange
            var id = new Guid(DatabaseFixture.ExistingUserId);

            // Act
            var response = await _httpClient.GetAsync($"api/users/{Guid.NewGuid()}");
            var returnedUser = await response.Content.ReadFromJsonAsync<UserViewModel>();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(returnedUser);
            Assert.Equal(id, returnedUser.Id);
        }

        [Fact]
        public async Task CreateUser_ValidUser_CreatesNewUser()
        {
            var newUser = new CreateUserViewModel
            {
                Name = "TestName",
                Surname = "TestSurname",
                Position = EmployeePosition.Developer,
                Gender = Gender.Male,
                WorkStatus = WorkStatus.Active,
                WorkFormat = WorkFormat.Remotely,
                BirthDate = new DateTime(1980, 1, 1),
                Location = "TestLocation",
                AvatarURL = "TestAvatarURL"
            };

            var response = await _httpClient.PostAsJsonAsync("api/users", newUser);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task UpdateUser_ValidUpdate_UpdatesExistingUser()
        {
            var userIdToUpdate = DatabaseFixture.UpdateUserId;
            var updateUser = new UpdateUser
            {
                Name = "UpdatedName",
                Surname = "UpdatedSurname",
                Position = EmployeePosition.Director,
                WorkStatus = WorkStatus.InVacation,
                WorkFormat = WorkFormat.Hybrid,
                Location = "UpdatedLocation",
                AvatarURL = "UpdatedAvatarURL",

            };

            var response = await _httpClient.PutAsJsonAsync($"api/users/{userIdToUpdate}", updateUser);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task UserController_DeleteUser_ExistingId_ReturnsNoContent()
        {
            // Arrange
            var existingUserId = new Guid(DatabaseFixture.ExistingUserId);
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{ApiRoutes.Users}/{existingUserId}");

            // Act
            var response = await _httpClient.SendAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task UserController_DeleteUser_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            var nonExistingUserId = new Guid(DatabaseFixture.ExistingUserId);
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{ApiRoutes.Users}/{nonExistingUserId}");

            // Act
            var response = await _httpClient.SendAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

    }
}
