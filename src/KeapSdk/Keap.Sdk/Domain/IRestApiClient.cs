using System.Threading.Tasks;

namespace Keap.Sdk.Domain
{
    public interface IRestApiClient
    {
        AccessTokenCredentials AccessTokenCredentials { get; set; }

        Task<ServerResponse> DeleteAsync(string path);

        Task<ServerResponse> GetAsync(string path);

        Task<ServerResponse> PatchAsync(string path, object valueToSerialize);

        Task<ServerResponse> PostAsync(string path, object valueToSerialize);

        Task<ServerResponse> PutAsync(string path, object valueToSerialize);
    }
}