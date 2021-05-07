using FluentAssertions;
using Keap.Tests.E2E.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Keap.Tests.E2E
{
    [TestClass]
    public class AccountProfileTests : E2E.Common.SdkE2ETests
    {
        [Scenario("Get the account profile for the current app")]
        [Given("an admin token")]
        [When("a call to get the account profile is made")]
        [Then("an account profile is returned for the access token's app")]
        [TestMethod]
        public void Get_the_account_profile_for_the_current_app()
        {
            // Arrange
            var client = ClientHelper.GetSdkClient(PersonaType.Admin);

            // Act
            var actual = client.AccountInfo.GetAccountProfile();

            // Assert
            actual.Should().NotBeNull();
            actual.Name.Should().NotBeNullOrWhiteSpace();
            actual.Address.Should().NotBeNull();
        }

        [Scenario("Update the account profile for the current app")]
        [Given("an admin token")]
        [When("a call to update the account profile is made")]
        [Then("the updated account profile is returned")]
        [TestMethod]
        public void Update_the_account_profile_for_the_current_app()
        {
            // Arrange
            var client = ClientHelper.GetSdkClient(PersonaType.Admin);
            var accountProfile = client.AccountInfo.GetAccountProfile();

            // Act
            var updatedAccountProfile = accountProfile.Clone();
            updatedAccountProfile.Address = Common.FakeData.GetAddress();
            updatedAccountProfile.Address.CountryCode = "USA";
            var actual = client.AccountInfo.UpdateAccountProfile(updatedAccountProfile);

            // Assert
            actual.Should().NotBeNull();
            actual.Name.Should().NotBeNullOrWhiteSpace();
            actual.Address.Should().NotBeNull();
        }
    }
}