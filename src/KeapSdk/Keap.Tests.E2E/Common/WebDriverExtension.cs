using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Keap.Tests.E2E.Common
{
    public static class WebDriverExtension
    {
        /// <summary>
        /// Clicks a button based on the data-qa name
        /// </summary>
        /// <param name="driver">The WebDriver</param>
        /// <param name="fieldName">The data-qa name</param>
        /// <param name="secondsToWait">Default 1 second. If set to 0, then it is 500ms.</param>
        public static void DataQaClickButton(this IWebDriver driver, string fieldName, int secondsToWait = 1)
        {
            var foundField = driver.Wait(secondsToWait).Until(d => d.DataQaFindByValue(fieldName));
            foundField.Should().NotBeNull();
            foundField.Click();
        }

        /// <summary>
        /// Fills in a field with the given value
        /// </summary>
        /// <param name="driver">The WebDriver</param>
        /// <param name="fieldName">The data-qa name</param>
        /// <param name="value">The value to populate the field with</param>
        /// <param name="secondsToWait">Default 1 second. If set to 0, then it is 500ms.</param>
        public static void DataQaFillInField(this IWebDriver driver, string fieldName, string value, int secondsToWait = 1)
        {
            var foundField = driver.Wait(secondsToWait).Until(d => d.DataQaFindByValue(fieldName));
            foundField.Should().NotBeNull();
            foundField.SendKeys(value);
        }

        /// <summary>
        /// Will default to 500ms if a valud of 0 or less is passed in for seconds. Maximum is 300 seconds.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="seconds">If not value set for seconds or it is 0 or less, default to 500ms. Maximum is 300 seconds.</param>
        /// <returns></returns>
        public static WebDriverWait Wait(this IWebDriver driver, int seconds = 0)
        {
            if (seconds > 300)
            {
                seconds = 300;
            }

            if (seconds <= 0)
            {
                return new WebDriverWait(driver, new TimeSpan(0, 0, 0, 500));
            }
            return new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
        }

        /// <summary>
        /// Uses XPath to find a field by the data-qa attribute
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="dataQaAttributeValue">The data-qa name</param>
        /// <returns></returns>
        private static IWebElement DataQaFindByValue(this IWebDriver driver, string dataQaAttributeValue)
        {
            return driver.FindElement(By.XPath($"//*[@data-qa='{dataQaAttributeValue}']"));
        }
    }
}