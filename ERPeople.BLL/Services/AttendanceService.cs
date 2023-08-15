using AutoMapper;
using ERPeople.BLL.ModelsDto;
using ERPeople.DAL.Models;
using ERPeople.DAL.UnitOfWork;


namespace ERPeople.BLL.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public AttendanceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        
        public void CheckIn(int employeeId)
        {
            var employee = _unitOfWork.EmployeeRepo.GetById(employeeId);

            if (employee == null)
            {
                throw new Exception("Employee not Found");
            }

            var checkInEntry = new AttendanceDto
            {
                EmployeeId = employee.EmployeeId,
                CheckInTime = DateTime.Now
            };

             var checkIn = _mapper.Map<Attendance>(checkInEntry);

            _unitOfWork.AttendanceRepo.Add(checkIn);
            _unitOfWork.Commit();
        }



        public void CheckOut(int employeeId)
        {
            var employee = _unitOfWork.EmployeeRepo.GetById(employeeId);

            if (employee == null)
            {
                throw new Exception("Employee not Found");
            }

            var checkOutEntry = new AttendanceDto
            {
                EmployeeId = employee.EmployeeId,
                CheckOutTime = DateTime.Now
            };

            var checkOut = _mapper.Map<Attendance>(checkOutEntry);

            _unitOfWork.AttendanceRepo.Add(checkOut);
            _unitOfWork.Commit();
        }


        public IEnumerable<AttendanceDto> GetEmployeeAttendances(int employeeId)
        {
            var attendances = _unitOfWork.AttendanceRepo.GetAttendancesByEmployeeId(employeeId);
            return _mapper.Map<IEnumerable<AttendanceDto>>(attendances);
        }

        public IEnumerable<AttendanceDto> GetLastWeekAttendances(int employeeId)
        {
            var lastWeekStart = DateTime.Now.AddDays(-7);
            var lastWeekAttendances = _unitOfWork.AttendanceRepo.GetAttendancesByEmployeeIdAndDateRange(employeeId, lastWeekStart, DateTime.Now);
            return _mapper.Map<IEnumerable<AttendanceDto>>(lastWeekAttendances);
        }
    }
}
