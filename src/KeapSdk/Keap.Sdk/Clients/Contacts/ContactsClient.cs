using Keap.Sdk.Domain;
using Keap.Sdk.Domain.Clients;
using Keap.Sdk.Domain.Common;
using Keap.Sdk.Domain.Contacts;
using System;
using System.Threading.Tasks;
using System.Web;

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

            var result = resultDto?.MapTo();

            return result;
        }

        public bool DeleteContact(long contactId)
        {
            var responseTask = DeleteContactAsync(contactId).ConfigureAwait(false).GetAwaiter();
            var result = responseTask.GetResult();

            return result;
        }

        public async Task<bool> DeleteContactAsync(long contactId)
        {
            string path = $"contacts/{contactId}";

            var responseTask = apiClient.DeleteAsync(path);
            var response = await responseTask;

            // Perform standard error handling
            RestHelper.ProcessResultsForErrors(response);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }

            return false;
        }

        public Contact GetContact(long contactId)
        {
            var responseTask = GetContactAsync(contactId).ConfigureAwait(false).GetAwaiter();
            var result = responseTask.GetResult();

            return result;
        }

        public async Task<Contact> GetContactAsync(long contactId)
        {
            string path = $"contacts/{contactId}";

            var responseTask = apiClient.GetAsync(path);
            var response = await responseTask;
            var resultDto = Domain.Clients.RestHelper.ProcessResults<ContactGetDto>(response);

            var result = resultDto?.MapTo();

            return result;
        }

        public ResultPage<Contact> GetContacts(int pageSize = 1000, string email = null, string givenName = null, string familyName = null, DateTimeOffset? lastUpdatedSince = null, DateTimeOffset? lastUpdatedUntil = null, string order = "id", string orderDirection = "ascending", bool includeLeadSourceId = false, bool includeCustomFields = false, bool includeJobTitle = true)
        {
            var responseTask = GetContactsAsync(pageSize, email, givenName, familyName, lastUpdatedSince, lastUpdatedUntil, order, orderDirection, includeLeadSourceId, includeCustomFields, includeJobTitle).ConfigureAwait(false).GetAwaiter();
            var result = responseTask.GetResult();

            return result;
        }

        public ResultPage<Contact> GetContacts(string nextPageToken)
        {
            var responseTask = GetContactsAsync(nextPageToken).ConfigureAwait(false).GetAwaiter();
            var result = responseTask.GetResult();

            return result;
        }

        public async Task<ResultPage<Contact>> GetContactsAsync(int pageSize = 1000, string email = null, string givenName = null, string familyName = null, DateTimeOffset? lastUpdatedSince = null, DateTimeOffset? lastUpdatedUntil = null, string order = "id", string orderDirection = "ascending", bool includeLeadSourceId = false, bool includeCustomFields = false, bool includeJobTitle = true)
        {
            if (pageSize <= 0 || pageSize > 1000)
            {
                pageSize = 1000;
            }
            string queryString = $"offset=0&limit={pageSize}&email={email}&given_name={givenName}&family_name={familyName}&order={order}&order_direction={orderDirection}&since={lastUpdatedSince}&unit={lastUpdatedUntil}";

            return await GetContactsWithQueryStringAsync(queryString);
        }

        public async Task<ResultPage<Contact>> GetContactsAsync(string nextPageToken)
        {
            var qs = RestHelper.ExtractQueryStringFromPageToken(nextPageToken);
            return await GetContactsWithQueryStringAsync(qs);
        }

        private async Task<ResultPage<Contact>> GetContactsWithQueryStringAsync(string queryString)
        {
            string path = $"contacts?{queryString}";
            // Make sure that any parameters not included in the original request are appended onto
            // each subsequent request.
            var originalParameters = HttpUtility.ParseQueryString(queryString);

            var responseTask = apiClient.GetAsync(path);
            var response = await responseTask;
            var resultDto = RestHelper.ProcessResults<ContactListDto>(response);

            ResultPage<Contact> result = new ResultPage<Contact>();
            if (resultDto.Contacts != null && resultDto.Contacts.Count > 0)
            {
                result.NextPageToken = resultDto.GetNextPageToken(originalParameters);

                foreach (var item in resultDto.Contacts)
                {
                    result.Items.Add(item.MapTo());
                }
            }

            return result;
        }
    }
}