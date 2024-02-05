using SpartakHRM.UserService.BLL.Models;
using SpartakHRM.UserService.DAL.Entities;

namespace SpartakHRM.UserService.BLL.Abstractions.Services;
public interface IDocumentService : IGenericService<DocumentEntity, Document>
{
    Task<Document> CreateAsync(CreateDocumentModel createDocumentModel, CancellationToken cancellationToken);
    Task<Document> PatchAsync(Guid id, PatchDocumentModel patchDocument, CancellationToken cancellationToken);
}
