using FluentValidation;

public class DraftModelValidator : AbstractValidator<DraftViewModel>
{
    public DraftModelValidator()
    {
        RuleFor(draft => draft.Id).NotEmpty();
        RuleFor(draft => draft.Type).IsInEnum();
        RuleFor(draft => draft.PersonalInfo).NotNull();
        RuleFor(draft => draft.BusinessInfo).NotNull();
        RuleFor(draft => draft.Email).NotEmpty().EmailAddress();
        RuleFor(draft => draft.Position).IsInEnum();
        RuleFor(draft => draft.AcceptanceDate).NotEmpty();
        RuleFor(draft => draft.Location).NotEmpty();
        RuleFor(draft => draft.WorkFormat).IsInEnum();
        RuleFor(draft => draft.CreatedAt).NotEmpty();
        RuleFor(draft => draft.UpdatedAt).NotEmpty();
    }
}
