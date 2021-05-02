using FluentAssertions;
using Keap.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Keap.Tests.E2E
{
    [TestClass]
    public class AccountProfileTests : E2E.Common.E2ETests
    {
        [Scenario("Get a client using an existing access token")]
        [Given("a valid Keap developer client ID and secret")]
        [When("a call to the OAuth2 endpoint is made and validated by the user")]
        [Then("a client object is returned to the integrator")]
        [TestMethod]
        public void Get_a_client_using_an_existing_access_token()
        {
            // Arrange
            var accessToken = base.GetCredentialsFromSecretFile();

            // Act
            var client = Sdk.Authentication.GetClientUsingAccessToken(accessToken, PersistCredentialsToSecretFile);
            var actual = client.AccountInfo.GetAccountProfile();

            // Assert
            actual.Should().NotBeNull();
            actual.Name.Should().NotBeNullOrWhiteSpace();
            actual.Address.Should().NotBeNull();
        }
    }
}