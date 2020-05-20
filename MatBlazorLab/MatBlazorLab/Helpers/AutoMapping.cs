using System;
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
        }
    }
}
