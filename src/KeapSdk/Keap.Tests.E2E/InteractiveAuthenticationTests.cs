using FluentAssertions;
using Keap.Sdk.Domain;
using Keap.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Keap.Tests.E2E.Common;
using System.Web;

namespace Keap.Tests.E2E
{
    [TestClass]
    public class InteractiveAuthenticationTests : E2E.Common.E2ETests
    {
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

            // Act
            var actual = Sdk.Authentication.GetClientUsingOAuth2(integrationName, clientId, clientSecret, "https://localhost/seleniumHandler", GetCodeViaSelenium, PersistCredentialsToSecretFile);

            // Assert
            actual.Should().NotBeNull("valid credentials were passed in.");
        }
    }
}