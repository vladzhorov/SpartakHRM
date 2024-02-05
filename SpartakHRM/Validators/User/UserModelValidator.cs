using FluentValidation;
using SpartakHRM.UserService.BLL.Models;

public class UserModelValidator : AbstractValidator<User>
{
    public UserModelValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Surname).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Position).IsInEnum();
        RuleFor(x => x.BirthDate).NotEmpty();
        RuleFor(x => x.AcceptanceDate).NotEmpty();
        RuleFor(x => x.Gender).IsInEnum().When(x => x.Gender != null);
        RuleFor(x => x.Location).NotEmpty();
        RuleFor(x => x.WorkStatus).IsInEnum();
        RuleFor(x => x.WorkFormat).IsInEnum();
        RuleFor(x => x.AvatarURL).MaximumLength(100).When(x => x.AvatarURL != null);
        RuleFor(x => x.OfficeId).NotEmpty();
        RuleFor(x => x.Contacts).NotEmpty().WithMessage("Contacts are required").Must(BeUniquePrimaryContact)
            .WithMessage("Only one primary contact is allowed");
    }

    private bool BeUniquePrimaryContact(IEnumerable<Contact> contacts)
    {
        return contacts.Count(c => c.IsPrimary) <= 1;
    }
}