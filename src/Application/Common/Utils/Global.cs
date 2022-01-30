
using System.Collections.Generic;

namespace WeeloApi.Application.Common.Utils
{
    public class Global
    {
        public int MaxImageSizeProperty { get; set; }
        public List<string> ValidExtension{ get; set; } = new List<string>();
        public string ImagePath { get; set; }
        public string DefaultPhoto { get; set; }
        public string DefaultImage { get; set; }
    }
}
