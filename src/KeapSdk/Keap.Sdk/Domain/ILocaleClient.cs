using System.Collections.Generic;
using System.Threading.Tasks;

namespace Keap.Sdk.Domain
{
    public interface ILocaleClient
    {
        /// <summary>
        /// Gets a Keap compatible dictionary of country codes and their English names
        /// </summary>
        /// <returns>A dictionary of Country Codes (key) and Names (value)</returns>
        /// <exception cref="Keap.Sdk.Exceptions.KeapException"></exception>
        Dictionary<string, string> GetCountries();

        /// <summary>
        /// Gets a Keap compatible dictionary of country codes and their English names
        /// </summary>
        /// <returns>A dictionary of Country Codes (key) and Names (value)</returns>
        /// <exception cref="Keap.Sdk.Exceptions.KeapException"></exception>
        Task<Dictionary<string, string>> GetCountriesAsync();

        /// <summary>
        /// Gets a Keap compatible dictionary of province codes and their English names
        /// </summary>
        /// <param name="countryCode">
        /// The "key" value from the dictionary of Country Code <see cref="GetCountries"/>
        /// </param>
        /// <returns>A dictionary of Province Codes (key) and Names (value)</returns>
        /// <exception cref="Keap.Sdk.Exceptions.KeapException"></exception>
        Dictionary<string, string> GetProvinces(string countryCode);

        /// <summary>
        /// Gets a Keap compatible dictionary of province codes and their English names
        /// </summary>
        /// <param name="countryCode">
        /// The "key" value from the dictionary of Country Code <see cref="GetCountries"/>
        /// </param>
        /// <returns>A dictionary of Province Codes (key) and Names (value)</returns>
        /// <exception cref="Keap.Sdk.Exceptions.KeapException"></exception>
        Task<Dictionary<string, string>> GetProvincesAsync(string countryCode);
    }
}