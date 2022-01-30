using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WeeloApi.Application.Common.Abstracts;
using WeeloApi.Application.Common.Interfaces;

namespace WeeloApi.Application.Features.PropertyImages.Queries.Get
{
    /// <summary>
    /// Class for get PropertyImage by IdPropertyImage
    /// </summary>
    public class GetPropertyImageHandler : QueryRequestHandler<GetPropertyImageRequest, PropertyImageDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        /// <summary>
        /// Constructor to initialize the GetPropertyImageHandler class
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public GetPropertyImageHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        ///     Function to handle call query
        /// </summary>
        /// <param name="request">Query</param>
        /// <param name="cancellationToken">To cancel Task</param>
        /// <returns>Data for type PropertyImageDto</returns>
        public override async Task<PropertyImageDto> HandleQuery(GetPropertyImageRequest request, CancellationToken cancellationToken)
        {
            var vm = await _context.PropertyImages
                     .AsNoTracking()
                     .Where(e => e.IdPropertyImage == request.IdPropertyImage)
                     .ProjectTo<PropertyImageDto>(_mapper.ConfigurationProvider)
                     .FirstOrDefaultAsync(cancellationToken);

            return vm;

        }
    }
}