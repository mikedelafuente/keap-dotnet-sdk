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
    public class UserInfoTests : E2E.Common.SdkE2ETests
    {
        [Scenario("Get current user info")]
        [Given("any valid token")] // TODO: Determine how to feed in a list of different tokens as input
        [When("a call to get the current user is made")]
        [Then("a object is returned containing the current user information")]
        [TestMethod]
        public void Get_current_user_info()
        {
            // Arrange
            var client = Tests.Common.ClientHelper.GetSdkClient(PersonaType.Admin);

            // Act
            var actual = client.UserInfo.GetCurrentUser();

            // Assert
            actual.Should().NotBeNull();
            actual.Sub.Should().NotBeNullOrWhiteSpace();
            actual.GlobalUserId.Should().BeGreaterThan(0);
            actual.InfusionsoftId.Should().Contain("@", "The InfusionsoftId should be the login ID which is an email");
        }
    }
}