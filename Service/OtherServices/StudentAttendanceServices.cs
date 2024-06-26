using CenterEnglishManagement.Context;
using CenterEnglishManagement.Models.OtherModels;
using CenterEnglishManagement.Service.IService.IOtherServices;

namespace CenterEnglishManagement.Service.OtherServices
{
    public class StudentAttendanceServices:CommonServices<StudentAttendance>,IStudentAttendanceServices
    {
        private readonly ApplicationDbContext _context;
        public StudentAttendanceServices(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
    }
}
