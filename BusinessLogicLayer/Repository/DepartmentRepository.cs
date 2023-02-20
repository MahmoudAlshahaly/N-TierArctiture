using BusinessLogicLayer.Interface;
using BusinessLogicLayer.Models;
using DataAccessLayer.DataBaseContext;
using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        DBContext db = new DBContext();



        public IQueryable<DepartmentVM> GetAll()
        {
            var data = db.Departments.Select(a => new DepartmentVM { id = a.id, name = a.name, code = a.code });
            return data;
        }

        public DepartmentVM GetByID(int id)
        {
            var data = db.Departments.Select(a => new DepartmentVM { id = a.id, name = a.name, code = a.code }).Where(b=>b.id==id).FirstOrDefault();
            return data;
        }
        public void Add(DepartmentVM dpt)
        {
            //mapping
            Department d = new Department();
            d.name = dpt.name;
            d.code = dpt.code;
            db.Departments.Add(d);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Department d = db.Departments.Where(a => a.id==id).FirstOrDefault();
            db.Departments.Remove(d);
            db.SaveChanges();
        }
        public void Update(DepartmentVM dpt)
        {
            Department d = db.Departments.Where(a => a.id == dpt.id).FirstOrDefault();
            d.id = dpt.id;
            d.name = dpt.name;
            d.code = dpt.code;
            db.SaveChanges();
        }
    }
}
