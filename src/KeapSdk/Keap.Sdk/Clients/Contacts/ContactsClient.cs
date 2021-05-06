using Keap.Sdk.Domain;
using Keap.Sdk.Domain.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keap.Sdk.Clients.Contacts
{
    public class ContactsClient : IContactsClient
    {
        private readonly IRestApiClient apiClient;

        public ContactsClient(Domain.IRestApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public Contact GetContact(int contactId)
        {
            var responseTask = GetContactAsync(contactId).ConfigureAwait(false).GetAwaiter();
            var result = responseTask.GetResult();

            return result;
        }

        public async Task<Contact> GetContactAsync(int contactId)
        {
            string path = $"contacts/{contactId}";

            var responseTask = apiClient.GetAsync(path);
            var response = await responseTask;
            var resultDto = Domain.Clients.RestHelper.ProcessResults<ContactDto>(response);

            var result = resultDto.MapTo();

            return result;
        }
    }
}