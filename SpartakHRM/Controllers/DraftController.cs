using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpartakHRM.UserService.API.Helpers;
using SpartakHRM.UserService.API.ViewModel.Draft;
using SpartakHRM.UserService.BLL.Abstractions.Services;
using SpartakHRM.UserService.BLL.Models;

namespace SpartakHRM.UserService.Controllers
{
    [ApiController]
    [Route("api/drafts")]
    public class DraftController : ControllerBase
    {
        private readonly IUserDraftService _userDraftService;
        private readonly IMapper _mapper;
        //private readonly IValidator<DraftViewModel> _draftValidator;
        //private readonly IValidator<EmployeePersonalInfoDraft> _personalInfoValidator;
        //private readonly IValidator<EmployeeBusinessInfoDraft> _businessInfoValidator;
        //private readonly IValidator<CreateDraft> _createDraftValidator;
        //private readonly IValidator<UpdateDraft> _updateDraftValidator;
        //
        public DraftController(
            IUserDraftService userDraftService,
            IMapper mapper)
        {
            _userDraftService = userDraftService;
            _mapper = mapper;
            //_draftValidator = draftValidator;
            //_personalInfoValidator = personalInfoValidator;
            //_businessInfoValidator = businessInfoValidator;
            //_createDraftValidator = createDraftValidator;
            //_updateDraftValidator = updateDraftValidator;
        }

        [HttpGet]

        public async Task<IEnumerable<DraftViewModel>> GetAllUsers(CancellationToken cancellationToken)
        {
            var draft = await _userDraftService.GetAllAsync(cancellationToken);

            if (draft == null)
            {
                // Обработка ситуации, когда draft равен null
                // Например, возврат пустого списка или другое действие
                return new List<DraftViewModel>();
            }

            var draftViewModels = draft.Select(draft => ConvertToViewModel(draft)).ToList();
            return draftViewModels;
        }

        [HttpGet($"{Routes.BaseDraft}")]
        public async Task<DraftViewModel> GetDraftById(string draftId, CancellationToken cancellationToken)
        {
            var draft = await _userDraftService.GetByIdAsync(Guid.Parse(draftId), cancellationToken);
            return ConvertToViewModel(draft);
        }

        [HttpPost]
        public async Task CreateDraft(CreateDraft draftViewModel, CancellationToken cancellationToken)
        {
            var draft = _mapper.Map<Draft>(draftViewModel);
            //await _createDraftValidator.ValidateAndThrowAsync(draftViewModel);
            await _userDraftService.CreateAsync(draft, cancellationToken);
        }

        [HttpPut(Routes.BaseDraftPersonal)]
        public async Task UpdatePersonalInfoDraft(
            string draftId,
            EmployeePersonalInfoDraft personalInfo,
            CancellationToken cancellationToken)
        {
            //await _personalInfoValidator.ValidateAndThrowAsync(personalInfo);

            var draft = await _userDraftService.GetByIdAsync(Guid.Parse(draftId), cancellationToken);
            draft.PersonalInfo = personalInfo;
            await _userDraftService.UpdateAsync(draft, cancellationToken);
        }

        [HttpPut(Routes.BaseDraftBusiness)]
        public async Task UpdateBusinessInfoDraft(
            string draftId,
            EmployeeBusinessInfoDraft businessInfo,
            CancellationToken cancellationToken)
        {
            //await _businessInfoValidator.ValidateAndThrowAsync(businessInfo);

            var draft = await _userDraftService.GetByIdAsync(Guid.Parse(draftId), cancellationToken);
            draft.BusinessInfo = businessInfo;
            await _userDraftService.UpdateAsync(draft, cancellationToken);
        }

        [HttpDelete($"{Routes.BaseDraft}")]
        public async Task DeleteDraft(string draftId, CancellationToken cancellationToken)
        {
            await _userDraftService.DeleteAsync(Guid.Parse(draftId), cancellationToken);
        }

        private DraftViewModel ConvertToViewModel(Draft draftModel)//
        {
            return _mapper.Map<DraftViewModel>(draftModel);
        }
    }
}
