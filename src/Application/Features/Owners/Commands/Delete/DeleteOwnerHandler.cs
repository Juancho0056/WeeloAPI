using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WeeloApi.Application.Common.Abstracts;
using WeeloApi.Application.Common.Exceptions;
using WeeloApi.Application.Common.Interfaces;

namespace WeeloApi.Application.Features.Owners.Commands.Delete
{
    public class DeleteOwnerHandler : CommandRequestHandler<DeleteOwnerRequest, Unit>
    {
        private readonly IApplicationDbContext _context;
        public DeleteOwnerHandler(IApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<Unit> HandleCommand(DeleteOwnerRequest request, CancellationToken cancellationToken)
        {
   
            var entity = await _context.Owners.Where(x => x.IdOwner == request.IdOwner).FirstOrDefaultAsync(cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(ErrorMessage.NotFound("Owner"), new[] { "OwnerId" });
            }

            _context.Owners.Remove(entity);
          
            await _context.SaveChangesAsync(cancellationToken);
           
            return Unit.Value;
        }
    }
}

