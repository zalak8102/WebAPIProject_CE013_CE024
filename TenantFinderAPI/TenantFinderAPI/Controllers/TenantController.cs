using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenantFinderAPI.Data;
using TenantFinderAPI.Models;

namespace TenantFinderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ITenantRepo trepo;
        public TenantController(ITenantRepo trepo)
        {
            this.trepo = trepo;
        }
        [HttpPost]
        public ActionResult addTenant(Tenant tenant)
        {
            Tenant tt = new Tenant();
            tt.tname = tenant.tname;
            tt.phone = tenant.phone;
            tt.catg = tenant.catg;
            tt.reqhouse = tenant.reqhouse;
            trepo.addTenant(tt);
            return Ok();
        }
        [HttpGet]
        public ActionResult<IEnumerable<Tenant>> getAllTenants()
        {
            var t = trepo.getAllTenants();
            return Ok(t);

        }
        [HttpGet("{id}")]
        public ActionResult<House> getTenant(int id)
        {
            var t = trepo.getTenant(id);
            return Ok(t);

        }
        [HttpDelete("{id}")]
        public ActionResult deleteTenant(int id)
        {
            var t = trepo.deleteTenant(id);
            if (t == false)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }

        }
        [HttpPut("{id}")]
        public ActionResult updateTenant(int id, Tenant tenant)
        {
            Tenant tt = trepo.getTenant(id);
            tt.tname = tenant.tname;
            tt.phone = tenant.phone;
            tt.catg = tenant.catg;
            tt.reqhouse = tenant.reqhouse;
            trepo.updateTenant(tt);

            return Ok();
        }
    }
}
