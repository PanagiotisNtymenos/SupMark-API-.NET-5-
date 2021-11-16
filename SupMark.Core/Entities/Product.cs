using SupMark.Core.Entities.Common;
using SupMark.Core.Entities.Partials;
using System.ComponentModel.DataAnnotations;

namespace SupMark.Core.Entities
{
    public class Product : BaseEntity<int>
    {
        public Product()
        {
        }

        public Product(string name, string image, string type)
        {
            Name = name;
            Image = image;
            Type = type;
        }

        //[Required]
        public string Name { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        public string Notes { get; set; }
    }
}
