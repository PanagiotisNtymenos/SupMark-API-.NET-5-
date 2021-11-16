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
    public class ItemService : IItemService
    {
        private readonly SupMarkDbContext _context;
        public ItemService(SupMarkDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> FetchItems()
        {
            return await _context.Items
               .AsNoTracking()
               .ToListAsync();
        }

        public async Task<IEnumerable<Item>> FetchItems(List<int> ids)
        {
            if (ids == null) return null;

            return await _context.Items
                .AsNoTracking()
                .Where(i => ids.Contains(i.Id))
                .ToListAsync();
        }
    }
}
