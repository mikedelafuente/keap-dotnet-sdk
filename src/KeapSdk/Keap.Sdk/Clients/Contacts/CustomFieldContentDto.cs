using Keap.Sdk.Domain.Contacts;
using System;

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