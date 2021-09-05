using AutoMapper;
using B_Layer.Interface;
using B_Layer.Models;
using DAL_Layer.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinaL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly Interface<Department> department;
        private readonly IMapper mapper;

        public DepartmentController(Interface<Department> Department , IMapper Mapper)
        {
            department = Department;
            mapper = Mapper;
        }

        public IActionResult Index()
        {
            var data = department.AllData();
            var result = mapper.Map<IEnumerable<DepartmentVM>>(data);
            return View(result);
        }

        public IActionResult Details(int id)
        {
            var data = department.GetById(id);
            var result = mapper.Map<DepartmentVM>(data);
            return View(result);
        }

        public IActionResult Creat()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Creat(DepartmentVM obj)
        {
            if (ModelState.IsValid)
            {
                var data = mapper.Map<Department>(obj);
                department.Creat(data);
            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            var data = department.GetById(id);
            department.Delete(data);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var data = department.GetById(id);
            var result = mapper.Map<DepartmentVM>(data);
            return View(result);
        }

        [HttpPost]
        public IActionResult Update(DepartmentVM obj)
        {
            if (ModelState.IsValid)
            {
                var data = mapper.Map<Department>(obj);
                department.Updata(data);
                return RedirectToAction("Index");
            }

            return View();
        }
    }


}
