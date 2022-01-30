
using WeeloApi.Domain.Common;
using WeeloApi.Domain.Entities;

namespace WeeloApi.Domain.Events
{
    public class PropertyEvent : DomainEvent
    {
        public PropertyEvent(Property item)
        {
            Item = item;
        }

        public Property Item { get; }
    }
}
