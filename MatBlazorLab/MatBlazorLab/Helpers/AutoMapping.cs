﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatBlazorLab.Helpers
{
    using AutoMapper;
    using EFCoreModel.Models;
    using MatBlazorLab.AdaptorModels;

    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Person, PersonAdaptorModel>();
            CreateMap<PersonAdaptorModel, Person>();
            CreateMap<Department, DepartmentAdaptorModel>();
            CreateMap<DepartmentAdaptorModel, Department>();
            CreateMap<Course, CourseAdaptorModel>();
            CreateMap<CourseAdaptorModel, Course>();
            CreateMap<Outline, OutlineAdaptorModel>();
            CreateMap<OutlineAdaptorModel, Outline>();
            CreateMap<StudentGrade, StudentGradeAdaptorModel>();
            CreateMap<StudentGradeAdaptorModel, StudentGrade>();
        }
    }
}
