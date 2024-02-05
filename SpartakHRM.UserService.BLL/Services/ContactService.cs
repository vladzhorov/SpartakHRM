using SpartakHRM.UserService.BLL.Abstractions.Services;
using SpartakHRM.UserService.DAL.Entities;
using SpartakHRM.UserService.DAL.Interface;
using System.Linq.Expressions;

namespace SpartakHRM.UserService.BLL.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<ContactEntity> GetContactByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _contactRepository.GetByIdAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<ContactEntity>> GetAllContactsAsync(CancellationToken cancellationToken)
        {
            return await _contactRepository.GetAllAsync(cancellationToken);
        }

        public async Task<IEnumerable<ContactEntity>> GetContactsByPredicateAsync(Expression<Func<ContactEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _contactRepository.GetByPredicateAsync(predicate, cancellationToken);
        }

        public async Task AddContactAsync(ContactEntity contact, CancellationToken cancellationToken)
        {
            await _contactRepository.AddAsync(contact, cancellationToken);
        }

        public async Task UpdateContactAsync(ContactEntity contact, CancellationToken cancellationToken)
        {
            await _contactRepository.UpdateAsync(contact, cancellationToken);
        }

        public async Task DeleteContactAsync(ContactEntity contact, CancellationToken cancellationToken)
        {
            await _contactRepository.DeleteAsync(contact, cancellationToken);
        }
    }
}
