using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WeeloApi.Application.Common.Abstracts;
using WeeloApi.Application.Common.Exceptions;
using WeeloApi.Application.Common.Interfaces;
using WeeloApi.Domain.Entities;

namespace WeeloApi.Application.Features.PropertyTraces.Commands.Create
{
    public class CreatePropertyTraceHandler : CommandRequestHandler<CreatePropertyTraceRequest, PropertyTraceDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CreatePropertyTraceHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<PropertyTraceDto> HandleCommand(CreatePropertyTraceRequest request, CancellationToken cancellationToken)
        {
            var entity = await _context.Propertys.Where(x => x.IdProperty == request.IdProperty).FirstOrDefaultAsync(cancellationToken);
            if (entity == null)
                throw new NotFoundException(nameof(Property), request.IdProperty);
            PropertyTrace property = new()
            {
                Name = request.Name,
                DateSale = request.DateSale,
                Value = request.Value,
                Tax = request.Tax,
                IdProperty = request.IdProperty
            };
            _context.PropertyTraces.Add(property);
            
            await _context.SaveChangesAsync(cancellationToken);
         
            PropertyTraceDto vm = _mapper.Map<PropertyTraceDto>(property);
            return vm;
        }


    }
}

