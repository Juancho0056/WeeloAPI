using System;
using WeeloApi.Application.Common.Abstracts;
using WeeloApi.Application.Common.Models;

namespace WeeloApi.Application.Features.Propertys.Queries.GetAll
{
    /// <summary>
    /// Class for filter Property data
    /// </summary>
    public class GetAllPropertyRequest : QueryEnumerableRequest<PaginatedList<PropertyDto>>
    {
        /// <summary>
        /// Identification Property
        /// </summary>
        /// <example>1</example>
        public int? IdProperty { get; set; }
        /// <summary>
        /// Name Property
        /// </summary>
        /// <example>TORREON</example>
        public string Name { get; set; }
        /// <summary>
        /// Address for Property
        /// </summary>
        /// <example>CRA 9 No 27 - 09 IBAGUE </example>
        public string Address { get; set; }
        /// <summary>
        /// Price Property
        /// </summary>
        /// <example>1000000</example>
        public decimal? Price { get; set; }
        /// <summary>
        /// Code Internal for Property
        /// </summary>
        /// <example>454ee028-b4c6-465c-8da8-65a5ce79e41d</example>
        public Guid? CodeInternal { get; set; }
        /// <summary>
        /// Year Property
        /// </summary>
        /// <example>2021</example>
        public int? Year { get; set; }
        /// <summary>
        /// Owner Property
        /// </summary>
        /// <example>1</example>
        public int? IdOwner { get; set; }
    }
}
