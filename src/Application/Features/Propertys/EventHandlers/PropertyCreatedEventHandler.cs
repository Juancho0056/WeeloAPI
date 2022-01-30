using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WeeloApi.Application.Common.Interfaces;
using WeeloApi.Application.Common.Models;
using WeeloApi.Application.Features.PropertyTraces.Commands.Create;
using WeeloApi.Domain.Events;

namespace WeeloApi.Application.Features.Propertys.EventHandlers
{
    public class PropertyCreatedEventHandler : INotificationHandler<DomainEventNotification<PropertyEvent>>
    {
        private readonly IMediator _mediator;
        private readonly IApplicationDbContext _context;

        public PropertyCreatedEventHandler(IMediator mediator, IApplicationDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async  Task Handle(DomainEventNotification<PropertyEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;
         
            var command = new CreatePropertyTraceRequest()
            {
                DateSale = DateTime.Now,
                Name = domainEvent.Item.Name,
                Value = domainEvent.Item.Price,
                Tax = domainEvent.Item.Price * (decimal)0.19,
                IdProperty = domainEvent.Item.IdProperty
            };
        
            var result =  await _mediator.Send(command);

            if (!result.Success)
                throw new Exception(result.Error);
            
            //return Task.CompletedTask;
        }
    }
}
