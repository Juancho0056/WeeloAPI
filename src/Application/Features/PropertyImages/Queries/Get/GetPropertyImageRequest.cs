using WeeloApi.Application.Common.Abstracts;

namespace WeeloApi.Application.Features.PropertyImages.Queries.Get
{
    public class GetPropertyImageRequest : QueryRequest<PropertyImageDto>
    {
        /// <summary>
        /// Identification Property Image
        /// </summary>
        /// <example>1</example>
        public int IdPropertyImage { get; set; }
    }
}

