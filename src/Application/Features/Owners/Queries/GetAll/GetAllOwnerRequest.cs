using System;
using WeeloApi.Application.Common.Abstracts;
using WeeloApi.Application.Common.Models;

namespace WeeloApi.Application.Features.Owners.Queries.GetAll
{
    /// <summary>
    /// Class for filter Owner data
    /// </summary>
    public class GetAllOwnerRequest : QueryEnumerableRequest<PaginatedList<OwnerDto>>
    {
        /// <summary>
        /// Identification Owner
        /// </summary>
        /// <example>1</example>
        public int? IdOwner { get; set; }
        /// <summary>
        /// Name Owner
        /// </summary>
        /// <example>JUAN CARLOS CARDONA</example>
        public string Name { get; set; }
        /// <summary>
        /// Address for Owner
        /// </summary>
        /// <example>TORREON</example>
        public string Address { get; set; }
        /// <summary>
        /// Birthday Owner
        /// </summary>
        /// <example>1997-12-01</example>
        public DateTime? Birthday { get; set; }
    }
}
