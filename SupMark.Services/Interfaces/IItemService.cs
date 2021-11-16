using SupMark.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupMark.Services.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> FetchItems();
        Task<IEnumerable<Item>> FetchItems(List<int> ids);
    }
}
