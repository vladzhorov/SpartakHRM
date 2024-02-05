using static SpartakHRM.UserService.DAL.Entities.EnumsEntity;

namespace SpartakHRM.UserService.API.ViewModel.Documents;

public class DocumentViewModel
{
    public Guid Id { get; set; }
    public DocumentType Type { get; set; }
    public DocumentStatus Status { get; set; }
    public DateOnly DateFrom { get; set; }
    public DateOnly DateTo { get; set; }
    public EmployeeDetailsViewModel? EmployeeDetails { get; set; }
    public string Note { get; set; } = string.Empty;
}
