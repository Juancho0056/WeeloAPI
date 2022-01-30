
using WeeloApi.Domain.Common;

namespace WeeloApi.Domain.Entities
{
    public class PropertyImage: AuditableEntity
    {
        public int IdPropertyImage { get; set; }
        public Property Property { get; set; }
        public int IdProperty { get; set; }
        public string File { get; set; }
        public bool Enabled { get; set; }
    }
}
