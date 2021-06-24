using FluentValidation;
using FluentValidationPOC.Shared.Models;
using FluentValidationPOC.Shared.Services;
using Microsoft.Extensions.Localization;

namespace FluentValidationPOC.Shared.Validators.ArticleValidators
{
    public class LocalizedAsyncArticleValidator : AbstractValidator<Article>
    {
        /*
        * Adding Localization and Async validation
        * 
        * Note! The ConsoleApp is not configured to use this validator. Will only work in the Blazor example 
        */

        private readonly ISkumArticleService _skumArticleService;

        public LocalizedAsyncArticleValidator(IStringLocalizer<Article> localizer, ISkumArticleService skumArticleService)
        {
            _skumArticleService = skumArticleService;

            RuleFor(x => x.Name).NotEmpty().When(x => x.Status == ArticleStatus.ReadyForWeb)
                .WithMessage(x => localizer["Name required when status is ReadyForWeb", ArticleStatus.ReadyForWeb]);

            RuleFor(x => x.ArticleNumber)
                .NotEmpty().When(x => x.Status != ArticleStatus.Discontinued)
                .MustBeValidArticleNumberFormat()

                // Check to see that the number is not already taken
                .MustAsync(async (articleNumber, cancellation) =>
                {
                    bool isAvailable = await _skumArticleService.IsArticleNumberAvailableAsync(articleNumber);
                    return isAvailable;
                }).WithMessage($"Article number is already taken");

            RuleFor(x => x.Status).NotNull();
        }
    }
}
