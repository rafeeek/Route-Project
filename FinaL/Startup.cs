using B_Layer.Helpers;
using B_Layer.Interface;
using B_Layer.Mapper;
using B_Layer.Repository;
using DAL_Layer.Database;
using DAL_Layer.Entity;
using DAL_Layer.Entity.Place;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinaL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddNewtonsoftJson(opt => {
                opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });


            services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

            services.AddScoped<Interface<Department>, DepartmentRep>();
            services.AddScoped<Interface<Employee>, EmployeeRep>();
            services.AddScoped<IcountryRepo<Country>, CountryRep>();
            services.AddScoped<IcountryRepo<City>, CityRep>();
            services.AddScoped<IcountryRepo<District>, DistrictRep>();

            services.AddDbContextPool<FinalDbContext>(opts =>
                       opts.UseSqlServer(Configuration.GetConnectionString("FinalConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<FinalDbContext>()
            .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(TokenOptions.DefaultProvider);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
