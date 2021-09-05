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
    public class EmployeeRep : Interface<Employee>
    {
        private readonly FinalDbContext Db;

        public EmployeeRep(FinalDbContext db)
        {
            Db = db;
        }

        public IEnumerable<Employee> AllData()
        {
            var data = Db.Employee.Include("Department").Include("District").Select(a => a);
            return data;
        }

        public void Creat(Employee obj)
        {
            Db.Employee.Add(obj);
            Db.SaveChanges();
        }

        public void Delete(Employee obj)
        {
            Db.Employee.Remove(obj);
            Db.SaveChanges();
        }

        public Employee GetById(int Id)
        {
            var data = Db.Employee.Include("Department").Where(a => a.Id == Id).FirstOrDefault();
            return data;
        }

        public void Updata(Employee obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }
    }
}
