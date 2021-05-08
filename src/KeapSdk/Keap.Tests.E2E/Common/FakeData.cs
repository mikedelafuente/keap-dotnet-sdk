using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keap.Tests.E2E.Common
{
    public static class FakeData
    {
        public static Sdk.Domain.Common.Address GetAddress()
        {
            var address = new Bogus.Faker<Sdk.Domain.Common.Address>()
                 .RuleFor(a => a.CountryCode, f => f.Address.CountryCode(Bogus.DataSets.Iso3166Format.Alpha3))
                 .RuleFor(a => a.Field, f => f.PickRandom<Sdk.Domain.Common.AddressType>())
                 .RuleFor(a => a.Line1, f => f.Address.StreetAddress())
                 .RuleFor(a => a.Line2, f => f.Address.SecondaryAddress())
                 .RuleFor(a => a.CountryCode, f => f.Address.CountryCode())
                 .RuleFor(a => a.Locality, f => f.Address.City())
                 .RuleFor(a => a.PostalCode, f => f.Address.ZipCode("#####"))
                 .RuleFor(a => a.Region, f => f.Address.State())
                 .RuleFor(a => a.ZipCode, f => f.Address.ZipCode("#####"))
                 .RuleFor(a => a.ZipFour, f => f.Address.ZipCode("####"));

            return address.Generate();
        }

        public static string GetEmailAddress()
        {
            return Guid.NewGuid().ToString() + "@weekendproject.app";
        }

        public static string GetFirstName()
        {
            return new Bogus.DataSets.Name().FirstName();
        }

        public static string GetLastName()
        {
            return new Bogus.DataSets.Name().LastName();
        }

        /// <summary>
        /// Creates a Contact with just a first, last and email address
        /// </summary>
        /// <returns></returns>
        public static Sdk.Domain.Contacts.Contact GetSimpleContact()
        {
            var result = new Sdk.Domain.Contacts.Contact();

            result.FamilyName = GetLastName();
            result.GivenName = GetFirstName();
            var emailAddress = new Sdk.Domain.Contacts.EmailAddress();
            emailAddress.Email = GetEmailAddress();
            emailAddress.Field = Sdk.Domain.Contacts.EmailFieldType.EMAIL1;

            result.EmailAddresses.Add(emailAddress);

            return result;
        }
    }
}