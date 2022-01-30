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

namespace WeeloApi.Application.Features.Propertys.Commands.Update
{
    public class UpdatePropertyHandler : CommandRequestHandler<UpdatePropertyRequest, PropertyDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UpdatePropertyHandler(IApplicationDbContext context, IMapper mapper) :base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        public override async Task<PropertyDto> HandleCommand(UpdatePropertyRequest request, CancellationToken cancellationToken)
        {
            var entity = await _context.Propertys.Where(x => x.IdProperty == request.IdProperty).FirstOrDefaultAsync(cancellationToken);
            if (entity == null)
                throw new NotFoundException(nameof(Property), request.IdProperty);

            var owner = await _context.Owners.Where(x => x.IdOwner == request.IdOwner).FirstOrDefaultAsync(cancellationToken);
            if (owner == null)
                throw new NotFoundException(nameof(Owner), request.IdOwner);

            entity.IdOwner = request.IdOwner;
            if(!string.IsNullOrEmpty(request.Name))
                entity.Name = request.Name;
            if(!string.IsNullOrEmpty(request.Address))
                entity.Address = request.Address;

            //entity.Price = request.Price;
            entity.Year = request.Year;
            //entity.DomainEvents.Add(new PropertyEvent(entity));
            _context.Propertys.Update(entity);
          
            await _context.SaveChangesAsync(cancellationToken);
        
            PropertyDto vm = _mapper.Map<PropertyDto>(entity);
            return vm;
        }
    }
}
