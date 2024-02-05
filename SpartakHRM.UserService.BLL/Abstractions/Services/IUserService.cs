using SpartakHRM.UserService.BLL.Models;
using SpartakHRM.UserService.DAL.Entities;
using static SpartakHRM.UserService.DAL.Entities.EnumsEntity;

namespace SpartakHRM.UserService.BLL.Abstractions.Services
{
    public interface IUserService : IGenericService<UserEntity, User>
    {
        Task<IEnumerable<User>> GetAllAsync(int pageNumber, int pageSize, string name, WorkStatus? workStatus, string location, CancellationToken cancellationToken);
    }
}