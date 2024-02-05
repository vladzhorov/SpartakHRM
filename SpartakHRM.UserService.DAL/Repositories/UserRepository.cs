using Microsoft.EntityFrameworkCore;
using SpartakHRM.UserService.DAL.Entities;
using SpartakHRM.UserService.DAL.Interface;
using static SpartakHRM.UserService.DAL.Entities.EnumsEntity;

namespace SpartakHRM.UserService.DAL.Repositories
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<UserEntity>> GetAllAsync(int pageNumber, int pageSize, string name, WorkStatus? workStatus, string location, CancellationToken cancellationToken)
        {
            var query = _dbContext.Users.AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                var nameInLower = name.ToLower();
                query = query.Where(x => EF.Functions.Like(x.Name.ToLower(), $"%{nameInLower}%") || EF.Functions.Like(x.Surname.ToLower(), $"%{nameInLower}%"));
            }
            if (workStatus != null)
            {
                query = query.Where(x => x.WorkStatus == workStatus);
            }
            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(x => x.Location.Contains(location));
            }

            return await query.Where(x => !x.IsDeleted).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        }
    }
}
