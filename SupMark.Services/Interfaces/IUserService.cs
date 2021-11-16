using SupMark.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupMark.Services.Interfaces
{
   public interface IUserService
    {
        Task<IEnumerable<User>> FetchUsers();
        Task<IEnumerable<User>> FetchUsers(List<Guid> ids);
    }
}
