using static SpartakHRM.UserService.DAL.Entities.EnumsEntity;

namespace SpartakHRM.UserService.BLL.Models;
public class PatchDocumentModel
{
    public DocumentStatus Status { get; set; }
}
