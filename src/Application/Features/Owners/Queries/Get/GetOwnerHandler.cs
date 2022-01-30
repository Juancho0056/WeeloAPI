using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WeeloApi.Application.Common.Abstracts;
using WeeloApi.Application.Common.Interfaces;

namespace WeeloApi.Application.Features.Owners.Queries.Get
{
    /// <summary>
    /// Class for get Owner by IdOwner
    /// </summary>
    public class GetOwnerHandler : QueryRequestHandler<GetOwnerRequest, OwnerDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        /// <summary>
        /// Constructor to initialize the GetOwnerHandler class
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public GetOwnerHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        ///     Function to handle call query
        /// </summary>
        /// <param name="request">Query</param>
        /// <param name="cancellationToken">To cancel Task</param>
        /// <returns>Data for type OwnerDto</returns>
        public override async Task<OwnerDto> HandleQuery(GetOwnerRequest request, CancellationToken cancellationToken)
        {
            var vm = await _context.Owners
                     .AsNoTracking()
                     .Where(e => e.IdOwner == request.IdOwner)
                     .ProjectTo<OwnerDto>(_mapper.ConfigurationProvider)
                     .FirstOrDefaultAsync(cancellationToken);

            return vm;

        }
    }
}