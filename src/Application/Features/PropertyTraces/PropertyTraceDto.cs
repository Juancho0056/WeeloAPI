using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeloApi.Application.Common.Mappings;
using WeeloApi.Application.Features.Propertys;
using WeeloApi.Domain.Entities;

namespace WeeloApi.Application.Features.PropertyTraces
{
    public class PropertyTraceDto: IMapFrom<PropertyTrace>
    {
        public int IdPropertyTrace { get; set; }
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal Tax { get; set; }
        public int IdProperty { get; set; }
        public PropertyDto Property { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<PropertyTrace, PropertyTraceDto>();
        }
    }
}
