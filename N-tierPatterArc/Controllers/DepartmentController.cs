using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace N_tierPatterArc.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentRepository department = new DepartmentRepository();
        public IActionResult Index()
        {
            return View();
        }
    }
}
