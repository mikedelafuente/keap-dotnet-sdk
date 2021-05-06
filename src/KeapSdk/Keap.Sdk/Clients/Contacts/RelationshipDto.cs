using Keap.Sdk.Domain.Contacts;
using System;
using System.Text.Json.Serialization;

namespace Keap.Sdk.Clients.Contacts
{
    internal class RelationshipDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("linked_contact_id")]
        public string LinkedContactId { get; set; }

        [JsonPropertyName("relationship_type_id")]
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