using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentValidationPOC.Shared.Services
{
    public class SkumArticleService : ISkumArticleService
    {
        private readonly List<string> _takenNumbers = new List<string> { TakenArticleNumber.Value };

        public async Task<bool> IsArticleNumberAvailableAsync(string articleNumber)
        {
            return !_takenNumbers.Contains(articleNumber);

        }
    }

    public static class TakenArticleNumber
    {
        public static string Value => "1000-104-0075";
    }
}
