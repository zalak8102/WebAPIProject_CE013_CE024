using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenantFinderAPI.Models;

namespace TenantFinderAPI.Data
{
    public interface ITenantRepo
    {
        public void addTenant(Tenant tenant);
        public bool deleteTenant(int id);
        public void updateTenant(Tenant tenant);
        public IEnumerable<Tenant> getAllTenants();
        public Tenant getTenant(int id);
    }
}
