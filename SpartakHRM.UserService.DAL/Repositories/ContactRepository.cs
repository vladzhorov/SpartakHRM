using Microsoft.EntityFrameworkCore;
using SpartakHRM.UserService.DAL.Entities;
using SpartakHRM.UserService.DAL.Interface;
using static SpartakHRM.UserService.DAL.Entities.EnumsEntity;

namespace SpartakHRM.UserService.DAL.Repositories
{
    public class ContactRepository : Repository<ContactEntity>, IContactRepository
    {
        public ContactRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<ContactEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Contacts.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<ContactEntity>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await _dbContext.Contacts.Where(contact => contact.UserId == userId).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<ContactEntity>> GetByTypeAsync(ContactType type, CancellationToken cancellationToken)
        {
            return await _dbContext.Contacts.Where(contact => contact.Type == type).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<ContactEntity>> GetPrimaryContactsAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Contacts.Where(contact => contact.IsPrimary).ToListAsync(cancellationToken);
        }
    }
}
