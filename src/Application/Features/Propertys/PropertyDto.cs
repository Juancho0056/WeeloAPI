using AutoMapper;
using System;
using WeeloApi.Application.Common.Mappings;
using WeeloApi.Application.Features.Owners;
using WeeloApi.Domain.Entities;

namespace WeeloApi.Application.Features.Propertys
{
    public class PropertyDto : IMapFrom<Property>
    {
        public int IdProperty { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public Guid CodeInternal { get; set; }
        public int Year { get; set; }
        public int IdOwner { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Property, PropertyDto>();
        }
    }
}
