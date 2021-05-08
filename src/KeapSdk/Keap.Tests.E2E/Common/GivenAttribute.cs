namespace Keap.Tests.E2E.Common
{
    public class GivenAttribute : TestDescriptionAttribute
    {
        public GivenAttribute(string condition) : base(condition)
        {
        }

        public override string ToString()
        {
            return "GIVEN " + Description;
        }
    }
}