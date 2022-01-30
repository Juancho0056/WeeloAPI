using WeeloApi.Application.Common.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WeeloApi.Application.Common.Exceptions;
namespace WeeloApi.Application.Common.Abstracts
{
    /// <summary>
    /// Abstract Class to handle call query
    /// </summary>
    /// <typeparam name="TRequest">TRequest is a mediatr interface to handle</typeparam>
    /// <typeparam name="TData">TData is the data type to return</typeparam>
    public abstract class QueryRequestHandler<TRequest, TData> : IRequestHandler<TRequest, QueryResult<TData>> where TRequest : IRequest<QueryResult<TData>>
    {
        /// <summary>
        ///     Function to handle call query
        /// </summary>
        /// <param name="request">Query</param>
        /// <param name="cancellationToken">To cancel Task</param>
        /// <returns>Data for type TData</returns>
        public virtual async Task<QueryResult<TData>> Handle(TRequest request, CancellationToken cancellationToken)
        {
                TData vm = await HandleQuery(request, cancellationToken);

                if (vm != null) 
                    return QueryResult<TData>.Ok(vm);
                else
                    throw new NotFoundException(ErrorMessage.NotFound(typeof(TData).Name));
        }
        /// <summary>
        ///     Function to handle call query
        /// </summary>
        /// <param name="request">Query</param>
        /// <param name="cancellationToken">To cancel Task</param>
        /// <returns>Data for type TData</returns>
        public abstract Task<TData> HandleQuery(TRequest request, CancellationToken cancellationToken);
    }
}
