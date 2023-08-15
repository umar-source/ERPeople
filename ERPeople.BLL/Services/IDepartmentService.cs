using ERPeople.BLL.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPeople.BLL.Services
{
    public interface IDepartmentService
    {
        void CreateDepartment(DepartmentDto depDto);
        void DeleteDepartment(int id);
        IEnumerable<DepartmentDto> GetAllDepartment();
        DepartmentDto GetDepartmentById(int id);
        void UpdateDepartment(DepartmentDto departmentDto);
    }
}
