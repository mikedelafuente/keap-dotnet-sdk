using Newtonsoft.Json;

namespace Keap.Sdk.Domain.Contacts
{
    public class Relationship
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("linked_contact_id")]
        public string LinkedContactId { get; set; }

        [JsonProperty("relationship_type_id")]
        public string RelationshipTypeId { get; set; }
    }
}