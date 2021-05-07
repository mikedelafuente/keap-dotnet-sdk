using Keap.Sdk.Domain;
using Keap.Sdk.Domain.Clients;
using Keap.Sdk.Domain.Common;
using Keap.Sdk.Domain.Contacts;
using System;
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

        public Contact CreateContact(Contact contact)
        {
            var responseTask = CreateContactAsync(contact).ConfigureAwait(false).GetAwaiter();
            var result = responseTask.GetResult();

            return result;
        }

        public async Task<Contact> CreateContactAsync(Contact contact)
        {
            string path = "contacts";

            ContactPutPostDto contactDto = ContactPutPostDto.MapFrom(contact);

            var responseTask = apiClient.PostAsync(path, contactDto);
            var response = await responseTask;
            var resultDto = Domain.Clients.RestHelper.ProcessResults<ContactGetDto>(response);

            var result = resultDto.MapTo();

            return result;
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
            var resultDto = Domain.Clients.RestHelper.ProcessResults<ContactGetDto>(response);

            var result = resultDto.MapTo();

            return result;
        }

        public ResultPage<Contact> GetContacts(int pageSize = 1000, string email = null, string givenName = null, string familyName = null, DateTimeOffset? lastUpdatedSince = null, DateTimeOffset? lastUpdatedUntil = null, string order = null, string orderDirection = null, bool includeLeadSourceId = false, bool includeCustomFields = false, bool includeJobTitle = true)
        {
            var responseTask = GetContactsAsync(pageSize, email, givenName, familyName, lastUpdatedSince, lastUpdatedUntil, order, orderDirection, includeLeadSourceId, includeCustomFields, includeJobTitle).ConfigureAwait(false).GetAwaiter();
            var result = responseTask.GetResult();

            return result;
        }

        public async Task<ResultPage<Contact>> GetContactsAsync(int pageSize = 1000, string email = null, string givenName = null, string familyName = null, DateTimeOffset? lastUpdatedSince = null, DateTimeOffset? lastUpdatedUntil = null, string order = null, string orderDirection = null, bool includeLeadSourceId = false, bool includeCustomFields = false, bool includeJobTitle = true)
        {
            if (pageSize <= 0 || pageSize > 1000)
            {
                pageSize = 1000;
            }
            string path = $"contacts?limit={pageSize}&email={email}&given_name={givenName}&family_name={familyName}&order={order}&order_direction={orderDirection}&since={lastUpdatedSince}&unit={lastUpdatedUntil}";

            var responseTask = apiClient.GetAsync(path);
            var response = await responseTask;
            var resultDto = Domain.Clients.RestHelper.ProcessResults<ContactListDto>(response);

            ResultPage<Contact> result = new ResultPage<Contact>();
            if (resultDto.Contacts != null && resultDto.Contacts.Count > 0)
            {
                result.NextPageToken = resultDto.GetNextPageToken(); // $"email={email}&include_partners={givenName}"

                foreach (var item in resultDto.Contacts)
                {
                    result.Items.Add(item.MapTo());
                }
            }

            return result;
        }
    }
}