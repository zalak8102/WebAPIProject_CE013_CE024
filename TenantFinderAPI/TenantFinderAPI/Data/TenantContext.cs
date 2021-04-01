using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenantFinderAPI.Models;

namespace TenantFinderAPI.Data
{
    public class TenantContext:DbContext
    {
        public TenantContext(DbContextOptions<TenantContext> opt):base(opt)
        {

        }
        public DbSet<House> Houses { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
    }
}
