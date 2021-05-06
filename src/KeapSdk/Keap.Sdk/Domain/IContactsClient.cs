using Keap.Sdk.Domain.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keap.Sdk.Domain
{
    public interface IContactsClient
    {
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