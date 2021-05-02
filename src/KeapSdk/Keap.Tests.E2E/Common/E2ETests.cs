using FluentAssertions;
using Keap.Sdk.Domain;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text.Json;
using System.Web;

namespace Keap.Tests.E2E.Common
{
    public class E2ETests
    {
        public string _accessTokenFile = "token.secret";
        public IConfigurationRoot _config;

        public E2ETests()
        {
            _config = ConfigurationHelper.GetConfiguration();
        }

        /// <summary>
        /// Returns the value of a given query string parameter name
        /// </summary>
        /// <param name="url">The url to parse</param>
        /// <param name="name">The parameter name to get the value for</param>
        /// <returns></returns>
        protected static string GetQueryStringValue(string url, string name)
        {
            var uri = new Uri(url);
            var parts = HttpUtility.ParseQueryString(uri.Query);
            return parts[name];
        }

        /// <summary>
        /// Runs Selenium, using the chrome driver
        /// </summary>
        /// <param name="authorizationUri"></param>
        /// <returns></returns>
        protected string GetCodeViaSelenium(string authorizationUri)
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

        protected AccessTokenCredentials GetCredentialsFromSecretFile()
        {
            var fullPath = System.IO.Path.GetFullPath("./" + _accessTokenFile);
            if (System.IO.File.Exists(fullPath))
            {
                var json = System.IO.File.ReadAllText(fullPath);

                JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var credentials = JsonSerializer.Deserialize<AccessTokenCredentials>(json, options);
                return credentials;
            }

            return null;
        }

        protected void PersistCredentialsToSecretFile(AccessTokenCredentials accessTokenCredentials)
        {
            var fullPath = System.IO.Path.GetFullPath("./" + _accessTokenFile);

            JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true, WriteIndented = true };
            var json = JsonSerializer.Serialize(accessTokenCredentials, options);

            System.IO.File.WriteAllText(fullPath, json);
        }
    }
}