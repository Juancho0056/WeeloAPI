
using FluentAssertions;
using NUnit.Framework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WeeloApi.Application.Common.Exceptions;
using WeeloApi.Application.Features.Owners.Commands.Create;
using WeeloApi.Application.Features.Propertys.Commands.Create;
using WeeloApi.Domain.Entities;

namespace Application.IntegrationTests.Features.Propertys
{
    using static Testing;
    using ValidationException = WeeloApi.Application.Common.Exceptions.ValidationException;

    public class CreatePropertyTests : TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreatePropertyRequest();

            ValidationContext context = new ValidationContext(command);

            FluentActions.Invoking(() =>
                Validator.ValidateObject(command, context)).Should().Throw<System.ComponentModel.DataAnnotations.ValidationException>();
        }

        [Test]
        public async Task ShouldCreateProperty()
        {
            var userId = await RunAsDefaultUserAsync();
            var commandOwner = new CreateOwnerRequest
            {
                Name = "JUAN CARLOS CARDONA",
                Address = "CRA 9 No 5 - 27",
                Birthday = DateTime.Parse("2000-12-01")
            };
            var owner = await SendAsync(commandOwner);
            var command = new CreatePropertyRequest
            {
                Name = "TORREON",
                Address = "CRA 9 No 5 - 27",
                Price = 1000,
                IdOwner = owner.Data.IdOwner,
                Year = 2021
            };

            ValidationContext context = new ValidationContext(command);
            Validator.ValidateObject(command, context);
            var itemId = await SendAsync(command);

            var item = await FindAsync<Property>(itemId?.Data.IdProperty);

            item.Should().NotBeNull();
            item.Name.Should().Be(command.Name);
            item.Address.Should().Be(command.Address);
            item.Price.Should().Be(command.Price);
            item.CreatedBy.Should().Be(userId);
            item.Created.Should().BeCloseTo(DateTime.Now, 10000);
            item.LastModifiedBy.Should().BeNull();
            item.LastModified.Should().BeNull();
        }

        [Test]
        public async Task ShouldCreateOwnerless()
        {
            var userId = await RunAsDefaultUserAsync();

            var command = new CreatePropertyRequest
            {
                Name = "TORREON",
                Address = "CRA 9 No 5 - 27",
                Price = 1000,
                IdOwner = 99,
                Year = 2021
            };

            ValidationContext context = new ValidationContext(command);
            Validator.ValidateObject(command, context);
            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
   
        }
    }
}
