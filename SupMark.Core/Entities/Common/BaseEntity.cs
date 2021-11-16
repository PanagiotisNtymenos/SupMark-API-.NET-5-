using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupMark.Core.Entities.Common
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
        //public virtual Audit Audit { get; set; }
    }
}
