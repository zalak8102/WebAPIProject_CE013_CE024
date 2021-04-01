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
    public class HouseController : ControllerBase
    {
        private readonly IHouseRepo hrepo;
        public HouseController(IHouseRepo hrepo)
        {
            this.hrepo = hrepo;
        }
        [HttpPost]
        public ActionResult addHouse(House house)
        {
            House hs = new House();
            hs.no = house.no;
            hs.name = house.name;
            hs.area = house.area;
            hs.city = house.city;
            hs.category = house.category;
            hs.rent = house.rent;
            hs.reqtenant = house.reqtenant;
            hrepo.addHouse(hs);
            return Ok();
        }
        [HttpGet]
        public ActionResult<IEnumerable<House>> getAllHouses()
        {
            var h = hrepo.getAllHouses();
            return Ok(h);

        }
        [HttpGet("{id}")]
        public ActionResult<House> getHouse(int id)
        {
            var h = hrepo.getHouse(id);
            return Ok(h);

        }
        [HttpDelete("{id}")]
        public ActionResult deleteHouse(int id)
        {
            var h = hrepo.deleteHouse(id);
            if (h == false)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }

        }
        [HttpPut("{id}")]
        public ActionResult updateHouse(int id, House house)
        {
            House hs = hrepo.getHouse(id);
            hs.no = house.no;
            hs.name = house.name;
            hs.area = house.area;
            hs.city = house.city;
            hs.category = house.category;
            hs.rent = house.rent;
            hs.reqtenant = house.reqtenant;
            hrepo.updateHouse(hs);

            return Ok();
        }
    }
}
