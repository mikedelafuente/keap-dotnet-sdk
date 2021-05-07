using Keap.Sdk.Domain;
using Keap.Sdk.Domain.Contacts;
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
    }
}