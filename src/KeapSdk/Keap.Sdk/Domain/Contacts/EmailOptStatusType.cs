namespace Keap.Sdk.Domain.Contacts
{
    public enum EmailOptStatusType
    {
        UNENGAGED_MARKETABLE,
        SINGLE_OPT_IN,
        DOUBLE_OPT_IN,
        CONFIRMED,
        UNENGAGED_NON_MARKETABLE,
        NON_MARKETABLE,
        LOCKDOWN,
        BOUNCE,
        HARD_BOUNCE,
        MANUAL,
        ADMIN,
        SYSTEM,
        LIST_UNSUBSCRIBE,
        FEEDBACK,
        SPAM,
        INVALID,
        DEACTIVATED
    }
}