using Keap.Sdk.Authorization;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Keap.Tests.E2E.Common
{
    public static class SeleniumHelper
    {
        /// <summary>
        /// Runs through the Selenium code flow using admin credentials
        /// </summary>
        /// <param name="authorizationUri"></param>
        /// <returns></returns>
        public static string GetAdminCodeFromSelenium(string authorizationUri)
        {
            var config = Tests.Common.ConfigurationHelper.GetConfiguration(System.Reflection.Assembly.GetAssembly(typeof(SdkE2ETests)));
            var keapAppName = config["TestSettings:AppName"];
            var username = config["TestSettings:AdminUsername"];
            var password = config["TestSettings:AdminPassword"];

            return RunAuthorizationCodeFlow(authorizationUri, keapAppName, username, password);
        }

        /// <summary>
        /// Returns the value of a given query string parameter name
        /// </summary>
        /// <param name="url">The url to parse</param>
        /// <param name="name">The parameter name to get the value for</param>
        /// <returns></returns>
        public static string GetQueryStringValue(string url, string name)
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
        internal static string RunAuthorizationCodeFlow(string authorizationUri, string keapAppName, string username, string password)
        {
            string authorizationCode;

            IWebDriver driver;
            using (driver = new ChromeDriver())
            {
                driver.Url = authorizationUri;

                var originalRedirectUri = GetQueryStringValue(authorizationUri, "redirect_uri");
                if (string.IsNullOrWhiteSpace(originalRedirectUri))
                {
                    throw new ArgumentException(nameof(originalRedirectUri));
                }

                driver.Wait(10).Until(d => d.Url.StartsWith("https://signin.infusionsoft.com/", StringComparison.InvariantCultureIgnoreCase));

                driver.DataQaFillInField("username", username);
                driver.DataQaFillInField("password", password);
                driver.DataQaClickButton("login");

                driver.Wait(5).Until(d => d.Url.StartsWith("https://accounts.infusionsoft.com", StringComparison.InvariantCultureIgnoreCase));

                //Select the app name
                var dropDown = driver.Wait().Until(d => d.FindElement(By.Name("application")));
                SelectElement selectElement = new SelectElement(dropDown);
                selectElement.SelectByText(keapAppName);

                driver.Wait().Until(d => d.FindElement(By.Name("allow"))).Click();
                driver.Wait(30).Until(d => d.Url.StartsWith(originalRedirectUri, StringComparison.InvariantCultureIgnoreCase));

                authorizationCode = GetQueryStringValue(driver.Url, "code");
            }

            return authorizationCode;
        }

        /// <summary>
        /// Redirects to accounts.infusionsoft.com
        /// </summary>
        /// <param name="keapAppName"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="driver"></param>
        internal static void RunLoginToAccountCentral(string username, string password, IWebDriver driver)
        {
            driver.Url = "https://signin.infusionsoft.com/login?service=https%3A%2F%2Faccounts.infusionsoft.com";

            driver.Wait(10).Until(d => d.Url.StartsWith("https://signin.infusionsoft.com/", StringComparison.InvariantCultureIgnoreCase));

            driver.DataQaFillInField("username", username);
            driver.DataQaFillInField("password", password);
            driver.DataQaClickButton("login");

            driver.Wait(5).Until(d => d.Url.StartsWith("https://accounts.infusionsoft.com", StringComparison.InvariantCultureIgnoreCase));
        }
    }
}