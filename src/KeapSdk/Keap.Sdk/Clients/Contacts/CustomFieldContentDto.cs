using Keap.Sdk.Domain.Contacts;
using System;

namespace Keap.Sdk.Clients.Contacts
{
    internal class CustomFieldContentDto
    {
        internal static CustomFieldContentDto MapFrom(CustomFieldContent source)
        {
            if (source == null)
            {
                return null;
            }

            CustomFieldContentDto r = new();
            return r;
        }

        internal CustomFieldContent MapTo()
        {
            CustomFieldContent r = new();
            return r;
        }
    }
}