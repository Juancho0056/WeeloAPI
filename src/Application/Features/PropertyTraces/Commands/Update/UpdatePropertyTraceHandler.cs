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

namespace WeeloApi.Application.Features.PropertyTraces.Commands.Update
{
    public class UpdatePropertyTraceHandler : CommandRequestHandler<UpdatePropertyTraceRequest, PropertyTraceDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UpdatePropertyTraceHandler(IApplicationDbContext context, IMapper mapper) :base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        public override async Task<PropertyTraceDto> HandleCommand(UpdatePropertyTraceRequest request, CancellationToken cancellationToken)
        {
            var entity = await _context.PropertyTraces.Where(x => x.IdPropertyTrace == request.IdPropertyTrace).FirstOrDefaultAsync(cancellationToken);
            if (entity == null)
                throw new NotFoundException(nameof(PropertyTrace), request.IdPropertyTrace);
            
            var property = await _context.Propertys.Where(x => x.IdProperty == request.IdProperty).FirstOrDefaultAsync(cancellationToken);
            if (property == null)
                throw new NotFoundException(nameof(Property), request.IdProperty);


            entity.IdProperty = request.IdProperty;
            if(!string.IsNullOrEmpty(request.Name))
                entity.Name = request.Name;
            if(request.Value > 0)
                entity.Value = request.Value;
            if(request.Tax > 0)
                entity.Tax = request.Tax;
            if (request.DateSale != null && request.DateSale != DateTime.MinValue)
                entity.DateSale = (DateTime)request.DateSale;

            _context.PropertyTraces.Update(entity);
          
            await _context.SaveChangesAsync(cancellationToken);
        
            PropertyTraceDto vm = _mapper.Map<PropertyTraceDto>(entity);
            return vm;
        }
    }
}
