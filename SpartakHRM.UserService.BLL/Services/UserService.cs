using AutoMapper;
using SpartakHRM.UserService.BLL.Abstractions.Services;
using SpartakHRM.UserService.BLL.Models;
using SpartakHRM.UserService.DAL.Entities;
using SpartakHRM.UserService.DAL.Interface;

namespace SpartakHRM.UserService.BLL.Services
{
    public class UserService : GenericService<UserEntity, User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IMapper mapper)
            : base(userRepository, mapper)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllAsync(int pageNumber, int pageSize, string name,
            EnumsEntity.WorkStatus? workStatus, string location,
            CancellationToken cancellationToken)
        {
            var entities = await _userRepository.GetAllAsync(pageNumber, pageSize, name, workStatus, location, cancellationToken);
            var models = _mapper.Map<IEnumerable<User>>(entities);
            return models;
        }
    }
}