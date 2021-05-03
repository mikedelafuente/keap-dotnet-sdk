using FluentAssertions;
using Keap.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Keap.Tests.E2E
{
    [TestClass]
    public class LocaleTests : E2E.Common.SdkE2ETests
    {
        [Scenario("List Countries should return all countries")]
        [Given("any valid token")] // TODO: Determine how to feed in a list of different tokens as input
        [When("a call to get a list of countries")]
        [Then("a dictionary of countries containing the key {USA} and at least {180} items")]
        [TestMethod]
        public void Get_the_account_profile_for_the_current_app()
        {
            // Arrange
            var client = Tests.Common.ClientHelper.GetSdkClient(PersonaType.Admin);

            // Act
            var actual = client.Locale.GetCountries();

            // Assert
            actual.Should().NotBeNull();
            actual.Keys.Should().Contain("USA");
            actual.Keys.Count.Should().BeGreaterOrEqualTo(249);
        }

        [Scenario("List Provinces for a valid country should return a list")]
        [Given("any valid token and a country code of {USA}")] // TODO: Determine how to feed in a list of different tokens as input
        [When("a call to get a list of provinces")]
        [Then("a dictionary of provinces with at least {50} items is returned")]
        [TestMethod]
        public void Update_the_account_profile_for_the_current_app()
        {
            // Arrange
            var client = Tests.Common.ClientHelper.GetSdkClient(PersonaType.Admin);

            // Act
            var actual = client.Locale.GetProvinces("USA");

            // Assert
            actual.Should().NotBeNull();
            actual.Count.Should().BeGreaterOrEqualTo(50);
        }
    }
}