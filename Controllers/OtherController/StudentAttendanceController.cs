using CenterEnglishManagement.Models.OtherModels;
using CenterEnglishManagement.Service.IService;
using CenterEnglishManagement.Service.IService.IOtherServices;
using Microsoft.AspNetCore.Mvc;

namespace CenterEnglishManagement.Controllers.OtherController
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentAttendanceController:CommonController<StudentAttendance>
    {
        private readonly IStudentAttendanceServices _StudentAttendanceServices;
        public StudentAttendanceController(ICommonServices<StudentAttendance> commonServices,IStudentAttendanceServices studentAttendanceServices):base(commonServices)
        {
            _StudentAttendanceServices = studentAttendanceServices;
        }
    }
}
