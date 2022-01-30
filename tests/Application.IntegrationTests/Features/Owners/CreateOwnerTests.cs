
using FluentAssertions;
using NUnit.Framework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WeeloApi.Application.Features.Owners.Commands.Create;
using WeeloApi.Domain.Entities;

namespace Application.IntegrationTests.Features.Owners
{
    using static Testing;
    using ValidationException = WeeloApi.Application.Common.Exceptions.ValidationException;

    public class CreateOwnerTests : TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreateOwnerRequest();

            ValidationContext context = new ValidationContext(command);

            FluentActions.Invoking(() =>
                Validator.ValidateObject(command, context)).Should().Throw<System.ComponentModel.DataAnnotations.ValidationException>();
        }

        [Test]
        public async Task ShouldCreateOwner()
        {
            var userId = await RunAsDefaultUserAsync();

            var command = new CreateOwnerRequest
            {
                Name = "JUAN CARLOS CARDONA",
                Address = "CRA 9 No 5 - 27",
                Birthday = DateTime.Parse("2000-12-01")
            };

            ValidationContext context = new ValidationContext(command);
            Validator.ValidateObject(command, context);
            var itemId = await SendAsync(command);

            var item = await FindAsync<Owner>(itemId?.Data.IdOwner);

            item.Should().NotBeNull();
            item.Name.Should().Be(command.Name);
            item.Address.Should().Be(command.Address);
            item.Birthday.Should().Be(command.Birthday);
            item.CreatedBy.Should().Be(userId);
            item.Created.Should().BeCloseTo(DateTime.Now, 10000);
            item.LastModifiedBy.Should().BeNull();
            item.LastModified.Should().BeNull();
        }
    }
}
