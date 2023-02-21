using AutoMapper;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_tierPatterArc.AutoMapping
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<Department, DepartmentVM>();
            CreateMap<DepartmentVM, Department>();
        }
    }
}
