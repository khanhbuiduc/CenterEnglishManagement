using AutoMapper;
using CenterEnglishManagement.Dto.ModelDto;
using CenterEnglishManagement.Dto.ModelDto.OtherModelDto;
using CenterEnglishManagement.Models.OtherModels;
using CenterEnglishManagement.Service;
using CenterEnglishManagement.Service.IService;
using CenterEnglishManagement.Service.IService.IOtherServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CenterEnglishManagement.Controllers.OtherController
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentAttendanceController:CommonController<StudentAttendance>
    {
        private readonly IStudentAttendanceServices _StudentAttendanceServices;
        private readonly IMapper _Mapper;
        public StudentAttendanceController(IMapper mapper,ICommonServices<StudentAttendance> commonServices,IStudentAttendanceServices studentAttendanceServices):base(commonServices)
        {
            _StudentAttendanceServices = studentAttendanceServices;
            _Mapper = mapper;

        }
        [HttpPost("class")]
        public async Task<IActionResult> CreateStudentAttendanceByClass(List<StudentAttendanceDto> studentAttendanceDtos) {
            foreach (var attendanceDto in studentAttendanceDtos)
            {
                var studentAttendance = _Mapper.Map<StudentAttendance>(attendanceDto);
                 await _StudentAttendanceServices.CreateAsync(studentAttendance);
            }
            return Ok();

        }


        [HttpGet("monthly")]
        /*[Authorize(Policy = "AdminPolicy")]*/
        public IActionResult GetMonthlyStudent()
        {
            List<MonthlyStudentStatisticDto> entity= _StudentAttendanceServices.GetMonthlyStudentAttendanceAsync();
            return Ok(entity);
        }
        [HttpGet("quarterly")]
        [Authorize(Policy = "StudentPolicy")]
        public IActionResult GetQuarterlyStudent()
        {

            List<QuarterlyStudentStatisticDto> entity = _StudentAttendanceServices.GetQuarterlyStudentAttendanceAsync();
            return Ok(entity);
        }
        [HttpGet("yearly")]
        public IActionResult GetYearlyStudent()
        {
            List<YearlyStudentStatisticDto> entity = _StudentAttendanceServices.GetYearlyStudentAttendanceAsync();
            return Ok(entity);
        }
    }
}
