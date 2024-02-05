//using SpartakHRM.IntegrationTest.Helpers;
//using SpartakHRM.UserService.BLL.Models;
//using System.Net;
//using System.Text.Json;

//namespace SpartakHRM.Test.IntegrationTest
//{
//    public class IntegrationDraftTest : IClassFixture<DatabaseFixture>
//    {
//        private readonly DatabaseFixture _fixture;
//        private readonly HttpClient _httpClient;

//        public IntegrationDraftTest(DatabaseFixture fixture)
//        {
//            _fixture = fixture;
//            _httpClient = _fixture.CreateClient();
//        }

//        [Fact]


//        public async Task GetDraft_ExistingId_ReturnsOkStatusAndDraft()
//        {
//            // Задание существующего Id Draft
//            var existingDraftId = DatabaseFixture.ExistingDraftId;

//            // Создание HTTP запроса GET для получения существующего Draft
//            var response = await _httpClient.GetAsync($"/api/drafts/{existingDraftId}");

//            // Проверка, что статус код равен 200 OK
//            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

//            // Чтение JSON тела ответа
//            var responseContent = await response.Content.ReadAsStringAsync();

//            // Преобразование JSON тела ответа в объект Draft
//            var existingDraft = JsonSerializer.Deserialize<Draft>(responseContent);

//            // Проверка, что существующий Draft был возвращен успешно
//            Assert.NotNull(existingDraft);
//        }

//        [Fact]
//        public async Task DeleteDraft_ExistingDraftId_ReturnsNoContentResult()
//        {
//            // Arrange
//            var draftId = DatabaseFixture.ExistingDraftId;

//            // Act
//            var response = await _httpClient.DeleteAsync($"{ApiRoutes.Drafts}/{draftId}");

//            // Assert
//            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
//        }

//        [Fact]
//        public async Task DeleteDraft_NonExistingDraftId_ReturnsNotFoundResult()
//        {
//            // Arrange
//            var draftId = DatabaseFixture.NonExistingDraftId;

//            // Act
//            var response = await _httpClient.DeleteAsync($"{ApiRoutes.Drafts}/{draftId}");

//            // Assert
//            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
//        }
//    }
//}
