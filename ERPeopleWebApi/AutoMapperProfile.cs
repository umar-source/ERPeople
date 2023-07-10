using AutoMapper;
using ERPeople.BLL.ModelsDto;
using ERPeople.DAL.Models;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;

namespace ERPeopleWebApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
           
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            
        }
    }
}
