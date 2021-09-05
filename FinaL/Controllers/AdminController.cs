using B_Layer.Models.Account;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinaL.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult CreatRole()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatRole(CreatRoleVM model)
        {
            return View();
        }
    }
}
