using System.Threading.Tasks;
using BibleBrainSharp.Models;

namespace BibleBrainSharp
{
    public partial class BibleBrainClient
    {
        public async Task<AlphabetsResult?> GetAlphabets()
        {
            var request = new HttpRequest(ApiEndpoints.Alphabets);
            var response = await httpClient.ExecuteAsync<AlphabetsResult>(request).ConfigureAwait(false);
            return response;
        }

        public async Task<AlphabetInfoResult?> GetAlphabet(string alphabetId)
        {
            var request = new HttpRequest(ApiEndpoints.GetAlphabet(alphabetId));
            var response = await httpClient.ExecuteAsync<AlphabetInfoResult>(request).ConfigureAwait(false);
            return response;
        }
    }
}
