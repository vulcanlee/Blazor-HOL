using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLab.Helpers
{
    using AutoMapper;
    using EFCoreModel.Models;
    using SyncfusionLab.AdaptorModels;
    using SyncfusionLab.RazorModels;

    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Person, PersonAdaptorModel>();
            CreateMap<PersonAdaptorModel, Person>();
            CreateMap<Department, DepartmentAdapterModel>();
            CreateMap<DepartmentAdapterModel, Department>();
        }
    }
}
