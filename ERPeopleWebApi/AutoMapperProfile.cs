using AutoMapper;
using ERPeople.BLL.ModelsDto;
using ERPeople.DAL.Models;

namespace ERPeopleWebApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {           
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Attendance, AttendanceDto>().ReverseMap();
        }
    }
}
