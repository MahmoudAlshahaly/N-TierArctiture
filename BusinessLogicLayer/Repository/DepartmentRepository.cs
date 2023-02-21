using AutoMapper;
using BusinessLogicLayer.Interface;
using BusinessLogicLayer.Models;
using DataAccessLayer.DataBaseContext;
using DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DBContext db;
        private readonly IMapper mapper;

        public DepartmentRepository(DBContext db,IMapper _mapper)
        {
            this.db = db;
            mapper = _mapper;
        }
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
            //Department d = new Department();
            //d.name = dpt.name;
            //d.code = dpt.code;

            var d = mapper.Map<Department>(dpt);
            db.Departments.Add(d);
            db.SaveChanges();
        }

        public void Delete(int id)
        {    
            //var d = db.Departments.Find(id);
            Department d = db.Departments.Where(a => a.id==id).FirstOrDefault();
            db.Departments.Remove(d);
            db.SaveChanges();
        }
        public void Update(DepartmentVM dpt)
        {
            //var d = db.Departments.Find(id);
            //d.name = dpt.name;
            //d.code = dpt.code;

            //Department d = db.Departments.Where(a => a.id == dpt.id).FirstOrDefault();
            //d.name = dpt.name;
            //d.code = dpt.code;

            var d = mapper.Map<Department>(dpt);
            db.Entry(d).State = EntityState.Modified;

            db.SaveChanges();
        }
    }
}
