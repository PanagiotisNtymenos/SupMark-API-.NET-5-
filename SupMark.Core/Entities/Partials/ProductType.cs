using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupMark.Core.Entities.Partials
{
    public class ProductType
    {
        public ProductType(string label)
        {
            Label = label;
        }

        public string Label { get; set; }
        public string Specific { get; set; }
    }
}
