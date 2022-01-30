using WeeloApi.Application.Common.Models;
using MediatR;

namespace WeeloApi.Application.Common.Abstracts
{
    public abstract class QueryEnumerableRequest<TData> : EnumerableRequest, IRequest<QueryResult<TData>>
    {
    }
    
}
