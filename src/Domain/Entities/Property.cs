using System;
using System.Collections.Generic;
using WeeloApi.Domain.Common;
using WeeloApi.Domain.Events;

namespace WeeloApi.Domain.Entities
{
    public class Property: AuditableEntity, IHasDomainEvent
    {
        public int IdProperty { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public Guid CodeInternal { get; set; }
        public int Year { get; set; }
        public Owner Owner { get; set; }
        public int? IdOwner { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
