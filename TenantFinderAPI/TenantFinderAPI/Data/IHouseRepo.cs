using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenantFinderAPI.Models;

namespace TenantFinderAPI.Data
{
    public interface IHouseRepo
    {
        public void addHouse(House house);
        public bool deleteHouse(int id);
        public void updateHouse(House house);
        public IEnumerable<House> getAllHouses();
        public House getHouse(int id);
    }
}
