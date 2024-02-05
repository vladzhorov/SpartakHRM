using SpartakHRM.UserService.DAL.Entities;
using System.Linq.Expressions;

namespace SpartakHRM.UserService.BLL.Abstractions.Services
{
    public interface IContactService
    {
        Task<ContactEntity> GetContactByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<ContactEntity>> GetAllContactsAsync(CancellationToken cancellationToken);
        Task<IEnumerable<ContactEntity>> GetContactsByPredicateAsync(Expression<Func<ContactEntity, bool>> predicate, CancellationToken cancellationToken);
        Task AddContactAsync(ContactEntity contact, CancellationToken cancellationToken);
        Task UpdateContactAsync(ContactEntity contact, CancellationToken cancellationToken);
        Task DeleteContactAsync(ContactEntity contact, CancellationToken cancellationToken);
    }
}
