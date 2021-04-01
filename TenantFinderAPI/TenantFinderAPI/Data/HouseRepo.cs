using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenantFinderAPI.Models;

namespace TenantFinderAPI.Data
{
    public class HouseRepo : IHouseRepo
    {
        private readonly TenantContext context;

        public HouseRepo(TenantContext context)
        {
            this.context = context;
        }
        public void addHouse(House house)
        {
            context.Houses.Add(house);
            context.SaveChanges();
            return;
        }

        public bool deleteHouse(int id)
        {
            var delhouse = context.Houses.Find(id);
            if (delhouse == null)
            {
                return false;
            }
            else
            {
                context.Houses.Remove(delhouse);
                context.SaveChanges();
                return true;
            }
        }

        public IEnumerable<House> getAllHouses()
        {
            return context.Houses;
        }

        public House getHouse(int id)
        {
            var h = context.Houses.Find(id);
            if (h == null)
            {
                return null;
            }
            else
            {
                return h;
            }
        }

        public void updateHouse(House house)
        {
            var h = context.Houses.Attach(house);
            h.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return;
        }
    }
}
