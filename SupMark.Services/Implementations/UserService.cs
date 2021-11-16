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
    public class UserService : IUserService
    {
        private readonly SupMarkDbContext _context;
        public UserService(SupMarkDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> FetchUsers()
        {
            return await _context.Users
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> FetchUsers(List<Guid> ids)
        {
            return await _context.Users
                .AsNoTracking()
                .Where(u => ids.Contains(u.SupMarkUserId))
                .ToListAsync();
        }
    }
}
