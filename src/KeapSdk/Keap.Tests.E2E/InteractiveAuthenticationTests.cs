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
            var actual = Sdk.Authentication.GetClientUsingOAuth2(integrationName, clientId, clientSecret, "https://localhost:44379/seleniumHandler", GetCodeViaSelenium);

            // Assert
            actual.Should().NotBeNull("valid credentials were passed in.");
        }

        private string GetCodeViaSelenium(string authorizationUri)
        {
            string code;

            IWebDriver driver;
            using (driver = new ChromeDriver())
            {
                driver.Url = authorizationUri;

                var originalRedirectUri = GetQueryStringValue(authorizationUri, "redirect_uri");
                originalRedirectUri.Should().NotBeNullOrWhiteSpace();

                driver.Wait(10).Until(d => d.Url.StartsWith("https://signin.infusionsoft.com/", StringComparison.InvariantCultureIgnoreCase));

                var keapAppName = _config["TestSettings:AppName"];
                var badUsername = _config["TestSettings:AdminUsername"];
                var badPassword = _config["TestSettings:AdminPassword"];

                driver.DataQaFillInField("username", badUsername);
                driver.DataQaFillInField("password", badPassword);
                driver.DataQaClickButton("login");

                driver.Wait(5).Until(d => d.Url.StartsWith("https://accounts.infusionsoft.com", StringComparison.InvariantCultureIgnoreCase));

                //Select the app name
                var dropDown = driver.Wait().Until(d => d.FindElement(By.Name("application")));
                SelectElement selectElement = new SelectElement(dropDown);
                selectElement.SelectByText(keapAppName);

                driver.Wait().Until(d => d.FindElement(By.Name("allow"))).Click();
                driver.Wait(30).Until(d => d.Url.StartsWith(originalRedirectUri, StringComparison.InvariantCultureIgnoreCase));

                code = GetQueryStringValue(driver.Url, "code");
                code.Should().NotBeNullOrWhiteSpace("a valid code should have been returned");
            }

            return code;
        }
    }
}