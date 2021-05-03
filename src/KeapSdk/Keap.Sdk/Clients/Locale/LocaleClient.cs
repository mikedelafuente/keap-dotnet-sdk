using Keap.Sdk.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Keap.Sdk.Clients.Locale
{
    internal class LocaleClient : ILocaleClient
    {
        private readonly IRestApiClient apiClient;

        public LocaleClient(IRestApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public Dictionary<string, string> GetCountries()
        {
            var responseTask = GetCountriesAsync().ConfigureAwait(false).GetAwaiter();
            var result = responseTask.GetResult();

            return result;
        }

        public async Task<Dictionary<string, string>> GetCountriesAsync()
        {
            // TODO: Cache results
            string path = "locales/countries";

            var responseTask = apiClient.GetAsync(path);
            var response = await responseTask;
            var resultDto = Domain.Clients.RestHelper.ProcessResults<CountriesDto>(response);

            var result = resultDto.Countries;

            return result;
        }

        public Dictionary<string, string> GetProvinces(string countryCode)
        {
            var responseTask = GetProvincesAsync(countryCode).ConfigureAwait(false).GetAwaiter();
            var result = responseTask.GetResult();

            return result;
        }

        public async Task<Dictionary<string, string>> GetProvincesAsync(string countryCode)
        {
            // All Keap Country Codes are upper case and the REST API is case sensitive
            countryCode = countryCode.ToUpper();

            // TODO: Cache results
            string path = $"locales/countries/{countryCode}/provinces";

            var responseTask = apiClient.GetAsync(path);
            var response = await responseTask;
            var resultDto = Domain.Clients.RestHelper.ProcessResults<ProvincesDto>(response);

            var result = resultDto.Provinces;

            return result;
        }
    }
}