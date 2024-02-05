using FluentValidation;

namespace SpartakHRM.UserService.BLL.Models
{
    public class EmployeePersonalInfoDraftModelValidator : AbstractValidator<EmployeePersonalInfoDraft>
    {
        public EmployeePersonalInfoDraftModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Surname).NotEmpty().MaximumLength(50);
            RuleFor(x => x.BirthDate).NotEmpty();
            RuleFor(x => x.Gender).IsInEnum().When(x => x.Gender != null);
        }
    }
}
