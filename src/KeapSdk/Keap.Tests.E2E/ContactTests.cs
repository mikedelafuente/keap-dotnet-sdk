using FluentAssertions;
using Keap.Tests.E2E.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keap.Tests.E2E
{
    [TestClass]
    public class ContactTests
    {
        [Scenario("Get contact by a valid ID should return a contact")]
        [Given("any token and a valid contact ID")]
        [When("a call to get a contact by ID is made")]
        [Then("a populated contact is returned")]
        [TestMethod]
        public void Get_contact_by_a_valid_id_should_return_a_contact()
        {
            // Arrange
            var client = ClientHelper.GetSdkClient(PersonaType.Admin);
            var validId = 2;
            // Act
            var actual = client.Contacts.GetContact(validId);

            // Assert
            actual.Should().NotBeNull();
            actual.Id.Should().Be(validId);
        }
    }
}