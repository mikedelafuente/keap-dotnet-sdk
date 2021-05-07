using Keap.Sdk.Domain.Contacts;
using System.Threading.Tasks;

namespace Keap.Sdk.Domain
{
    public interface IContactsClient
    {
        /// <summary>
        /// Creates a new contact as the authenticated user. The contact must contain at least one
        /// item in email addresses or phone numbers. If region is specified then country code is
        /// required. You may opt-in or mark a Contact as Marketable by populating the OptInReason.
        /// </summary>
        /// <param name="contact">The contact to create.</param>
        /// <returns>The contact with a populated ID.</returns>
        Contact CreateContact(Contact contact);

        /// <summary>
        /// Creates a new contact as the authenticated user. The contact must contain at least one
        /// item in email addresses or phone numbers. If region is specified then country code is
        /// required. You may opt-in or mark a Contact as Marketable by populating the OptInReason.
        /// </summary>
        /// <param name="contact">The contact to create.</param>
        /// <returns>The contact with a populated ID.</returns>
        Task<Contact> CreateContactAsync(Contact contact);

        /// <summary>
        /// Retrieves a single contact
        /// </summary>
        /// <param name="contactId">The ID of the contact</param>
        /// <returns>A contact if it exists, otherwise returns null.</returns>
        Contact GetContact(int contactId);

        /// <summary>
        /// Retrieves a single contact
        /// </summary>
        /// <param name="contactId">The ID of the contact</param>
        /// <returns>A contact if it exists, otherwise returns null.</returns>
        Task<Contact> GetContactAsync(int contactId);
    }
}