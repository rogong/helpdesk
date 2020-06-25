using AutoMapper;
using CallogApp.Dtos;
using CallogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallogApp.Utility
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Request, RequestToReturnDto>()
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.Name))
                .ForMember(d => d.Department, o => o.MapFrom(s => s.Department.Name))
                .ForMember(d => d.Issue, o => o.MapFrom(s => s.Issue.Name))
                .ForMember(d => d.Device, o => o.MapFrom(s => s.Device.Name))
              
                .ForMember(d => d.ITStaff, o => o.MapFrom(s => s.ITStaff.Name));

    
        }
    }
}
