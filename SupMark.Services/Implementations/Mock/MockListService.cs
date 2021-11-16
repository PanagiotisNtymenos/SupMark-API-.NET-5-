using SupMark.Core.Entities;
using SupMark.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupMark.Services.Implementations.Mock
{
    public class MockListService : IListService
    {
        public Task<List> CreateList(List list)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteList(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List> FetchList(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<List>> FetchLists()
        {
            throw new NotImplementedException();
        }

        public Task<List> UpdateList(int id, List list)
        {
            throw new NotImplementedException();
        }
    }
}
