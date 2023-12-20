using Cohorts_01.Models;
using FluentValidation;

namespace Cohorts_01.Validation;

public class UserValidation : AbstractValidator<User>
{
    public UserValidation()
    {
        RuleFor(f => f.ID)
            .NotEmpty()
            .WithMessage("ID is required.");
    }
}