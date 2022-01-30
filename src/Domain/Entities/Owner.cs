using System;
using WeeloApi.Domain.Common;

namespace WeeloApi.Domain.Entities
{
    public class Owner : AuditableEntity
    {
        public int IdOwner { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public DateTime Birthday { get; set; }
    }
}
