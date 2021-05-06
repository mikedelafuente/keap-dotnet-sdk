using Newtonsoft.Json;

namespace Keap.Sdk.Clients.Users
{
    internal class UserListDto : Common.KeapListDto
    {
        [JsonProperty("users")]
        public UserDto[] Users { get; set; }
    }
}