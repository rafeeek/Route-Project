using B_Layer.Interface;
using DAL_Layer.Database;
using DAL_Layer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Layer.Repository
{
    public class DepartmentRep : Interface<Department>
    {
        private readonly FinalDbContext Db;

        public DepartmentRep(FinalDbContext db)
        {
            Db = db;
        }

        public IEnumerable<Department> AllData()
        {
            var data = Db.Department.Select(a => a);
            return data;
        }

        public void Creat(Department obj)
        {
            Db.Department.Add(obj);
            Db.SaveChanges();
        }

        public void Delete(Department obj)
        {
            Db.Department.Remove(obj);
            Db.SaveChanges();
        }

        public Department GetById(int Id)
        {
            var data = Db.Department.Where(a => a.Id == Id).FirstOrDefault();
            return data;
        }

        public void Updata(Department obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }
    }
}
