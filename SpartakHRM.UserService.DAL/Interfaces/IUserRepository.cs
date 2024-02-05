using SpartakHRM.UserService.DAL.Entities;
using static SpartakHRM.UserService.DAL.Entities.EnumsEntity;

namespace SpartakHRM.UserService.DAL.Interface
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<IEnumerable<UserEntity>> GetAllAsync(int pageNumber, int pageSize, string name, WorkStatus? workStatus, string location, CancellationToken cancellationToken);
    }
}
