using SpartakHRM.UserService.DAL.Entities;
using SpartakHRM.UserService.DAL.Interfaces;

namespace SpartakHRM.UserService.DAL.Repositories;

public class OfficeRepository : Repository<OfficeEntity>, IOfficeRepository
{
    public OfficeRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
