using FluentAssertions;
using Keap.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            throw new NotImplementedException("Clear out users!");
        }
    }
}