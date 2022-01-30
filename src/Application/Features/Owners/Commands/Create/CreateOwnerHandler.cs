using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using WeeloApi.Application.Common.Abstracts;
using WeeloApi.Application.Common.Interfaces;
using WeeloApi.Application.Common.Utils;
using WeeloApi.Domain.Entities;

namespace WeeloApi.Application.Features.Owners.Commands.Create
{
    public class CreateOwnerHandler : CommandRequestHandler<CreateOwnerRequest, OwnerDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IOptions<Global> _options;
        private readonly ISaveFileService _fileService;
        private readonly IWebHostEnvironment _env;
        public CreateOwnerHandler(IApplicationDbContext context, IOptions<Global> options, IMapper mapper, ISaveFileService fileService, IWebHostEnvironment env) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _options = options;
            _fileService = fileService;
            _env = env;
        }
        public override async Task<OwnerDto> HandleCommand(CreateOwnerRequest request, CancellationToken cancellationToken)
        {
            
            if (string.IsNullOrWhiteSpace(_env.WebRootPath))
            {
                _env.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }
            var nameSave = _fileService.SaveImage(request.Photo, Path.Combine(_env.WebRootPath, _options.Value.ImagePath));
            Owner owner = new()
            {
                Name = request.Name,
                Address = request.Address,
                Birthday = request.Birthday,
                Photo = nameSave
            };
            if (!string.IsNullOrEmpty(nameSave))
            {
                owner.Photo = nameSave;
                //var File = System.IO.File.OpenRead(Path.Combine(_env.WebRootPath, _options.Value.ImagePath, _options.Value.DefaultPhoto));
                //nameSave = _fileService.SaveImage(File, Path.Combine(_env.WebRootPath, _options.Value.ImagePath));

                //if (string.IsNullOrEmpty(nameSave))
                //    throw new System.Exception("Error almacenando imagen");
            }
         
            _context.Owners.Add(owner);

            await _context.SaveChangesAsync(cancellationToken);

            OwnerDto vm = _mapper.Map<OwnerDto>(owner);
            return vm;
        }


    }
}

