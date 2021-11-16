using SupMark.Authentication.Models;
using SupMark.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupMark.Core.Entities
{
    public class Item : BaseEntity<int>
    {
        public Item()
        {

        }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
        public virtual User AddedBy { get; set; }
        public virtual User RemovedBy { get; set; }
        public virtual List List { get; set; }
    }
}
