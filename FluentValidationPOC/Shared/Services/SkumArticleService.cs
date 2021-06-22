using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentValidationPOC.Shared.Services
{
    public class SkumArticleService : ISkumArticleService
    {
        private readonly List<string> _takenNumbers = new List<string> { "1000-104-0075" };

        public async Task<bool> IsArticleNumberAvailableAsync(string articleNumber)
        {
            return !_takenNumbers.Contains(articleNumber);

        }
    }
}
