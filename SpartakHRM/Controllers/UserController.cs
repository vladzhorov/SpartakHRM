using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SpartakHRM.UserService.API.ViewModel.NewFolder;
using SpartakHRM.UserService.API.ViewModel.User;
using SpartakHRM.UserService.BLL.Abstractions.Services;
using SpartakHRM.UserService.BLL.Models;
using static SpartakHRM.UserService.DAL.Entities.EnumsEntity;

namespace SpartakHRM.UserService.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IValidator<User> _userValidator;
        private readonly IValidator<CreateUserViewModel> _createUserValidator;
        private readonly IValidator<UpdateUser> _updateUserValidator;


        public UserController(IUserService userService, IMapper mapper, IValidator<User> userValidator, IValidator<CreateUserViewModel> createUserValidator, IValidator<UpdateUser> _updateUserValidator)
        {
            _userService = userService;
            _mapper = mapper;
            _userValidator = userValidator;
            _createUserValidator = createUserValidator;
        }

        [HttpGet]
        public async Task<IEnumerable<UserViewModel>> GetAllUsers(int pageNumber, int pageSize, string Name = null, WorkStatus? workStatus = null, string location = null, CancellationToken cancellationToken = default)
        {
            var users = await _userService.GetAllAsync(pageNumber, pageSize, Name, workStatus, location, cancellationToken);
            var userViewModels = users.Select(user => ConvertToViewModel(user)).ToList();
            return userViewModels;
        }

        [HttpGet("{id}")]
        public async Task<UserViewModel> GetUserById(Guid id, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByIdAsync(id, cancellationToken);
            return ConvertToViewModel(user);
        }

        [HttpPost]
        public async Task<UserViewModel> CreateUser(CreateUserViewModel viewModel, CancellationToken cancellationToken)
        {
            var modelToCreate = _mapper.Map<User>(viewModel);
            modelToCreate.OfficeId = Guid.NewGuid();
            await _createUserValidator.ValidateAndThrowAsync(viewModel);
            var result = await _userService.CreateAsync(modelToCreate, cancellationToken);

            return _mapper.Map<UserViewModel>(result);
        }


        [HttpPut("{id}")]
        public async Task<UserViewModel> UpdateUser(Guid id, UpdateUser viewModel, CancellationToken cancellationToken)
        {
            var modelToUpdate = _mapper.Map<User>(viewModel);
            modelToUpdate.Id = id;
            var result = await _userService.UpdateAsync(modelToUpdate, cancellationToken);

            return _mapper.Map<UserViewModel>(result);
        }

        [HttpDelete("{id}")]
        public async Task DeleteUser(Guid id, CancellationToken cancellationToken)
        {
            await _userService.DeleteAsync(id, cancellationToken);
        }

        private UserViewModel ConvertToViewModel(User userModel)//
        {
            return _mapper.Map<UserViewModel>(userModel);
        }
    }
}
