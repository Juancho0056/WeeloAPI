using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WeeloApi.Application.Common.Abstracts;
using WeeloApi.Application.Common.Exceptions;
using WeeloApi.Application.Common.Interfaces;
using WeeloApi.Domain.Entities;
using WeeloApi.Domain.Events;

namespace WeeloApi.Application.Features.Propertys.Commands.Create
{
    public class CreatePropertyHandler : CommandRequestHandler<CreatePropertyRequest, PropertyDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CreatePropertyHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<PropertyDto> HandleCommand(CreatePropertyRequest request, CancellationToken cancellationToken)
        {
            var owner = await _context.Owners.Where(x => x.IdOwner == request.IdOwner).FirstOrDefaultAsync(cancellationToken);
            if (owner == null)
                throw new NotFoundException(nameof(Owner), request.IdOwner);

            Property property = new()
            {
                Name = request.Name,
                Address = request.Address,
                Price = request.Price,
                Year = request.Year,
                CodeInternal = Guid.NewGuid(),
                IdOwner = request.IdOwner
            };
            // Se publica el evento de insertcion de propiedad para insertar en PropertyTrace
            property.DomainEvents.Add(new PropertyEvent(property));
            _context.Propertys.Add(property);
            
            await _context.SaveChangesAsync(cancellationToken);
            
            PropertyDto vm = _mapper.Map<PropertyDto>(property);
            return vm;
        }


    }
}

