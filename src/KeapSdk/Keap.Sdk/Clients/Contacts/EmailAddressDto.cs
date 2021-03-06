using Keap.Sdk.Domain.Contacts;
using Newtonsoft.Json;
using System;

namespace Keap.Sdk.Clients.Contacts
{
    internal class EmailAddressGetDto
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("field")]
        public string Field { get; set; }

        internal static EmailAddressGetDto MapFrom(EmailAddress source)
        {
            if (source == null)
            {
                return null;
            }
            EmailAddressGetDto r = new();
            r.Email = source.Email;
            r.Field = source.Field.ToString();
            return r;
        }

        internal EmailAddress MapTo()
        {
            EmailAddress r = new();
            r.Email = this.Email;
            // r.EmailOptStatus = Enum.Parse<EmailOptStatusType>(this.EmailOptStatus);
            r.Field = Enum.Parse<EmailFieldType>(this.Field);
            // r.IsOptIn = this.IsOptIn; r.OptInReason = this.OptInReason;
            return r;
        }
    }

    internal class EmailAddressPutPostDto
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        //[JsonProperty("email_opt_status")]
        //public string EmailOptStatus { get; set; }

        [JsonProperty("field")]
        public string Field { get; set; }

        //[JsonProperty("is_opt_in")]
        //public bool IsOptIn { get; set; }

        //// TODO: Does clearing the opt-in reason set IsOptIn to false?
        //[JsonProperty("opt_in_reason")]
        //public string OptInReason { get; set; }

        internal static EmailAddressPutPostDto MapFrom(EmailAddress source)
        {
            if (source == null)
            {
                return null;
            }
            EmailAddressPutPostDto r = new();
            r.Email = source.Email;
            // r.EmailOptStatus = source.EmailOptStatus.ToString();
            r.Field = source.Field.ToString();
            // r.IsOptIn = source.IsOptIn;
            //r.OptInReason = source.OptInReason;
            return r;
        }
    }
}