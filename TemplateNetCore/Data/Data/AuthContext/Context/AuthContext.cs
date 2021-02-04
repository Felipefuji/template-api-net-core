using Data.Data.AuthContext.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Data.AuthContext.Context
{
    public class AuthContext : IdentityDbContext<User, Role, Guid>
    {

        public AuthContext(DbContextOptions<AuthContext> options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
