using FluentValidation;
using FluentValidationPOC.Shared.Models;

namespace FluentValidationPOC.Shared.Validators.ArticleValidators
{
    public class ArticleValidator : AbstractValidator<Article>
    {

        /*
         * Adding a custom message & Regex rule
         */
        public ArticleValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().When(x => x.Status == ArticleStatus.ReadyForWeb)
                .WithMessage($"Hey! Name can not be empty when article status is: {ArticleStatus.ReadyForWeb}");

            RuleFor(x => x.ArticleNumber)
                .NotEmpty().When(x => x.Status != ArticleStatus.Discontinued)
                .Matches(@"^\d{4}-\d{3}-\d{4}$");

            RuleFor(x => x.Status).NotNull();
        }


        //protected bool BeAValidArticleNumber(string input)
        //{
        //    return input != null && Regex.Match(input, @"^\d{4}-\d{3}-\d{4}$").Success;
        //}
    }
}
