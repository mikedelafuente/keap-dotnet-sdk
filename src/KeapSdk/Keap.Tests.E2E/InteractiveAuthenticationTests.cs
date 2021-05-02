using FluentAssertions;
using Keap.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Keap.Tests.E2E
{
    [TestClass]
    public class InteractiveAuthenticationTests : E2E.Common.SdkE2ETests
    {
        [Scenario("Get a client using an existing access token")]
        [Given("a valid Keap developer client ID and secret")]
        [When("a call to the OAuth2 endpoint is made and validated by the user")]
        [Then("a client object is returned to the integrator")]
        [TestMethod]
        public void Get_a_client_using_an_existing_access_token()
        {
            // Arrange
            var accessToken = ClientHelper.GetCredentialsFromSecretFile(PersonaType.Admin);

            // Act
            var actual = Sdk.Authentication.GetClientUsingAccessToken(accessToken, ClientHelper.PersistCredentialsToSecretFile);

            // Assert
            actual.Should().NotBeNull("valid credentials were passed in.");
        }

        [Scenario("Get a client via OAuth2 by passing in client ID and secret")]
        [Given("a valid Keap developer client ID and secret")]
        [When("a call to the OAuth2 endpoint is made and validated by the user")]
        [Then("a client object is returned to the integrator")]
        [TestMethod]
        public void Get_a_client_via_OAuth2_by_passing_in_client_ID_and_secret()
        {
            // Arrange
            string clientId = _config["TestSettings:ClientId"];
            string clientSecret = _config["TestSettings:ClientSecret"];
            var integrationName = _config["TestSettings:IntegrationName"];
            string integratorUniqueIdentifier = PersonaType.Admin.ToString();

            // Act
            var actual = Sdk.Authentication.GetClientUsingOAuth2(integrationName, integratorUniqueIdentifier, clientId, clientSecret, "https://localhost/seleniumHandler", Tests.Common.ClientHelper.PersistCredentialsToSecretFile, Common.SeleniumHelper.GetAdminCodeFromSelenium);

            // Assert
            actual.Should().NotBeNull("valid credentials were passed in.");
        }
    }
}