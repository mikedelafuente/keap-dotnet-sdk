﻿using FluentAssertions;
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
    }
}