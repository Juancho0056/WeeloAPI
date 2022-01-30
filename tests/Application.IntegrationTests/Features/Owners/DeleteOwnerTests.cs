using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeloApi.Application.Common.Exceptions;
using WeeloApi.Application.Features.Owners.Commands.Create;
using WeeloApi.Application.Features.Owners.Commands.Delete;
using WeeloApi.Domain.Entities;

namespace Application.IntegrationTests.Features.Owners
{
    using static Testing;

    public class DeleteOwnerTests : TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new DeleteOwnerRequest { IdOwner = 99 };
            ValidationContext context = new ValidationContext(command);
           
            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteOwner()
        {


            var command = await SendAsync(new CreateOwnerRequest
            {
                Name = "JUAN CARLOS CARDONA",
                Address = "CRA 9 No 5 - 27",
                Birthday = DateTime.Parse("2000-12-01")
            });

            await SendAsync(new DeleteOwnerRequest
            {
                IdOwner = command.Data.IdOwner
            });

            var item = await FindAsync<Owner>(command.Data.IdOwner);

            item.Should().BeNull();
        }
    }
}
