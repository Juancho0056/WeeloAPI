using WeeloApi.Application.Common.Models;
using MediatR;

namespace WeeloApi.Application.Common.Abstracts
{
    public abstract class QueryRequest<TData> : IRequest<QueryResult<TData>>
    {
    }
    
}
