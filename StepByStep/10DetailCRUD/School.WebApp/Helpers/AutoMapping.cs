using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.WebApp.Helpers
{
    using AutoMapper;
    using EFCore.Models;
    using School.WebApp.AdapterModels;

    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Outline, OutlineAdapterModel>();
            CreateMap<OutlineAdapterModel, Outline>();
            CreateMap<Course, CourseAdapterModel>();
            CreateMap<CourseAdapterModel, Course>();
            CreateMap<Department, DepartmentAdapterModel>();
            CreateMap<DepartmentAdapterModel, Department>();
        }
    }
}
