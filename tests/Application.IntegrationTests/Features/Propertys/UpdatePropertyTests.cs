using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using WeeloApi.Application.Common.Exceptions;
using WeeloApi.Application.Features.Owners.Commands.Create;
using WeeloApi.Application.Features.Propertys.Commands.Create;
using WeeloApi.Application.Features.Propertys.Commands.Update;
using WeeloApi.Domain.Entities;

namespace Application.IntegrationTests.Features.Propertys
{
    using static Testing;

    public class UpdatePropertyTests : TestBase
    {
        [Test]
        public void ShouldRequireValidIdProperty()
        {
            var command = new UpdatePropertyRequest
            {
                IdProperty = 99,
                Name = "New Name"
            };

            FluentActions.Invoking(() =>
            SendAsync(command)).Should().Throw<NotFoundException>();
        }
        [Test]
        public async Task ShouldRequireValidIdOwner()
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

            var item = await SendAsync(command);

            var updateCommand = new UpdatePropertyRequest
            {
                IdProperty = item.Data.IdProperty,
                IdOwner = 99
            };
            FluentActions.Invoking(() =>
            SendAsync(updateCommand)).Should().Throw<NotFoundException>();
        }
        [Test]
        public async Task ShouldUpdateProperty()
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

            var item = await SendAsync(command);

            var commandOwner2 = new CreateOwnerRequest
            {
                Name = "DANIELA",
                Address = "CRA 9 No 5 - 21",
                Birthday = DateTime.Parse("2006-12-01")
            };
            var owner2 = await SendAsync(commandOwner2);

            var updateCommand = new UpdatePropertyRequest
            {
                IdProperty = item.Data.IdProperty,
                IdOwner = owner2.Data.IdOwner
            };
            await SendAsync(updateCommand);
            var property = await FindAsync<Property>(item.Data.IdProperty);

            property.IdProperty.Should().Be(updateCommand.IdProperty);
            property.IdOwner.Should().Be(updateCommand.IdOwner);
            property.LastModifiedBy.Should().NotBeNull();
            property.LastModifiedBy.Should().Be(userId);
            property.LastModified.Should().NotBeNull();
            property.LastModified.Should().BeCloseTo(DateTime.Now, 10000);
        }

       
    }
}
