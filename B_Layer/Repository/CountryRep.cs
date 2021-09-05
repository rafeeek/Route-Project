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
    public class CountryRep : IcountryRepo<Country>
    {
        private readonly FinalDbContext db;

        public CountryRep(FinalDbContext Db)
        {
            db = Db;
        }

        public IEnumerable<Country> GetAll()
        {
            var data = db.Country.Select(a => a);
            return data;
        }

        public Country GetById(int id)
        {
            var data = db.Country.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }
    }
}
