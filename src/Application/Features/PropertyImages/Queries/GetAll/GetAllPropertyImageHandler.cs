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

namespace WeeloApi.Application.Features.PropertyImages.Queries.GetAll
{
    public class GetAllPropertyImageHandler : QueryRequestHandler<GetAllPropertyImageRequest, PaginatedList<PropertyImageDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetAllPropertyImageHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<PaginatedList<PropertyImageDto>> HandleQuery(GetAllPropertyImageRequest request, CancellationToken cancellationToken)
        {
            IQueryable<PropertyImage> query = (from v in _context.PropertyImages
                                        select v);
            if (request.IdProperty != null && request.IdProperty > 0)
            {
                query = query.Where(v => request.IdProperty == v.IdProperty);
            }
            if (request.IdPropertyImage != null && request.IdPropertyImage > 0)
            {
                query = query.Where(v => request.IdPropertyImage == v.IdPropertyImage);
            }
            if (request.Enabled != null)
            {
                query = query.Where(v => request.Enabled == v.Enabled);
            }
            return await query.AsNoTracking()
                            .ProjectTo<PropertyImageDto>(_mapper.ConfigurationProvider)
                            .PaginatedListAsync(request.PageNumber, request.PageSize);


        }
    }
}
