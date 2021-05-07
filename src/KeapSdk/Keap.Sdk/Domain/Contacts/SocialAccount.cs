using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Keap.Sdk.Domain.Contacts
{
    public enum SocialAccountType
    {
        SOCIAL_ACCOUNT_TYPE_UNSPECIFIED,
        FACEBOOK,
        LINKED_IN,
        TWITTER,
        INSTAGRAM,
        SNAPCHAT,
        YOUTUBE,
        PINTEREST
    }

    public class SocialAccount
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public SocialAccountType Type { get; set; }
    }
}