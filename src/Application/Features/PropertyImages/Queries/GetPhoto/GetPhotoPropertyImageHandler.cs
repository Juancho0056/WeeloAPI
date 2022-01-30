using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WeeloApi.Application.Common.Abstracts;
using WeeloApi.Application.Common.Interfaces;
using WeeloApi.Application.Common.Utils;

namespace WeeloApi.Application.Features.PropertyImages.Queries.GetPhoto
{
    public class GetPhotoPropertyImageHandler : QueryRequestHandler<GetPhotoPropertyImageRequest, FileStream>
    {
        private readonly IApplicationDbContext _context;
        private readonly IOptions<Global> _options;
        private readonly IWebHostEnvironment _env;
        public GetPhotoPropertyImageHandler(IApplicationDbContext context, IOptions<Global> options,  IWebHostEnvironment env)
        {
            _context = context;
            _options = options;
            _env = env;
        }

        public override async Task<FileStream> HandleQuery(GetPhotoPropertyImageRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var vm = await _context.PropertyImages
                .AsNoTracking()
                .Where(e => e.IdPropertyImage == request.IdPropertyImage)
                .FirstOrDefaultAsync(cancellationToken);

                return System.IO.File.OpenRead(Path.Combine(_env.WebRootPath, _options.Value.ImagePath, vm.File));
            }
            catch (System.Exception)
            {
                return System.IO.File.OpenRead(Path.Combine(_env.WebRootPath, _options.Value.ImagePath, _options.Value.DefaultPhoto));
            }
        }

    }
}
