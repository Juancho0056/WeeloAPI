using WeeloApi.Application.Common.Abstracts;

namespace WeeloApi.Application.Features.Propertys.Queries.Get
{
    public class GetPropertyRequest : QueryRequest<PropertyDto>
    {
        /// <summary>
        /// Identification Owner
        /// </summary>
        /// <example>1</example>
        public int IdProperty { get; set; }
    }
}

