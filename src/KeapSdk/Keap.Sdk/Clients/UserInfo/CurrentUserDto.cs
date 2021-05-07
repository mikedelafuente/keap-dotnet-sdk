using Keap.Sdk.Domain.UserInfo;
using Newtonsoft.Json;

namespace Keap.Sdk.Clients.UserInfo
{
    internal class CurrentUserDto
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("family_name")]
        public string FamilyName { get; set; }

        [JsonProperty("given_name")]
        public string GivenName { get; set; }

        [JsonProperty("global_user_id")]
        public long GlobalUserId { get; set; }

        [JsonProperty("infusionsoft_id")]
        public string InfusionsoftId { get; set; }

        [JsonProperty("middle_name")]
        public object MiddleName { get; set; }

        [JsonProperty("preferred_name")]
        public object PreferredName { get; set; }

        [JsonProperty("sub")]
        public string Sub { get; set; }

        internal CurrentUser MapTo()
        {
            CurrentUser result = new CurrentUser()
            {
                Email = this.Email,
                FamilyName = this.FamilyName,
                GivenName = this.GivenName,
                GlobalUserId = this.GlobalUserId,
                InfusionsoftId = this.InfusionsoftId,
                MiddleName = this.MiddleName,
                PreferredName = this.PreferredName,
                Sub = this.Sub
            };

            return result;
        }
    }
}