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

namespace WeeloApi.Application.Features.Owners.Queries.GetAll
{
    public class GetAllOwnerHandler : QueryRequestHandler<GetAllOwnerRequest, PaginatedList<OwnerDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetAllOwnerHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<PaginatedList<OwnerDto>> HandleQuery(GetAllOwnerRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Owner> query = (from v in _context.Owners
                                        select v);
            if (request.IdOwner != null && request.IdOwner > 0)
            {
                query = query.Where(v => request.IdOwner == v.IdOwner);
            }
            if (!string.IsNullOrEmpty(request.Name))
            {
                query = query.Where(v => v.Name.ToLower().Contains(request.Name.ToLower()));
            }
            if (!string.IsNullOrEmpty(request.Address))
            {
                query = query.Where(v => v.Address.ToLower().Contains(request.Address.ToLower()));
            }
            if (request.Birthday != null && request.Birthday != DateTime.MinValue)
            {
                query = query.Where(v => v.Birthday.Equals(request.Birthday));
            }

            return await query.AsNoTracking()
                            .ProjectTo<OwnerDto>(_mapper.ConfigurationProvider)
                            .PaginatedListAsync(request.PageNumber, request.PageSize);


        }
    }
}
