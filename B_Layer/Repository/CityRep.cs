using B_Layer.Interface;
using DAL_Layer.Database;
using DAL_Layer.Entity.Place;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Layer.Repository
{
    public class CityRep : IcountryRepo<City>
    {
        private readonly FinalDbContext db;

        public CityRep(FinalDbContext Db)
        {
            db = Db;
        }
        public IEnumerable<City> GetAll()
        {
            var data = db.City.Select(a => a);
            return data;
        }

        public City GetById(int id)
        {
            var data = db.City.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }
    }
}
