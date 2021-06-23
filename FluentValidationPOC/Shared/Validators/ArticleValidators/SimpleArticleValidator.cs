using FluentValidation;
using FluentValidationPOC.Shared.Models;

namespace FluentValidationPOC.Shared.Validators.ArticleValidators
{
    public class SimpleArticleValidator : AbstractValidator<Article>
    {
        public SimpleArticleValidator()
        {
            RuleFor(x => x.Name).NotEmpty().When(x => x.Status == ArticleStatus.ReadyForWeb); // Must have name when in status ready for web
            RuleFor(x => x.ArticleNumber).NotEmpty().When(x => x.Status != ArticleStatus.Discontinued); // If discontinued it's ok to omit article number
            RuleFor(x => x.Status).NotNull();
        }
    }
}
