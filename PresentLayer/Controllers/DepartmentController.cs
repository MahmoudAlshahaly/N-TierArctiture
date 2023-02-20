using BusinessLogicLayer.Models;
using BusinessLogicLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
         DepartmentRepository department = new DepartmentRepository();

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = department.GetAll();

            return Ok(data);
        }
        [HttpGet]
        [Route("[controller]/[action]/{id}")]

        public IActionResult GetByID(int id)
        {
            var data = department.GetByID(id);

            return Ok(data);
        }
        [HttpPost]
        public IActionResult Create(DepartmentVM dpt)
        {
            department.Add(dpt);

            return Ok(dpt);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            department.Delete(id);

            return Ok();
        }
        [HttpPut]
        public IActionResult Update(DepartmentVM dpt)
        {
            department.Update(dpt);

            return Ok(dpt);
        }
    }
}
