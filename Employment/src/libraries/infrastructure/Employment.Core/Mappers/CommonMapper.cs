using AutoMapper;
using Employment.Model.Entities;
using Employment.Service.Models.ViewModel;

namespace Employment.Core.Mappers;

public class CommonMapper :Profile
{
    public CommonMapper()
    {
       CreateMap<VMCountry,Country>().ReverseMap();
       CreateMap<VMCity,City>().ReverseMap();
       CreateMap<VMState,State>().ReverseMap();
       CreateMap<VMEmployee, Employee>().ReverseMap();
       CreateMap<VMDepartment, Department>().ReverseMap();
    }
}
