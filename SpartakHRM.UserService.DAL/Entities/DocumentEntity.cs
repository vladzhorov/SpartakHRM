using static SpartakHRM.UserService.DAL.Entities.EnumsEntity;

namespace SpartakHRM.UserService.DAL.Entities;

public class DocumentEntity : BaseEntity
{
    public DocumentType Type { get; set; }
    public DocumentStatus Status { get; set; }
    public DateOnly DateFrom { get; set; }
    public DateOnly DateTo { get; set; }
    public string Note { get; set; } = string.Empty;

    public Guid? UserId { get; set; }
    public UserEntity? User { get; set; }
}