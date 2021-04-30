using Keap.Sdk.Domain.Clients;
using System.Net.Http;
using System.Threading.Tasks;

namespace Keap.Sdk.Domain
{
    public interface IApiClient
    {
        Task<ServerResponse> DeleteAsync(string path);
        Task<ServerResponse> GetAsync(string path);
        Task<ServerResponse> PatchAsync(string path, object valueToSerialize);
        Task<ServerResponse> PostAsync(string path, object valueToSerialize);
        Task<ServerResponse> PutAsync(string path, object valueToSerialize);

    }
}