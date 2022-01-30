using WeeloApi.Application.Common.Interfaces;
using WeeloApi.Application.Common.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeeloApi.Application.Common.Exceptions;

namespace WeeloApi.Application.Common.Abstracts
{
    public abstract class CommandRequestHandler<TRequest, TData> : IRequestHandler<TRequest, CommandResult<TData>> where TRequest : IRequest<CommandResult<TData>>
    {
        private readonly IBaseDbContext _context;

        public CommandRequestHandler(IBaseDbContext context)
        {
            _context = context;
        }

        public virtual async Task<CommandResult<TData>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _context.BeginTransactionAsync();
                TData vm = await HandleCommand(request, cancellationToken);
                await _context.CommitTransactionAsync();

                return CommandResult<TData>.Ok(vm);
            }
            catch (DbUpdateConcurrencyException)
            {
                _context.RollbackTransaction();
                _context.DetachAll();
                return CommandResult<TData>.Fail(ErrorMessage.ExceptionConcurrency);
            }
            catch (DbUpdateException)
            {
                _context.RollbackTransaction();
                _context.DetachAll();
                return CommandResult<TData>.Fail(ErrorMessage.ExceptionUpdateData);
            }
            catch (InvalidOperationException eIO)
            {
                _context.RollbackTransaction();
                _context.DetachAll();
                return CommandResult<TData>.Fail(eIO.Message);
            }
        }

        public abstract Task<TData> HandleCommand(TRequest request, CancellationToken cancellationToken);
    }
}
