using Newtonsoft.Json;

namespace Keap.Sdk.Clients.Users
{
    internal class InviteUserDto
    {
        [JsonProperty("admin")]
        public bool Admin { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("given_name")]
        public string GivenName { get; set; }

        [JsonProperty("partner")]
        public bool Partner { get; set; }
    }
}