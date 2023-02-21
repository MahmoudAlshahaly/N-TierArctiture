using BusinessLogicLayer.Models;
using BusinessLogicLayer.Repository;
using BusinessLogicLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentLayer.Controllers
{
   // [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        //loosly coupled
        //
        private readonly IDepartmentRepository department;
        public DepartmentController(IDepartmentRepository department)
        {
            this.department = department;
        }
        //tightly coupled  اي تغير في الكلاس بتاع الريبو دبرت منت  هياثر
        //عليه هنا يعني لو جيت ف دالة وعدلت ف البدي بتاعها هتاثر عليه
        //هنا  علي العاكس ف اللوزلي كبل مش هيبقي فيه تاثير مباشر ولاكن هيبقي فيه تاثير بردة بس غير مباشر   
        ////private readonly DepartmentRepository department;
        //inject object in ctor
        //علشان اخلي الاوبجكت الا جوة الكونستراكتور ال انا حقتنة ده
        //وعملت الانستانس بتاعة ف ال استارت اب عشان اخلية متشاف علي مستوي الكونترولر
        //فكنت مضطر اعمل اوبجكت جديد الا هوه الريد اونلين واسوية بيه داخل الكونستراكتور علشان الكل يبقة شايفة 
        ////public DepartmentController(DepartmentRepository department)
        ////{
        ////    this.department = department;
        ////}
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
            if (ModelState.IsValid)
            {
                department.Update(dpt);
            }
            else
            {
                return BadRequest();
            }
            return Ok(dpt);
        }
    }
}
