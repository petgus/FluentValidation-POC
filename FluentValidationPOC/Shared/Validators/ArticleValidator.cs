using FluentValidation;
using FluentValidationPOC.Shared.Services;
using Microsoft.Extensions.Localization;

namespace FluentValidationPOC.Shared.Validators
{
    public class ArticleValidator : AbstractValidator<Article>
    {


        public ArticleValidator()
        {
            RuleFor(x => x.Name).NotEmpty().When(x => x.Status == ArticleStatus.ReadyForWeb); // Must have name when in status ready for web
            RuleFor(x => x.ArticleNumber).NotEmpty().When(x => x.Status != ArticleStatus.Discontinued);
            RuleFor(x => x.Status).NotNull();
        }

        //public ArticleValidator()
        //{
        //    RuleFor(x => x.Name).NotEmpty().When(x => x.Status == ArticleStatus.ReadyForWeb)
        //        .WithMessage($"Hey stupid! Name can not be empty when article status is: {ArticleStatus.ReadyForWeb}");

        //    RuleFor(x => x.ArticleNumber).Matches(@"^\d{4}-\d{3}-\d{4}$").NotEmpty().When(x => x.Status != ArticleStatus.Discontinued);

        //    RuleFor(x => x.Status).NotNull();
        //}




        // Demo this using MudBlazor        
        //private readonly ISkumArticleService _skumArticleService;

        //public ArticleValidator(IStringLocalizer<Article> localizer, ISkumArticleService skumArticleService)
        //{
        //    _skumArticleService = skumArticleService;

        //    RuleFor(x => x.Name).NotEmpty().When(x => x.Status == ArticleStatus.ReadyForWeb)
        //        .WithMessage(x => string.Format(localizer["Name required when status is ReadyForWeb"], ArticleStatus.ReadyForWeb));

        //    RuleFor(x => x.ArticleNumber)
        //        .Matches(@"^\d{4}-\d{3}-\d{4}$")
        //        .NotEmpty().When(x => x.Status != ArticleStatus.Discontinued)
        //        .MustAsync(async (articleNumber, cancellation) => {
        //            bool isAvailable = await _skumArticleService.IsArticleNumberAvailableAsync(articleNumber);
        //            return isAvailable;
        //        }).WithMessage($"Article number is already taken");

        //    RuleFor(x => x.Status).NotNull();
        //}
    }
}
