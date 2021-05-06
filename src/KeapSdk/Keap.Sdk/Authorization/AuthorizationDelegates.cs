using Keap.Sdk.Domain;

namespace Keap.Sdk.Authorization
{
    /// <summary>
    /// As the developer, you are responsible to redirect the user's browser to a URL that will then
    /// return the code for use by the SDK.
    /// </summary>
    /// <param name="authorizationUri">The URI to redirect a user's browser to</param>
    /// <returns>The 'Code' found in the redirect uri once the user has approved the integration.</returns>
    public delegate string OAuth2BrowserHandler(string authorizationUri);

    /// <summary>
    /// If access credentials are updated, this delegate will allow you to persist those credentials
    /// to long term storage.
    /// </summary>
    /// <param name="accessTokenCredentials">The update credentials that you should persist</param>
    public delegate void PersistAccessTokenCredentialsHandler(AccessTokenCredentials accessTokenCredentials);
}