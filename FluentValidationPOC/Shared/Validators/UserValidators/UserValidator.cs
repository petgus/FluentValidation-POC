using FluentValidation;
using FluentValidationPOC.Shared.Models;
using FluentValidationPOC.Shared.Validators.AdressValidators;

namespace FluentValidationPOC.Shared.Validators.UserValidators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator() {

            RuleFor(x => x.Username).NotEmpty().EmailAddress();

            RuleSet("Password", () =>
            {
                RuleFor(x => x.Password)
                    .NotEmpty()
                    .MustBeValidPassword();

                RuleFor(x => x.PasswordConfirmation)
                    .NotEmpty().WithMessage("Please confirm password")
                    .Equal(x => x.Password)
                    .WithMessage("Passwords do not match");
            });

            RuleFor(x => x.Address).SetValidator(new AdressValidator());
        }
    }
}
