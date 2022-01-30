using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WeeloApi.Application.Common.Abstracts;
using WeeloApi.Application.Common.Exceptions;
using WeeloApi.Application.Common.Interfaces;
using WeeloApi.Domain.Entities;

namespace WeeloApi.Application.Features.Propertys.Commands.Delete
{
    public class DeletePropertyHandler : CommandRequestHandler<DeletePropertyRequest, Unit>
    {
        private readonly IApplicationDbContext _context;
        public DeletePropertyHandler(IApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<Unit> HandleCommand(DeletePropertyRequest request, CancellationToken cancellationToken)
        {

            var entity = await _context.Propertys.Where(x => x.IdProperty == request.IdProperty).FirstOrDefaultAsync(cancellationToken);
            if (entity == null)
                throw new NotFoundException(nameof(Property), request.IdProperty);

            _context.Propertys.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
