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
using WeeloApi.Domain.Entities;

namespace WeeloApi.Application.Features.Owners.Commands.Update
{
    public class UpdateOwnerHandler : CommandRequestHandler<UpdateOwnerRequest, OwnerDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IOptions<Global> _options;
        private readonly ISaveFileService _fileService;
        private readonly IWebHostEnvironment _env;
        public UpdateOwnerHandler(IApplicationDbContext context, IMediator mediator, IOptions<Global> options, IMapper mapper, ISaveFileService fileService, IWebHostEnvironment env) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
            _options = options;
            _fileService = fileService;
            _env = env;
        }
        public override async Task<OwnerDto> HandleCommand(UpdateOwnerRequest request, CancellationToken cancellationToken)
        {
            OwnerDto vm = new();
            var entity = await _context.Owners.Where(x => x.IdOwner == request.IdOwner).FirstOrDefaultAsync(cancellationToken);
            if (entity == null)
                throw new NotFoundException(nameof(Owner), request.IdOwner);
            

            if (!string.IsNullOrEmpty(request.Name))
                entity.Name = request.Name;
            
            if (!string.IsNullOrEmpty(request.Address))
                entity.Address = request.Address;

            if (request.Birthday != null && request.Birthday != DateTime.MinValue)
                entity.Birthday = (DateTime)request.Birthday;
            if (request.Photo != null)
            {
                if (string.IsNullOrWhiteSpace(_env.WebRootPath))
                {
                    _env.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                }
                var nameSave = _fileService.SaveImage(request.Photo, Path.Combine(_env.WebRootPath, _options.Value.ImagePath));
                if (string.IsNullOrEmpty(nameSave))
                {
                    var File = System.IO.File.OpenRead(Path.Combine(_env.WebRootPath, _options.Value.ImagePath, _options.Value.DefaultPhoto));
                    nameSave = _fileService.SaveImage(File, Path.Combine(_env.WebRootPath, _options.Value.ImagePath));

                    if (string.IsNullOrEmpty(nameSave))
                        throw new System.Exception("Error almacenando imagen");
                }
                entity.Photo = nameSave;
            }
            _context.Owners.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            vm = _mapper.Map<OwnerDto>(entity);
            return vm;
        }

    }
}
