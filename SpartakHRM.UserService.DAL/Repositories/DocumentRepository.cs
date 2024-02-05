using Microsoft.EntityFrameworkCore;
using SpartakHRM.UserService.DAL.Entities;
using SpartakHRM.UserService.DAL.Interfaces;

namespace SpartakHRM.UserService.DAL.Repositories;
public class DocumentRepository : Repository<DocumentEntity>, IDocumentRepository
{
    public DocumentRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public override Task<DocumentEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _dbContext.Documents
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public override async Task<IEnumerable<DocumentEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Documents.Include(x => x.User).OrderByDescending(x => x.CreatedAt).ToListAsync(cancellationToken);
    }
}