using AutoMapper;
using ERPeople.BLL.ModelsDto;
using ERPeople.DAL.Models;
using ERPeople.DAL.UnitOfWork;
using System.Runtime.Intrinsics.Arm;

namespace ERPeople.BLL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public IEnumerable<DepartmentDto> GetAllDepartment()
        {
            var employees = _unitOfWork.DepartmentRepo.GetAll();
            return _mapper.Map<IEnumerable<DepartmentDto>>(employees);
        }

        public DepartmentDto GetDepartmentById(int id)
        {
            var department = _unitOfWork.DepartmentRepo.GetById(id);
            return _mapper.Map<DepartmentDto>(department);
        }

        public void CreateDepartment(DepartmentDto depDto)
        {
            var department = _mapper.Map<Department>(depDto);
            _unitOfWork.DepartmentRepo.Add(department);
            _unitOfWork.Commit();
        }

        public void UpdateDepartment(DepartmentDto depDto)
        {
            var existingDep = _unitOfWork.DepartmentRepo.GetById(depDto.DepartmentId);
            if (existingDep == null)
            {
                // Handle not found...
                 throw new Exception("Department Not Found");
            }

            existingDep.DepartmentName = depDto.DepartmentName;
            existingDep.CreatedDate = depDto.CreatedDate;
            existingDep.Description = depDto.Description;
            existingDep.ManagerName = depDto.ManagerName;

            _unitOfWork.DepartmentRepo.Update(existingDep);
            _unitOfWork.Commit();
        }

        public void DeleteDepartment(int id)
        {
            var department = _unitOfWork.DepartmentRepo.GetById(id);
            if (department != null)
            {
                _unitOfWork.DepartmentRepo.Delete(department);
                _unitOfWork.Commit();
            }
        }

    }
}
