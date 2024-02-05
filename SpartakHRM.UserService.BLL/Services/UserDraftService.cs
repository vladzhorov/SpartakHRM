using AutoMapper;
using SpartakHRM.UserService.BLL.Abstractions.Services;
using SpartakHRM.UserService.BLL.Models;
using SpartakHRM.UserService.DAL.Entities;
using SpartakHRM.UserService.DAL.Interface;

namespace SpartakHRM.UserService.BLL.Services
{
    public class UserDraftService : GenericService<UserDraftEntity, Draft>, IUserDraftService
    {
        public UserDraftService(IUserDraftRepository userDraftRepository, IMapper mapper)
            : base(userDraftRepository, mapper)
        {
        }

    }
}