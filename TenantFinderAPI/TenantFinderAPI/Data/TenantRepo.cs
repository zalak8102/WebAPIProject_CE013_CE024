using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenantFinderAPI.Models;

namespace TenantFinderAPI.Data
{
    public class TenantRepo : ITenantRepo
    {
        private readonly TenantContext context;

        public TenantRepo(TenantContext context)
        {
            this.context = context;
        }
        public void addTenant(Tenant tenant)
        {
            context.Tenants.Add(tenant);
            context.SaveChanges();
            return;
        }

        public bool deleteTenant(int id)
        {
            var deltenant = context.Tenants.Find(id);
            if (deltenant == null)
            {
                return false;
            }
            else
            {
                context.Tenants.Remove(deltenant);
                context.SaveChanges();
                return true;
            }
        }

        public IEnumerable<Tenant> getAllTenants()
        {
            return context.Tenants;
        }

        public Tenant getTenant(int id)
        {
            var t = context.Tenants.Find(id);
            if (t == null)
            {
                return null;
            }
            else
            {
                return t;
            }
        }

        public void updateTenant(Tenant tenant)
        {
            var t = context.Tenants.Attach(tenant);
            t.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return;
        }
    }
}
