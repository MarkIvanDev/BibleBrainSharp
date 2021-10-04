using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BibleBrainSharp.Models;

namespace BibleBrainSharp
{
    public partial class BibleBrainClient
    {
        public async Task<IList<Country>> GetCountries(string l10n = default, bool? include_languages = default)
        {
            var countries = new List<Country>();
            var request = new HttpRequest(ApiEndpoints.Countries);
            request.Query.AddOptionalParameter(nameof(l10n), l10n);
            request.Query.AddOptionalParameter(nameof(include_languages), include_languages);

            CountriesResult response;
            do
            {
                response = await httpClient.ExecuteAsync<CountriesResult>(request);
                if (response is null) break;

                countries.AddRange(response.Data);
                request.Query.Set("page", (response.Meta.Pagination.CurrentPage + 1).ToString());
            } while (response.Meta.Pagination.CurrentPage < response.Meta.Pagination.TotalPages);
            
            return countries;
        }

        public async Task<CountryInfoResult> GetCountry(string countryId)
        {
            var request = new HttpRequest(ApiEndpoints.GetCountry(countryId));
            var response = await httpClient.ExecuteAsync<CountryInfoResult>(request);
            return response;
        }
    }
}
