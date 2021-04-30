namespace Keap.Sdk.Domain
{
    /// <summary>
    /// 
    /// </summary>
    internal class RestClient : IRestClient
    {
        public RestClient(AccessToken token)
        {
            if (token == null)
            {
                throw new Common.KeapArgumentException(nameof(token));
            }

            AccessToken = token;
        }

        public AccessToken AccessToken { get; set; }
    }

    public interface IRestClient
    {
        AccessToken AccessToken { get; }

    }
}
