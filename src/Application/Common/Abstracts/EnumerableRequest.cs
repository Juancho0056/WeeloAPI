
using System.ComponentModel;

namespace WeeloApi.Application.Common.Abstracts
{
    public abstract class EnumerableRequest
    {
        [DefaultValue("1")]
        public int PageNumber { get; set; } = 1;

        [DefaultValue("10")]
        public int PageSize { get; set; } = 10;
    }
}
