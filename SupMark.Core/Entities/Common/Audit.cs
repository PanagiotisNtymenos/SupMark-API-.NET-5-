using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupMark.Core.Entities.Common
{
    public class Audit
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Audit()
        {
            CreatedAt = UpdatedAt = DateTime.UtcNow;
        }

        public void Create()
        {
            CreatedAt= UpdatedAt = DateTime.UtcNow;
        }
        public void Update()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
