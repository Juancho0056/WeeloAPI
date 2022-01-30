using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WeeloApi.Application.Common.Abstracts;
using WeeloApi.Application.Common.Interfaces;

namespace WeeloApi.Application.Features.Propertys.Queries.Get
{
    /// <summary>
    /// Class for get Property by IdProperty
    /// </summary>
    public class GetPropertyHandler : QueryRequestHandler<GetPropertyRequest, PropertyDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        /// <summary>
        /// Constructor to initialize the GetPropertyHandler class
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public GetPropertyHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        ///     Function to handle call query
        /// </summary>
        /// <param name="request">Query</param>
        /// <param name="cancellationToken">To cancel Task</param>
        /// <returns>Data for type PropertyDto</returns>
        public override async Task<PropertyDto> HandleQuery(GetPropertyRequest request, CancellationToken cancellationToken)
        {
            var vm = await _context.Propertys
                     .AsNoTracking()
                     .Where(e => e.IdProperty == request.IdProperty)
                     .ProjectTo<PropertyDto>(_mapper.ConfigurationProvider)
                     .FirstOrDefaultAsync(cancellationToken);

            return vm;

        }
    }
}