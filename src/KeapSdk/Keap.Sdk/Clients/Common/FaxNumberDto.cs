using Keap.Sdk.Domain.Common;
using System;

namespace Keap.Sdk.Clients.Common
{
    // TODO: Add comments to properties and class
    internal class FaxNumberDto : TelephoneDto
    {
        internal static FaxNumberDto MapFrom(FaxNumber source)
        {
            if (source == null)
            {
                return null;
            }

            var result = new FaxNumberDto
            {
                Extension = source.Extension,
                Field = source.Field.ToString(),
                Number = source.Number,
                Type = source.Type
            };

            return result;
        }

        internal FaxNumber MapTo()
        {
            var result = new FaxNumber
            {
                Extension = this.Extension,
                Field = Enum.Parse<FaxFieldType>(this.Field),
                Number = this.Number,
                Type = this.Type
            };

            return result;
        }
    }
}