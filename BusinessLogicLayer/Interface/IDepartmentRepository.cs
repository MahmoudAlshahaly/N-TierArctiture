using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    interface IDepartmentRepository
    {
        IQueryable<DepartmentVM> GetAll();
        DepartmentVM GetByID(int id);
        void Add(DepartmentVM dpt);
        void Delete(int id);
        void Update(DepartmentVM dpt);


    }
}
