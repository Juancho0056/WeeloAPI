using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using WeeloApi.Application.Common.Exceptions;
using WeeloApi.Application.Features.Owners.Commands.Create;
using WeeloApi.Application.Features.Owners.Commands.Update;
using WeeloApi.Domain.Entities;

namespace Application.IntegrationTests.Features.Owners
{
    using static Testing;

    public class UpdateOwnerTests : TestBase
    {
        [Test]
        public void ShouldRequireValidIdOwner()
        {
            var command = new UpdateOwnerRequest
            {
                IdOwner = 99,
                Name = "New Name"
            };

            FluentActions.Invoking(() =>
            SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldUpdateOwner()
        {
            var userId = await RunAsDefaultUserAsync();

            var itemId = await SendAsync(new CreateOwnerRequest
            {
                Name = "JUAN CARLOS CARDONA",
                Address = "CRA 9 No 5 - 27",
                Birthday = DateTime.Parse("2000-12-01")
            });

            var command = new UpdateOwnerRequest
            {
                IdOwner = itemId.Data.IdOwner,
                Address = "CRA 9 No 5 - 29",
            };

            await SendAsync(command);

            var item = await FindAsync<Owner>(itemId.Data.IdOwner);

            item.IdOwner.Should().Be(command.IdOwner);
            item.Address.Should().Be(command.Address);
            item.LastModifiedBy.Should().NotBeNull();
            item.LastModifiedBy.Should().Be(userId);
            item.LastModified.Should().NotBeNull();
            item.LastModified.Should().BeCloseTo(DateTime.Now, 10000);
        }
    }
}
