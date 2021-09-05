using AutoMapper;
using B_Layer.Helpers;
using B_Layer.Interface;
using B_Layer.Models;
using B_Layer.Repository;
using DAL_Layer.Entity;
using DAL_Layer.Entity.Place;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FinaL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly Interface<Employee> _employee;
        private readonly IMapper mapper;
        private readonly Interface<Department> department;
        private readonly IcountryRepo<Country> country;
        private readonly IcountryRepo<City> city;
        private readonly IcountryRepo<District> district;

        public EmployeeController(
            Interface<Employee> employee ,
            IMapper Mapper ,
            Interface<Department> Department ,
            IcountryRepo<Country> Country ,
            IcountryRepo<City> City ,
            IcountryRepo<District> District
            )
        {
            _employee = employee;
            mapper = Mapper;
            department = Department;
            country = Country;
            city = City;
            district = District;
        }
        public IActionResult Index()
        {
            var data = _employee.AllData();
            var result = mapper.Map<IEnumerable<EmployeeVM>>(data);
            return View(result);
        }
        public IActionResult Details(int id)
        {
            var data = _employee.GetById(id);
            var result = mapper.Map<EmployeeVM>(data);

            var depart = department.AllData();
            ViewBag.departmentList = new SelectList(depart, "Id", "DepartmentName", result.DepartmentId);
            return View(result);
        }

        public IActionResult Creat()
        {
            var data = department.AllData();
            ViewBag.departmentList = new SelectList(data, "Id", "DepartmentName");


            ViewBag.CountryList = new SelectList(country.GetAll() , "Id", "CountryName");

            return View();
        }

        [HttpPost]
        public IActionResult Creat(EmployeeVM obj)
        {

            if (ModelState.IsValid)
            {

                var PhotoName =  FileUpload.upload("Other/Photo" , obj.Photo);

                var data = mapper.Map<Employee>(obj);
                data.PhotoPath = PhotoName;
                _employee.Creat(data);
                return RedirectToAction("Index");
            }

            return View();


        }

        public IActionResult Delete(int id)
        {
            var data = _employee.GetById(id);
            FileUpload.DeleteFiles("Other/Photo/", data.PhotoPath);
            _employee.Delete(data);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var data = _employee.GetById(id);
            var result = mapper.Map<EmployeeVM>(data);

            var depart = department.AllData();
            ViewBag.departmentList = new SelectList(depart, "Id", "DepartmentName", result.DepartmentId);
            return View(result);
        }

        [HttpPost]
        public IActionResult Update(EmployeeVM obj)
        {
            if (ModelState.IsValid)
            {
                var data = mapper.Map<Employee>(obj);
                _employee.Updata(data);
                return RedirectToAction("Index");
            }

            return View();
        }


        #region AjaxCall


        [HttpPost]
        public JsonResult GetCity(int CountryId)
        {
            var data = city.GetAll().Where(a=> a.CountryId == CountryId);
            var data1 = mapper.Map<IEnumerable<CityVM>>(data);
            return Json(data1);
        }


        [HttpPost]
        public JsonResult GetDistrict(int CityId)
        {
            var data = district.GetAll().Where(a => a.CityId == CityId);
            var data1 = mapper.Map<IEnumerable<DistrictVM>>(data);
            return Json(data1);
        }



        #endregion

    }
}
