using AppMessageQueue.Domains.Data;
using DNI.Shared.Services.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMessageQueue.Data
{
    public class AppIdentityDbContext : DbContextBase
    {
        public AppIdentityDbContext(DbContextOptions dbContextOptions) 
            : base(dbContextOptions, true, true, true)
        {
        }

        public DbSet<User> Users { get;set; }
        public DbSet<ApplicationInstance> ApplicationInstances { get; set; }
    }
}
