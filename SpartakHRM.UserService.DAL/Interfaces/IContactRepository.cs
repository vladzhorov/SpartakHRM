using SpartakHRM.UserService.DAL.Entities;
using System.Linq.Expressions;
using static SpartakHRM.UserService.DAL.Entities.EnumsEntity;

namespace SpartakHRM.UserService.DAL.Interface
{
    public interface IContactRepository
    {
        Task<ContactEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<ContactEntity>> GetAllAsync(CancellationToken cancellationToken);
        Task<IEnumerable<ContactEntity>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
        Task<IEnumerable<ContactEntity>> GetByTypeAsync(ContactType type, CancellationToken cancellationToken);
        Task<IEnumerable<ContactEntity>> GetPrimaryContactsAsync(CancellationToken cancellationToken);
        Task<ContactEntity> AddAsync(ContactEntity contact, CancellationToken cancellationToken);
        Task<ContactEntity> UpdateAsync(ContactEntity contact, CancellationToken cancellationToken);
        Task DeleteAsync(ContactEntity contact, CancellationToken cancellationToken);
        Task<IEnumerable<ContactEntity>> GetByPredicateAsync(Expression<Func<ContactEntity, bool>> predicate, CancellationToken cancellationToken);
    }
}
