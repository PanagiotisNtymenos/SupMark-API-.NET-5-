using Newtonsoft.Json;
using SupMark.Authentication.Models;
using SupMark.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupMark.Core.Entities
{
    public class List : BaseEntity<int>
    {
        public List()
        {

        }
        public List(string name, IEnumerable<User> users, IEnumerable<Item> items, string notes)
        {
            Name = name;
            Users = users;
            UsersJSON = users != null ? JsonConvert.SerializeObject(users) : null;
            Items = items;
            ItemsJSON = items != null ? JsonConvert.SerializeObject(items) : null;
            Notes = notes;
        }

        public string Name { get; set; }

        public string UsersJSON { get; set; }
        public string ItemsJSON { get; set; }
        public string Notes { get; set; }

        public virtual IEnumerable<User> Users { get; set; }
        public virtual IEnumerable<Item> Items { get; set; }

    }
}
