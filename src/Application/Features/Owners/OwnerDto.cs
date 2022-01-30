using AutoMapper;
using System;
using WeeloApi.Application.Common.Mappings;
using WeeloApi.Domain.Entities;

namespace WeeloApi.Application.Features.Owners
{
    /// <summary>
    /// Response data for Owner
    /// </summary>
    public class OwnerDto : IMapFrom<Owner>
    {
        /// <summary>
        /// Identification Owner
        /// </summary>
        /// <example>1</example>
        public int IdOwner { get; set; }
        /// <summary>
        /// Name for Owner
        /// </summary>
        /// <example>JUAN CARLOS CARDONA</example>
        public string Name { get; set; }
        /// <summary>
        /// Address for Owner
        /// </summary>
        /// <example>CRA 9 No 27 - 09 IBAGUE </example>
        public string Address { get; set; }
        /// <summary>
        /// Birthday Owner
        /// </summary>
        /// <example>2000-12-01</example>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// Mapping Owner to OwnerDto
        /// </summary>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Owner, OwnerDto>();
        }
    }
}
