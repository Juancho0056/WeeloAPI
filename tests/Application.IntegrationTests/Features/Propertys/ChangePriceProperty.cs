using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeloApi.Application.Features.Owners.Commands.Create;
using WeeloApi.Application.Features.Propertys.Commands.Create;
using WeeloApi.Application.Features.Propertys.Commands.Update;
using WeeloApi.Domain.Entities;

namespace Application.IntegrationTests.Features.Propertys
{
    using static Testing;
    public class ChangePriceProperty : TestBase
    {
        [Test]
        public async Task ShouldUpdatePropertyPrice()
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


            var updateCommand = new ChangePriceRequest
            {
                IdProperty = item.Data.IdProperty,
                Price = 5000
            };
            await SendAsync(updateCommand);
            var property = await FindAsync<Property>(item.Data.IdProperty);

            property.IdProperty.Should().Be(updateCommand.IdProperty);
            property.Price.Should().Be(updateCommand.Price);
            property.LastModifiedBy.Should().NotBeNull();
            property.LastModifiedBy.Should().Be(userId);
            property.LastModified.Should().NotBeNull();
            property.LastModified.Should().BeCloseTo(DateTime.Now, 10000);
        }
    }
}
