using AutoMapper;
using WeeloApi.Application.Common.Mappings;
using WeeloApi.Application.Features.Propertys;
using WeeloApi.Domain.Entities;

namespace WeeloApi.Application.Features.PropertyImages
{
    public class PropertyImageDto : IMapFrom<PropertyImage>
    {
        public int IdPropertyImage { get; set; }
        public int IdProperty { get; set; }
        public bool Enabled { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<PropertyImage, PropertyImageDto>();
        }
    }
}
