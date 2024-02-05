using FluentValidation;
using SpartakHRM.UserService.API.ViewModel.Draft;

namespace SpartakHRM.UserService.API.Validators.Draft
{

    public class CreateDraftValidator : AbstractValidator<CreateDraft>
    {
        public CreateDraftValidator()
        {

            RuleFor(draft => draft.Type).IsInEnum();
            RuleFor(draft => draft.Email).NotEmpty().EmailAddress();
            RuleFor(draft => draft.Position).IsInEnum();
            RuleFor(draft => draft.Location).NotEmpty();
            RuleFor(draft => draft.WorkFormat).IsInEnum();

        }
    }
}
