using static SpartakHRM.UserService.DAL.Entities.EnumsEntity;

namespace SpartakHRM.UserService.BLL.Models;

public class CreateDocumentModel
{
    public Guid? EmployeeId { get; set; }
    public DocumentType Type { get; set; }
    public DateOnly DateFrom { get; set; }
    public DateOnly DateTo { get; set; }
    public string Note { get; set; } = string.Empty;

    public EmployeeHireDetails? EmployeeHireDetails { get; set; }
}
