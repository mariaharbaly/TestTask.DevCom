using FluentValidation;
using TestTask.DevCom.Contracts.User;

namespace TestTask.DevCom.Api.Validators;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    private static readonly List<string> Genders = new() {"W","M"};

    public CreateUserRequestValidator()
    {
        RuleFor(x => x.Login).NotEmpty().Length(3, 20);
        RuleFor(x => x.Password).NotEmpty().Length(4, 50);
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(40);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(40);
        RuleFor(x => x.Gender).NotEmpty().Must(x => Genders.Contains(x))
            .WithMessage("Please only use: " + String.Join(",", Genders));
    }
}