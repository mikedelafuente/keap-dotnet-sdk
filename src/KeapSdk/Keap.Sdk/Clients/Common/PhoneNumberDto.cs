using Keap.Sdk.Domain.Common;
using System;

namespace Keap.Sdk.Clients.Common
{
    internal class PhoneNumberDto : TelephoneDto
    {
        internal static PhoneNumberDto MapFrom(PhoneNumber source)
        {
            if (source == null)
            {
                return null;
            }

            var result = new PhoneNumberDto
            {
                Extension = source.Extension,
                Field = source.Field.ToString(),
                Number = source.Number,
                Type = source.Type
            };

            return result;
        }

        internal PhoneNumber MapTo()
        {
            var result = new PhoneNumber
            {
                Extension = this.Extension,
                Field = Enum.Parse<PhoneFieldType>(this.Field),
                Number = this.Number,
                Type = this.Type
            };

            return result;
        }
    }
}