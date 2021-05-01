using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Keap.Tests.E2E.Common
{
    public static class WebDriverExtension
    {
        public static void DataQaClickButton(this IWebDriver driver, string fieldName, int secondsToWait = 1)
        {
            var foundField = driver.Wait(secondsToWait).Until(d => d.DataQaFindByValue(fieldName));
            foundField.Should().NotBeNull();
            foundField.Click();
        }

        public static void DataQaFillInField(this IWebDriver driver, string fieldName, string value, int secondsToWait = 1)
        {
            var foundField = driver.Wait(secondsToWait).Until(d => d.DataQaFindByValue(fieldName));
            foundField.Should().NotBeNull();
            foundField.SendKeys(value);
        }

        /// <summary>
        /// Will default to 500ms if a valud of 0 or less is passed in for seconds
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static WebDriverWait Wait(this IWebDriver driver, int seconds = 0)
        {
            if (seconds <= 0)
            {
                return new WebDriverWait(driver, new TimeSpan(0, 0, 0, 500));
            }
            return new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
        }

        private static IWebElement DataQaFindByValue(this IWebDriver driver, string dataQaAttributeValue)
        {
            return driver.FindElement(By.XPath($"//*[@data-qa='{dataQaAttributeValue}']"));
        }
    }
}