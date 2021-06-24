using FluentValidation;
using FluentValidationPOC.Shared.Models;

namespace FluentValidationPOC.Shared.Validators.ArticleValidators
{
    public class SimpleArticleValidator : AbstractValidator<Article>
    {
        public SimpleArticleValidator()
        {
            RuleFor(x => x.Name).NotEmpty().When(x => x.Status == ArticleStatus.ReadyForWeb);
            RuleFor(x => x.ArticleNumber).NotEmpty();
            RuleFor(x => x.Status).NotNull();
        }
    }
}
