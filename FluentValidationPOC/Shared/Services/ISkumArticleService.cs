using System.Threading.Tasks;

namespace FluentValidationPOC.Shared.Services
{
    public interface ISkumArticleService
    {
         Task<bool> IsArticleNumberAvailableAsync(string articleNumber);
    }
}
