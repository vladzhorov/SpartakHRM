using FluentValidation;
using SpartakHRM.UserService.API.ViewModel.User;

namespace SpartakHRM.UserService.API.Validators.User
{
    public class UpdateUserViewModelValidator : AbstractValidator<UpdateUser>
    {
        public UpdateUserViewModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Surname).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Position).IsInEnum();
            RuleFor(x => x.WorkStatus).IsInEnum();
            RuleFor(x => x.WorkFormat).IsInEnum();
            //RuleFor(x => x.BirthDate).NotEmpty();
            //RuleFor(x => x.Location).NotEmpty();
            //RuleFor(x => x.AvatarURL).MaximumLength(100).When(x => x.AvatarURL != null);
        }
    }
}
