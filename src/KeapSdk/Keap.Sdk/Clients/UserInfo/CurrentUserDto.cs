using Keap.Sdk.Domain.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Keap.Sdk.Clients.UserInfo
{
    internal class CurrentUserDto
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("family_name")]
        public string FamilyName { get; set; }

        [JsonPropertyName("given_name")]
        public string GivenName { get; set; }

        [JsonPropertyName("global_user_id")]
        public long GlobalUserId { get; set; }

        [JsonPropertyName("infusionsoft_id")]
        public string InfusionsoftId { get; set; }

        [JsonPropertyName("middle_name")]
        public object MiddleName { get; set; }

        [JsonPropertyName("preferred_name")]
        public object PreferredName { get; set; }

        [JsonPropertyName("sub")]
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