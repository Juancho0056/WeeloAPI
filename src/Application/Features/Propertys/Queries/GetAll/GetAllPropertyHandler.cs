using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WeeloApi.Application.Common.Abstracts;
using WeeloApi.Application.Common.Interfaces;
using WeeloApi.Application.Common.Mappings;
using WeeloApi.Application.Common.Models;
using WeeloApi.Domain.Entities;

namespace WeeloApi.Application.Features.Propertys.Queries.GetAll
{
    public class GetAllPropertyHandler : QueryRequestHandler<GetAllPropertyRequest, PaginatedList<PropertyDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetAllPropertyHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override async Task<PaginatedList<PropertyDto>> HandleQuery(GetAllPropertyRequest request, CancellationToken cancellationToken)
        {
          
            IQueryable<Property> query = (from v in _context.Propertys
                                          select v);
            if (request.IdProperty != null && request.IdProperty > 0)
            {
                query = query.Where(v => request.IdProperty == v.IdProperty);
            }
            if (!string.IsNullOrEmpty(request.Name))
            {
                query = query.Where(v => v.Name.ToLower().Contains(request.Name.ToLower()));
            }
            if (!string.IsNullOrEmpty(request.Address))
            {
                query = query.Where(v => v.Address.ToLower().Contains(request.Address.ToLower()));
            }
            if (request.Price != null && request.Price > 0)
            {
                query = query.Where(v => v.Price == request.Price);
            } 
            if (request.CodeInternal != null)
            {
                query = query.Where(v => v.CodeInternal == request.CodeInternal);
            }
            if (request.Year != null && request.Year > 0)
            {
                query = query.Where(v => v.Year == request.Year);
            }
            if (request.IdOwner != null && request.IdOwner > 0)
            {
                query = query.Where(v => request.IdOwner == v.IdOwner);
            }
            return await query.AsNoTracking()
                            .ProjectTo<PropertyDto>(_mapper.ConfigurationProvider)
                            .PaginatedListAsync(request.PageNumber, request.PageSize);

        }
    }
}
