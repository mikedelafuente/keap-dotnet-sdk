using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Keap.Sdk.Domain.UserInfo
{
    /// <summary>
    /// The current authenticated end-user, as outlined by the OpenID Connect specification.
    /// </summary>
    public class CurrentUser
    {
        /// <summary>
        /// The primary email for the user
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Last name or surname
        /// </summary>
        [JsonPropertyName("family_name")]
        public string FamilyName { get; set; }

        /// <summary>
        /// First name or forename
        /// </summary>
        [JsonPropertyName("given_name")]
        public string GivenName { get; set; }

        /// <summary>
        /// Global User ID. Independent of the app. Used for multi-tenancy.
        /// </summary>
        [JsonPropertyName("global_user_id")]
        public long GlobalUserId { get; set; }

        /// <summary>
        /// The ID used to login which is always an email address
        /// </summary>
        [JsonPropertyName("infusionsoft_id")]
        public string InfusionsoftId { get; set; }

        /// <summary>
        /// Middle name
        /// </summary>
        [JsonPropertyName("middle_name")]
        public object MiddleName { get; set; }

        /// <summary>
        /// Preferred name
        /// </summary>
        [JsonPropertyName("preferred_name")]
        public object PreferredName { get; set; }

        // TODO: Determine what 'sub' is for the UserInfo object
        /// <summary>
        /// The User ID for the current app
        /// </summary>
        [JsonPropertyName("sub")]
        public string Sub { get; set; }
    }
}