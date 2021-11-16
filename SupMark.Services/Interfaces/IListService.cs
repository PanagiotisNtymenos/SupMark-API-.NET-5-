using SupMark.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupMark.Services.Interfaces
{
    public interface IListService
    {
        Task<IEnumerable<List>> FetchLists();
        Task<List> FetchList(int id);
        Task<List> CreateList(List list);
        Task<List> UpdateList(int id, List list);
        Task<bool> DeleteList(int id);
    }
}
