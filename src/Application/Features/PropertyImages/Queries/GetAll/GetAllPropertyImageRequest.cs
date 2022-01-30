
using WeeloApi.Application.Common.Abstracts;
using WeeloApi.Application.Common.Models;

namespace WeeloApi.Application.Features.PropertyImages.Queries.GetAll
{
    /// <summary>
    /// Class for filter PropertyImage data
    /// </summary>
    public class GetAllPropertyImageRequest : QueryEnumerableRequest<PaginatedList<PropertyImageDto>>
    {
        /// <summary>
        /// Identification PropertyImage
        /// </summary>
        /// <example>1</example>
        public int? IdPropertyImage { get; set; }
        /// <summary>
        /// Identification Property
        /// </summary>
        /// <example>1</example>
        public int? IdProperty { get; set; }
        /// <summary>
        /// IsEnabled
        /// </summary>
        /// <example>true</example>
        public bool? Enabled { get; set; }
    }
}
