using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keap.Sdk.Clients.Contacts
{
    internal class ContactListDto : Common.KeapListDto
    {
        [JsonProperty("contacts")]
        internal List<ContactGetDto> Contacts { get; set; }
    }
}