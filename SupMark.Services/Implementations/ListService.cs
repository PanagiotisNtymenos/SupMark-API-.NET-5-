using Microsoft.EntityFrameworkCore;
using SupMark.Core.Entities;
using SupMark.Infrastructure.DataAccess;
using SupMark.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupMark.Services.Implementations
{
    public class ListService : IListService
    {
        private readonly SupMarkDbContext _context;
        public ListService(SupMarkDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<List>> FetchLists()
        {
            return await _context.Lists
                .AsNoTracking()
                //.Include(l => l.Users)                
                //.Include(l => l.Items)
                .ToListAsync();
        }

        public async Task<List> FetchList(int id)
        {
            return await _context.Lists
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<List> UpdateList(int id, List list)
        {
            throw new NotImplementedException();
        }

        public async Task<List> CreateList(List list)
        {
            await _context.Lists.AddAsync(list);

            await _context.SaveChangesAsync();

            return await _context.Lists
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == list.Id);
        }

        public async Task<bool> DeleteList(int id)
        {
            var list = await _context.Lists.FirstOrDefaultAsync(p => p.Id == id);

            if (list == null) return false;

            _context.Lists.Remove(list);

            await _context.SaveChangesAsync();

            return true;
        }

    }
}
