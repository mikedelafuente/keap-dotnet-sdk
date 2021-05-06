using System.Text.Json.Serialization;

namespace Keap.Sdk.Domain.Contacts
{
    public class Relationship
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("linked_contact_id")]
        public string LinkedContactId { get; set; }

        [JsonPropertyName("relationship_type_id")]
        public string RelationshipTypeId { get; set; }
    }
}