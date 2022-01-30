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
using WeeloApi.Application.Common.Models;
using WeeloApi.Application.Common.Utils;
using WeeloApi.Application.Features.PropertyImages;
using WeeloApi.Domain.Entities;

namespace WeeloApi.Application.Features.PropertyImages.Commands.CreateImage
{
    public class CreatePropertyImageHandler : CommandRequestHandler<CreatePropertyImageRequest, PropertyImageDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IOptions<Global> _options;
        private readonly ISaveFileService _fileService;
        private readonly IWebHostEnvironment _env;
        public CreatePropertyImageHandler(IApplicationDbContext context,
            IMapper mapper, IOptions<Global> options, ISaveFileService fileService, IWebHostEnvironment env) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _options = options;
            _fileService = fileService;
            _env = env;
        }
        public override async Task<PropertyImageDto> HandleCommand(CreatePropertyImageRequest request,
          CancellationToken cancellationToken)
        {
            var entity = await _context.Propertys.Where(x => x.IdProperty == request.IdProperty).FirstOrDefaultAsync(cancellationToken);
            if (entity == null)
                throw new NotFoundException(nameof(Property), request.IdProperty);

            if (string.IsNullOrWhiteSpace(_env.WebRootPath))
            {
                _env.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }
            var nameSave =  _fileService.SaveImage(request.File, Path.Combine(_env.WebRootPath, _options.Value.ImagePath));
            if (string.IsNullOrEmpty(nameSave)) 
            {
                var File = System.IO.File.OpenRead(Path.Combine(_env.WebRootPath, _options.Value.ImagePath, _options.Value.DefaultPhoto));
                nameSave = _fileService.SaveImage(File, Path.Combine(_env.WebRootPath, _options.Value.DefaultImage));

                if (string.IsNullOrEmpty(nameSave))
                    throw new System.Exception("Error almacenando imagen");
            }
            PropertyImage image = new()
            {
                IdProperty = request.IdProperty,
                File = nameSave,
                Enabled = true
            };
            _context.PropertyImages.Add(image);
            PropertyImageDto vm;
           
            await _context.SaveChangesAsync(cancellationToken);
            vm = _mapper.Map<PropertyImageDto>(image);
      
            return vm;

        }
    }
}
