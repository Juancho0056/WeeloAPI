using AutoMapper;
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
using WeeloApi.Application.Features.Owners.Queries.Get;

namespace WeeloApi.Application.Features.Owners.Queries.GetPhoto
{
    public class GetPhotoOwnerHandler : QueryRequestHandler<GetPhotoOwnerRequest, FileStream>
    {
        private readonly IApplicationDbContext _context;
        private readonly IOptions<Global> _options;
        private readonly IWebHostEnvironment _env;
        public GetPhotoOwnerHandler(IApplicationDbContext context, IOptions<Global> options,  IWebHostEnvironment env)
        {
            _context = context;
            _options = options;
            _env = env;
        }

        public override async Task<FileStream> HandleQuery(GetPhotoOwnerRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var vm = await _context.Owners
                .AsNoTracking()
                .Where(e => e.IdOwner == request.IdOwner)
                .FirstOrDefaultAsync(cancellationToken);

                return System.IO.File.OpenRead(Path.Combine(_env.WebRootPath, _options.Value.ImagePath, vm.Photo));
            }
            catch (System.Exception)
            {
                return System.IO.File.OpenRead(Path.Combine(_env.WebRootPath, _options.Value.ImagePath, _options.Value.DefaultPhoto));
            }
        }

    }
}
