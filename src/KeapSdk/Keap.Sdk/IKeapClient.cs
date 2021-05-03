using Keap.Sdk.Domain;

namespace Keap.Sdk
{
    public interface IKeapClient
    {
        IAccountInfoClient AccountInfo { get; }
    }
}