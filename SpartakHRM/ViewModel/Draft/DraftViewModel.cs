using SpartakHRM.UserService.API.ViewModel;
using System.Text.Json.Serialization;
using static SpartakHRM.UserService.DAL.Entities.EnumsEntity;

public class DraftViewModel
{
    public string Id { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public DraftType Type { get; set; }
    public EmployeePersonalInfoDraftViewModel PersonalInfo { get; set; }
    public EmployeeBusinessInfoDraftViewModel BusinessInfo { get; set; }
    public string Email { get; set; }
    public EmployeePosition Position { get; set; }
    public DateTime AcceptanceDate { get; set; }
    public string Location { get; set; }
    public WorkFormat WorkFormat { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid? OfficeId { get; set; }
}
