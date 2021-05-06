using System.Text.Json.Serialization;

namespace Keap.Sdk.Clients.Users
{
    internal class UserListDto : Common.KeapListDto
    {
        [JsonPropertyName("users")]
        public UserDto[] Users { get; set; }
    }
}