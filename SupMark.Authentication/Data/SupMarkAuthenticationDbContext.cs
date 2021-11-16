using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupMark.Authentication.Data
{
    public class SupMarkAuthenticationDbContext : IdentityDbContext
    {
        public SupMarkAuthenticationDbContext(DbContextOptions<SupMarkAuthenticationDbContext> options)
            : base(options)
        {
        }
    }
}
