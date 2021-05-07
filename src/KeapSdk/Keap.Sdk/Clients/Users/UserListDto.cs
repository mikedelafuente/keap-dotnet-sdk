using Newtonsoft.Json;
using System.Collections.Generic;

namespace Keap.Sdk.Clients.Users
{
    internal class UserListDto : Common.KeapListDto
    {
        [JsonProperty("users")]
        public List<UserDto> Users { get; set; } = new List<UserDto>();
    }
}