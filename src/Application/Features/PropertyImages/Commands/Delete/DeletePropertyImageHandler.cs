using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WeeloApi.Application.Common.Abstracts;
using WeeloApi.Application.Common.Exceptions;
using WeeloApi.Application.Common.Interfaces;
using WeeloApi.Domain.Entities;

namespace WeeloApi.Application.Features.Owners.Commands.Delete
{
    public class DeletePropertyImageHandler : CommandRequestHandler<DeletePropertyImageRequest, Unit>
    {
        private readonly IApplicationDbContext _context;
        public DeletePropertyImageHandler(IApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<Unit> HandleCommand(DeletePropertyImageRequest request, CancellationToken cancellationToken)
        {
   
            var entity = await _context.PropertyImages.Where(x => x.IdPropertyImage == request.IdPropertyImage).FirstOrDefaultAsync(cancellationToken);
            if (entity == null)
                throw new NotFoundException(nameof(PropertyImage), request.IdPropertyImage);
            _context.PropertyImages.Remove(entity);
          
            await _context.SaveChangesAsync(cancellationToken);
           
            return Unit.Value;
        }
    }
}

