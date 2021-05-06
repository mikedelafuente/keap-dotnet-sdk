using Keap.Sdk.Domain.Contacts;
using Newtonsoft.Json;

namespace Keap.Sdk.Clients.Contacts
{
    internal class RelationshipDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("linked_contact_id")]
        public string LinkedContactId { get; set; }

        [JsonProperty("relationship_type_id")]
        public string RelationshipTypeId { get; set; }

        internal Relationship MapTo()
        {
            Relationship r = new();
            r.Id = this.Id;
            r.LinkedContactId = this.LinkedContactId;
            r.RelationshipTypeId = this.RelationshipTypeId;
            return r;
        }
    }
}