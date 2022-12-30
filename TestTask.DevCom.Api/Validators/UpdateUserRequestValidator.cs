using FluentValidation;
using TestTask.DevCom.Contracts.User;

namespace TestTask.DevCom.Api.Validators;

public class UpdateUserRequestValidator: AbstractValidator<UpdateUserRequest>
{
    private static readonly List<string> Genders = new() {"W","M"};

    public UpdateUserRequestValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(40);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(40);
        RuleFor(x => x.Gender).NotEmpty().Must(x => Genders.Contains(x))
            .WithMessage("Please only use: " + String.Join(",", Genders));
    }
}