using FluentValidation;
using System.Text.RegularExpressions;

namespace FluentValidationPOC.Shared.Validators
{
    public static class BusinessSpecificValidationExtensions
    {

        public static IRuleBuilderOptions<T, string> MustBeValidArticleNumberFormat<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(BeAValidArticleNumber).WithMessage(@"Not a valid article number. Valid format is: ""dddd-ddd-dddd"" ");
        }

        public static bool BeAValidArticleNumber(string input)
        {
            return input != null && Regex.Match(input, @"^\d{4}-\d{3}-\d{4}$").Success;
        }




        #region Password

        public static IRuleBuilderOptions<T, string> MustBeValidPassword<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                    .MinimumLength(8).WithMessage("Password must be at least 8 characters")
                    .Must(HaveNumber).WithMessage("Password must contain at least one number.")
                    .Must(HaveUpperChar).WithMessage("Password must contain at least one UPPER CASE letter.");
        }

        private static bool HaveNumber(string input)
        {
            return input != null && Regex.Match(input, @"[0-9]+").Success;
        }

        private static bool HaveUpperChar(string input)
        {
            return input != null && Regex.Match(input, @"[A-Z]+").Success;
        }

        #endregion password
    }
}
