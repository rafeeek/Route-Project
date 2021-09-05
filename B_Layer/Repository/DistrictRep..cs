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
    public class DistrictRep : IcountryRepo<District>
    {
        private readonly FinalDbContext db;

        public DistrictRep(FinalDbContext Db)
        {
            db = Db;
        }
        public IEnumerable<District> GetAll()
        {
            var data = db.District.Select(a => a);
            return data;
        }

        public District GetById(int id)
        {
            var data = db.District.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }
    }
}
