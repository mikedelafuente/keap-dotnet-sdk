using FluentAssertions;
using Keap.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Keap.Tests.E2E
{
    [TestClass]
    public class AccountProfileTests : E2E.Common.SdkE2ETests
    {
        [Scenario("Get the account profile for the current app")]
        [Given("an admin token")]
        [When("a call to the OAuth2 endpoint is made and validated by the user")]
        [Then("a client object is returned to the integrator")]
        [TestMethod]
        public void Get_a_client_using_an_existing_access_token()
        {
            // Arrange
            var client = Tests.Common.ClientHelper.GetSdkClient(PersonaType.Admin);

            // Act
            var actual = client.AccountInfo.GetAccountProfile();

            // Assert
            actual.Should().NotBeNull();
            actual.Name.Should().NotBeNullOrWhiteSpace();
            actual.Address.Should().NotBeNull();
        }
    }
}