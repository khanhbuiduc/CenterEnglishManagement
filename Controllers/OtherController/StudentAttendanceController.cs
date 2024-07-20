using AutoMapper;
using CenterEnglishManagement.Dto.ModelDto;
using CenterEnglishManagement.Dto.ModelDto.OtherModelDto;
using CenterEnglishManagement.Models.OtherModels;
using CenterEnglishManagement.Service;
using CenterEnglishManagement.Service.IService;
using CenterEnglishManagement.Service.IService.IOtherServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        /*[Authorize(Policy = "AdminPolicy")]*/
        public async Task<IActionResult> CreateStudentAttendanceByClass(List<StudentAttendanceDto> studentAttendanceDtos) {
            foreach (var attendanceDto in studentAttendanceDtos)
            {
                var studentAttendance = _Mapper.Map<StudentAttendance>(attendanceDto);
                 await _StudentAttendanceServices.CreateAsync(studentAttendance);
            }
            return Ok();

        }


        [HttpGet("studentStatic/{year}/monthly")]
        /*[Authorize(Policy = "StudentPolicy")]*/
        public async Task<IActionResult> GetMonthlyStudent(int year)
        {
            var entity=await _StudentAttendanceServices.GetMonthlyStudentAttendanceAsync(year);
            return Ok(entity);
        }
        [HttpGet("studentStatic/{year}/quarterly")]
        /*[Authorize(Policy = "StudentPolicy")]*/
        public async Task<IActionResult> GetQuarterlyStudent(int year)
        {

            var entity =await _StudentAttendanceServices.GetQuarterlyStudentAttendanceAsync( year);
            return Ok(entity);
        }
        [HttpGet("studentStatic/{year}")]
        public async Task<IActionResult> GetYearlyStudent(int year)
        {
            var entity =await _StudentAttendanceServices.GetYearlyStudentAttendanceAsync(year);
            return Ok(entity);
        }
    }
}
