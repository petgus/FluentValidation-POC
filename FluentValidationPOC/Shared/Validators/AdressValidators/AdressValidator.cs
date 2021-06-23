using FluentValidation;
using FluentValidationPOC.Shared.Models;
using System.Text.RegularExpressions;

namespace FluentValidationPOC.Shared.Validators.AdressValidators
{
    public class AdressValidator : AbstractValidator<Address>
    {
        public AdressValidator()
        {
            // Validator for Norweigans so keep it simple...
            When(x => x.Country.Equals(Country.Norway), () => {
                RuleFor(x => x.Street).NotEmpty();
                RuleFor(x => x.Postcode).NotEmpty();
                RuleFor(x => x.Town).NotEmpty();
            });

            // Swedish address
            When(x => x.Country.Equals(Country.Sweden), () => {
                RuleFor(x => x.Street).NotEmpty();
                RuleFor(x => x.Postcode)
                    .NotEmpty()
                    .Must(BeValidSwedishPostCode).WithMessage("Unvalid postcode. Valid formats: ddd dd or ddddd");
                RuleFor(x => x.Town).NotEmpty();
            });
        }


        protected bool BeValidSwedishPostCode(string input)
        {
            return input != null && Regex.Match(input.Trim(), @"^(\d\d\d \d\d|\d{5})$").Success;
        }
    }
}