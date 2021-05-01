using FluentAssertions;
using Keap.Sdk.Domain;
using Keap.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Keap.Tests.E2E
{
    [TestClass]
    public class InteractiveAuthenticationTests
    {
        [Scenario("Get a client via OAuth2 by passing in client ID and secret")]
        [Given("a valid Keap developer client ID and secret")]
        [When("a call to the OAuth2 endpoint is made and validated by the user")]
        [Then("a client object is returned to the integrator")]
        [TestMethod]
        public void Get_a_client_via_OAuth2_by_passing_in_client_ID_and_secret()
        {
            // Arrange
            var config = Common.ConfigurationHelper.GetConfiguration();
            string clientId = config["TestSettings:ClientId"];
            string clientSecret = config["TestSettings:ClientSecret"];
            var integrationName = config["TestSettings:IntegrationName"];
            // Act

            var actual = Sdk.Authentication.GetClientUsingOAuth2(integrationName, clientId, clientSecret, "https://localhost:44379/responseHandler", BrowserDelegate);

            // Assert
            actual.Should().NotBeNull("valid credentials were passed in.");
        }

        private AccessTokenCredentials BrowserDelegate(string browserRedirectUri)
        {
            // Start an HTTPS listener

            // Open a browser and redirect
            throw new NotImplementedException(browserRedirectUri);
        }
    }
}