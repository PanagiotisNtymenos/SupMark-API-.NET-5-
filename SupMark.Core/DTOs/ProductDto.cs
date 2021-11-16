using SupMark.Core.Entities.Partials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupMark.Core.DTOs
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        public string Notes { get; set; }
    }
}
