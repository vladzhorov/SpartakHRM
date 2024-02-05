using FluentValidation;

namespace SpartakHRM.UserService.BLL.Models
{
    public class EmployeeBusinessInfoDraftModelValidator : AbstractValidator<EmployeeBusinessInfoDraft>
    {
        public EmployeeBusinessInfoDraftModelValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(100);
            //RuleFor(x => x.Position).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Position).NotEmpty();
            RuleFor(x => x.AcceptanceDate).NotEmpty();
            RuleFor(x => x.Location).NotEmpty();
            RuleFor(x => x.WorkFormat).IsInEnum();
            RuleFor(x => x.OfficeId).NotEmpty()/*.When(x => x.OfficeId != null)*/;
        }
    }
}
