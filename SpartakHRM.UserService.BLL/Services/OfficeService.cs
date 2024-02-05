using AutoMapper;
using SpartakHRM.UserService.BLL.Abstractions.Services;
using SpartakHRM.UserService.BLL.Models;
using SpartakHRM.UserService.DAL.Entities;
using SpartakHRM.UserService.DAL.Interfaces;

namespace SpartakHRM.UserService.BLL.Services;

public class OfficeService : GenericService<OfficeEntity, Office>, IOfficeService
{
    public OfficeService(IOfficeRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
