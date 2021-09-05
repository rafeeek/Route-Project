using DAL_Layer.Entity;
using DAL_Layer.Entity.Place;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Layer.Database
{
    public class FinalDbContext: IdentityDbContext
    {

        public FinalDbContext(DbContextOptions<FinalDbContext> obj) :base(obj)
        {
           
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Employee> Employee { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
