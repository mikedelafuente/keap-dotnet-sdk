using Keap.Sdk.Domain.Common;
using Keap.Sdk.Domain.Contacts;
using System;
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

        /// <summary>
        /// Retrieves a list of all contacts
        /// </summary>
        /// <param name="pageSize">Sets a total of items to return. Limit of 1000.</param>
        /// <param name="email">Optional email address to query on</param>
        /// <param name="givenName">Optional first name or forename to query on</param>
        /// <param name="familyName">Optional last name or surname to query on</param>
        /// <param name="lastUpdatedSince">Date to start searching from on LastUpdated</param>
        /// <param name="lastUpdatedUntil">Date to search to on LastUpdated</param>
        /// <param name="order">
        /// Attribute to order items by. Id, date_created, name, firstName, email
        /// </param>
        /// <param name="orderDirection">
        /// How to order the data i.e. ascending (A-Z) or descending (Z-A)
        /// </param>
        /// <param name="includeLeadSourceId">
        /// Will populate the Lead Source ID. Not returning this could improve performance.
        /// </param>
        /// <param name="includeCustomFields">
        /// Will populate the custom fields. Not returning this could improve performance.
        /// </param>
        /// <param name="includeJobTitle">
        /// Will populate the job title. Not returning this could improve performance.
        /// </param>
        /// <returns>Returns a list of contacts</returns>
        public ResultPage<Contact> GetContacts(int pageSize = 1000, string email = null, string givenName = null, string familyName = null, DateTimeOffset? lastUpdatedSince = null, DateTimeOffset? lastUpdatedUntil = null, string order = null, string orderDirection = null, bool includeLeadSourceId = false, bool includeCustomFields = false, bool includeJobTitle = true);

        /// <summary>
        /// Retrieves a list of all contacts using the next page token. If there is not a next page,
        /// no token will be returned
        /// </summary>
        /// <param name="nextPageToken">
        /// The next page token is returned with every contact list unless there are no results.
        /// </param>
        /// <returns></returns>
        public ResultPage<Contact> GetContacts(string nextPageToken);

        /// <summary>
        /// Retrieves a list of all contacts
        /// </summary>
        /// <param name="pageSize">Sets a total of items to return. Limit of 1000.</param>
        /// <param name="email">Optional email address to query on</param>
        /// <param name="givenName">Optional first name or forename to query on</param>
        /// <param name="familyName">Optional last name or surname to query on</param>
        /// <param name="lastUpdatedSince">Date to start searching from on LastUpdated</param>
        /// <param name="lastUpdatedUntil">Date to search to on LastUpdated</param>
        /// <param name="order">
        /// Attribute to order items by. Id, date_created, name, firstName, email
        /// </param>
        /// <param name="orderDirection">
        /// How to order the data i.e. ascending (A-Z) or descending (Z-A)
        /// </param>
        /// <param name="includeLeadSourceId">
        /// Will populate the Lead Source ID. Not returning this could improve performance.
        /// </param>
        /// <param name="includeCustomFields">
        /// Will populate the custom fields. Not returning this could improve performance.
        /// </param>
        /// <param name="includeJobTitle">
        /// Will populate the job title. Not returning this could improve performance.
        /// </param>
        /// <returns>Returns a list of contacts</returns>
        public Task<ResultPage<Contact>> GetContactsAsync(int pageSize = 1000, string email = null, string givenName = null, string familyName = null, DateTimeOffset? lastUpdatedSince = null, DateTimeOffset? lastUpdatedUntil = null, string order = null, string orderDirection = null, bool includeLeadSourceId = false, bool includeCustomFields = false, bool includeJobTitle = true);

        /// <summary>
        /// Retrieves a list of all contacts using the next page token. If there is not a next page,
        /// no token will be returned
        /// </summary>
        /// <param name="nextPageToken">
        /// The next page token is returned with every contact list unless there are no results.
        /// </param>
        /// <returns></returns>
        public Task<ResultPage<Contact>> GetContactsAsync(string nextPageToken);
    }
}