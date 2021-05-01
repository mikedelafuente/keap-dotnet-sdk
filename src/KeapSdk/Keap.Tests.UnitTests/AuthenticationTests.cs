using FluentAssertions;
using Keap.Sdk.Domain;
using Keap.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Keap.Tests.UnitTests
{
    [TestClass]
    public class AuthenticationTests
    {
        [Scenario("Get a client via OAuth2 by passing in client ID and secret")]
        [Given("a valid Keap developer client ID and secret")]
        [When("a call to the OAuth2 endpoint is made and validated by the user")]
        [Then("a client object is returned to the integrator")]
        [TestMethod]
        public void Get_a_client_via_OAuth2_by_passing_in_client_ID_and_secret()
        {
            // Arrange
            string clientId = "validClientId";
            string clientSecret = "validClientSecret";
            string baseUrl = "https://api.infusionsoft.com/crm/rest/v1";

            // Act
            var actual = Sdk.Authentication.GetClientUsingOAuth2("Keap SDK Unit Tests", clientId, clientSecret, baseUrl);

            // Assert
            actual.Should().NotBeNull("valid credentials were passed in.");
        }

        [Scenario("Get a client via an existing access token")]
        [Given("a valid Keap developer client ID and secret")]
        [When("a call to the OAuth2 endpoint is made and validated by the user")]
        [Then("a client object is returned to the integrator")]
        [TestMethod]
        public void Get_a_client_via_an_existing_access_token()
        {
            // Arrange
            string integrationName = "Keap SDK Unit Tests";
            string clientId = "validClientId";
            string clientSecret = "validClientSecret";
            string baseUrl = "https://api.infusionsoft.com/crm/rest/v1";
            string accessToken = "wix7RGXw4kSVEYszjUcGsG1Jcw4m";
            string refreshToken = "Ax5PHruqOIFg56WeV3wiAPJPGshuAaeW";
            int expiresIn = 86399;
            DateTime createTime = new DateTime(2021, 4, 30, 16, 37, 0);

            AccessTokenCredentials accessTokenCredentials = new AccessTokenCredentials(integrationName, clientId, clientSecret, baseUrl, accessToken, refreshToken, expiresIn, createTime);

            // Act
            var actual = Sdk.Authentication.GetClientUsingAccessToken(accessTokenCredentials);

            // Assert
            actual.Should().NotBeNull("valid credentials were passed in.");
        }
    }
}