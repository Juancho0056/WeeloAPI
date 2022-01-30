using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WeeloApi.Application.Common.Abstracts;
using WeeloApi.Application.Common.Exceptions;
using WeeloApi.Application.Common.Interfaces;
using WeeloApi.Application.Common.Utils;
using WeeloApi.Application.Features.PropertyImages;
using WeeloApi.Domain.Entities;

namespace WeeloApi.Application.Features.Owners.Commands.Update
{
    public class UpdatePropertyImageHandler : CommandRequestHandler<UpdatePropertyImageRequest, PropertyImageDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IOptions<Global> _options;
        private readonly ISaveFileService _fileService;
        private readonly IWebHostEnvironment _env;
        public UpdatePropertyImageHandler(IApplicationDbContext context, IOptions<Global> options, IMapper mapper, ISaveFileService fileService, IWebHostEnvironment env) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _options = options;
            _fileService = fileService;
            _env = env;
        }
        public override async Task<PropertyImageDto> HandleCommand(UpdatePropertyImageRequest request, CancellationToken cancellationToken)
        {
            PropertyImageDto vm = new();
            var entity = await _context.PropertyImages.Where(x => x.IdPropertyImage == request.IdPropertyImage).FirstOrDefaultAsync(cancellationToken);
            if(entity == null)
                throw new NotFoundException(nameof(PropertyImage), request.IdPropertyImage);

            var property = await _context.Propertys.Where(x => x.IdProperty == request.IdProperty).FirstOrDefaultAsync(cancellationToken);
            if (property == null)
                throw new NotFoundException(nameof(Property), request.IdProperty);

            if (request.IdProperty > 0)
                entity.IdProperty = (int)request.IdProperty;
            
            if (request.Enabled != null)
                entity.Enabled = (bool)request.Enabled;

   
            if (request.File != null)
            {
                if (string.IsNullOrWhiteSpace(_env.WebRootPath))
                {
                    _env.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                }
                var nameSave = _fileService.SaveImage(request.File, Path.Combine(_env.WebRootPath, _options.Value.ImagePath));
                if (string.IsNullOrEmpty(nameSave))
                {
                    var File = System.IO.File.OpenRead(Path.Combine(_env.WebRootPath, _options.Value.ImagePath, _options.Value.DefaultPhoto));
                    nameSave = _fileService.SaveImage(File, Path.Combine(_env.WebRootPath, _options.Value.DefaultImage));

                    if (string.IsNullOrEmpty(nameSave))
                        throw new System.Exception("Error almacenando imagen");
                }
                entity.File = nameSave;
            }
            _context.PropertyImages.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            vm = _mapper.Map<PropertyImageDto>(entity);
            return vm;
        }

    }
}
