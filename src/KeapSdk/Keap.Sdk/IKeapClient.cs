using Keap.Sdk.Domain;

namespace Keap.Sdk
{
    public interface IKeapClient
    {
        /// <summary>
        /// Methods for interacting with the current app's Account Profile
        /// </summary>
        IAccountInfoClient AccountInfo { get; }

        /// <summary>
        /// Methods for getting Keap compatible country and province codes
        /// </summary>
        ILocaleClient Locale { get; }
    }
}