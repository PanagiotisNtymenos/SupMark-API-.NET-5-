using SupMark.Authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupMark.Core.Entities
{
    public class User
    {
        public User()
        {

        }
        public Guid SupMarkUserId { get; set; }
        public virtual SupMarkUser SupMarkUser { get; set; }
        public virtual IEnumerable<List> Lists { get; set; }
        public string ListsJSON { get; set; }
    }
}
