using Keap.Sdk.Domain.Contacts;

namespace Keap.Sdk.Clients.Contacts
{
    internal class CustomFieldContentDto
    {
        internal CustomFieldContent MapTo()
        {
            CustomFieldContent r = new();
            return r;
        }
    }
}