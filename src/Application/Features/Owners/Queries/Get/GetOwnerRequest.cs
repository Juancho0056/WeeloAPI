using WeeloApi.Application.Common.Abstracts;

namespace WeeloApi.Application.Features.Owners.Queries.Get
{
    public class GetOwnerRequest : QueryRequest<OwnerDto>
    {
        /// <summary>
        /// Identification Owner
        /// </summary>
        /// <example>1</example>
        public int IdOwner { get; set; }
    }
}

