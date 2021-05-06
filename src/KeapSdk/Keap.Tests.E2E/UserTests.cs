using FluentAssertions;
using Keap.Tests.Common;
using Keap.Tests.E2E.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keap.Tests.E2E
{
    [TestClass]
    public class UserTests : E2E.Common.SdkE2ETests
    {
        [Scenario("Get a list of users")]
        [Given("any valid token")] // TODO: Determine how to feed in a list of different tokens as input
        [When("the first call is made to get a list of users")]
        [Then("a object is returned containing a list of up to 1000 users")]
        [TestMethod]
        public void Get_a_list_of_users()
        {
            // Arrange
            var client = Tests.Common.ClientHelper.GetSdkClient(PersonaType.Admin);

            // Act
            var actual = client.Users.GetUsers();

            // Assert
            actual.Should().NotBeNull();
            actual.Items.Count.Should().BeGreaterOrEqualTo(1);
        }

        [Scenario("Get next page of users")]
        [Given("a result page for users with a next page token")] // TODO: Determine how to feed in a list of different tokens as input
        [When("a call is made to get a list of users with the next page token")]
        [Then("an object is returned that has another set of users")]
        [TestMethod]
        public void Get_next_page_of_users()
        {
            // Arrange
            var client = Tests.Common.ClientHelper.GetSdkClient(PersonaType.Admin);
            var original = client.Users.GetUsers(pageSize: 1);

            original.Should().NotBeNull();
            original.NextPageToken.Should().NotBeNullOrWhiteSpace();

            // Act
            var actual = client.Users.GetUsers(original.NextPageToken);

            // Assert
            actual.Should().NotBeNull();
            actual.Items.Count.Should().BeGreaterOrEqualTo(1);
        }

        [Scenario("Get the email signature for a user")]
        [Given("a valid user id and access token")] // TODO: Determine how to feed in a list of different tokens as input
        [When("a request to get the email signature is made")]
        [Then("the snippet of HTML for that user's email signature is returned")]
        [TestMethod]
        public void Get_the_email_signature_for_a_user()
        {
            // Arrange
            var client = Tests.Common.ClientHelper.GetSdkClient(PersonaType.Admin);

            // Act
            var actual = client.Users.GetUserEmailSignature(1); // This user should always exist

            // Assert
            actual.Should().NotBeNull();
            actual.HtmlSignature.Should().NotBeNullOrWhiteSpace();
        }

        [Scenario("Get the email signature for an invalid user")]
        [Given("a invalid user id and a valid access token")] // TODO: Determine how to feed in a list of different tokens as input
        [When("a request to get the email signature is made")]
        [Then("null is returned")]
        [TestMethod]
        public void Get_the_email_signature_for_an_invalid_user()
        {
            // Arrange
            var client = Tests.Common.ClientHelper.GetSdkClient(PersonaType.Admin);

            // Act
            var actual = client.Users.GetUserEmailSignature(99999); // This user should never exist

            // Assert
            actual.Should().BeNull();
        }

        [Scenario("Invite a user to the app")]
        [Given("a valid access token, given name and email")] // TODO: Determine how to feed in a list of different tokens as input
        [When("a user is invited to the app")]
        [Then("a user record with an ID greater than 0 and a status of Invited is returned")]
        [TestMethod]
        public void Invite_a_user_to_the_app()
        {
            // Arrange
            CleanupInvitedUsers();

            var client = Tests.Common.ClientHelper.GetSdkClient(PersonaType.Admin);
            var expectedEmail = Guid.NewGuid().ToString() + "@weekendproject.app";
            var expectedGivenName = "E2E Tests";
            var expectedIsAdmin = true;
            var expectedIsPartner = false;

            // Act
            var actual = client.Users.InviteUser(expectedEmail, expectedGivenName, expectedIsAdmin, expectedIsPartner); // This user should never exist

            // Assert
            actual.Should().NotBeNull();
            actual.Id.Should().BeGreaterThan(0);
            actual.GivenName.Should().Be(expectedGivenName);
            actual.EmailAddress.Should().Be(expectedEmail);
            actual.InfusionsoftId.Should().Be(expectedEmail);
            actual.Partner.Should().Be(expectedIsPartner);

            // TODO: How do I know if they are an admin?
        }

        [Scenario("Invite a user to the app")]
        [Given("a valid access token, given name and email")] // TODO: Determine how to feed in a list of different tokens as input
        [When("a user is invited to the app")]
        [Then("a user record with an ID greater than 0 and a status of Invited is returned")]
        [TestMethod]
        public void Invite_too_many_users_to_the_app()
        {
            // Arrange
            CleanupInvitedUsers();

            var client = Tests.Common.ClientHelper.GetSdkClient(PersonaType.Admin);
            for (int i = 0; i < 2; i++)
            {
                client.Users.InviteUser(Guid.NewGuid().ToString() + "@weekendproject.app", "E2E Tests_TMU", false, false);
            }

            var expectedEmail = Guid.NewGuid().ToString() + "@weekendproject.app";
            var expectedGivenName = "E2E Tests";
            var expectedIsAdmin = true;
            var expectedIsPartner = false;

            Keap.Sdk.Exceptions.KeapLicenseException expectedException = null;
            // Act
            try
            {
                var actual = client.Users.InviteUser(expectedEmail, expectedGivenName, expectedIsAdmin, expectedIsPartner); // This user should never exist
            }
            catch (Keap.Sdk.Exceptions.KeapLicenseException ex)
            {
                expectedException = ex;
            }

            // Assert
            expectedException.Should().NotBeNull("too many users should have been invited triggering a license expception");
        }

        private void CleanupInvitedUsers()
        {
            List<long> invitedUserIds = new List<long>();
            var client = Tests.Common.ClientHelper.GetSdkClient(PersonaType.Admin);
            var users = client.Users.GetUsers(true, true, 1000);
            foreach (var user in users.Items)
            {
                if (user.Status == Sdk.Domain.Users.UserStatus.Invited)
                {
                    invitedUserIds.Add(user.Id);
                }
            }

            // Only run if there are inactive users, for now
            if (invitedUserIds.Count > 0)
            {
                IWebDriver driver;
                using (driver = new ChromeDriver())
                {
                    var keapAppName = _config["TestSettings:AppName"];
                    var username = _config["TestSettings:AdminUsername"];
                    var password = _config["TestSettings:AdminPassword"];

                    E2E.Common.SeleniumHelper.RunLoginToAccountCentral(username, password, driver);

                    foreach (var userId in invitedUserIds)
                    {
                        driver.Url = $"https://{keapAppName}/Contact/manageUser.jsp?view=edit&ID={userId}";

                        var cancelInvitationButton = driver.Wait(5).Until(d => d.FindElement(By.Name("Cancel_Invitation")));
                        cancelInvitationButton.Click();
                        //Cancel_Invitation
                        driver.Wait(5).Until(d => d.Url.Contains("Reports/searchTemplate.jsp?reportClass=SetupUser", StringComparison.InvariantCultureIgnoreCase));
                    }
                }
            }
        }
    }
}