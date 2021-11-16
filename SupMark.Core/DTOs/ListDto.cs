using SupMark.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupMark.Core.DTOs
{
    public class ListDto
    {
        public string Name { get; set; }
        public List<Guid> UserIds { get; set; }
        public string UsersJSON { get; set; }
        public List<int> ItemIds { get; set; }
        public string ItemsJSON { get; set; }
        public string Notes { get; set; }
    }
}
