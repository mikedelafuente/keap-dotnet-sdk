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
        [Scenario("Create a contact with a name and email address")]
        [Given("any token and an empty contact model with a name and valid email address")]
        [When("a call to create a contact is made")]
        [Then("a contact is returned with the name, email address and an ID greater than 0")]
        [TestMethod]
        public void Create_a_contact_with_a_name_and_email_address()
        {
            // Arrange
            var client = ClientHelper.GetSdkClient(PersonaType.Admin);
            var expected = new Sdk.Domain.Contacts.Contact();
            var nameFaker = new Bogus.DataSets.Name();
            var internetFaker = new Bogus.DataSets.Internet();

            expected.FamilyName = nameFaker.LastName();
            expected.GivenName = nameFaker.FirstName();
            var emailAddress = new Sdk.Domain.Contacts.EmailAddress();
            emailAddress.Email = Guid.NewGuid().ToString() + "@weekendproject.app";
            emailAddress.Field = Sdk.Domain.Contacts.EmailFieldType.EMAIL1;

            expected.EmailAddresses.Add(emailAddress);

            // Act
            var actual = client.Contacts.CreateContact(expected);

            // Assert
            actual.Should().NotBeNull();
            actual.Id.Should().BeGreaterThan(0);
        }

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

        [Scenario("Get the initial contacts page with default values")]
        [Given("any token")]
        [When("a call to get a list of contacts by ID is made")]
        [Then("a populated contact is returned")]
        [TestMethod]
        public void Get_the_initial_contacts_page_with_default_values()
        {
            // Arrange
            var client = ClientHelper.GetSdkClient(PersonaType.Admin);

            // Act
            var actual = client.Contacts.GetContacts();

            // Assert
            actual.Should().NotBeNull();
            actual.Items.Count.Should().BeGreaterThan(0);
        }
    }
}