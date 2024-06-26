using CenterEnglishManagement.Dto.ModelDto.OtherModelDto;
using CenterEnglishManagement.Models.OtherModels;
using CenterEnglishManagement.Service.IService;
using CenterEnglishManagement.Service.IService.IOtherServices;
using CenterEnglishManagement.Service.OtherServices;
using Microsoft.AspNetCore.Mvc;

namespace CenterEnglishManagement.Controllers.OtherController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController:CommonController<Class>
    {
        private readonly IClassServices _services;
        public ClassController(ICommonServices<Class> commonServices,IClassServices services):base(commonServices)
        {
            _services = services;
        }
        [HttpPost("class")]
        public async Task<IActionResult> CreateClass([FromBody] ClassDto classDto)
        {
            if (classDto == null)
            {
                return BadRequest();
            }
            bool classNameExists = await _services.ClassNameExistsAsync(classDto.ClassName, classDto.Grade, classDto.Year);
            if (classNameExists)
            {
                return Conflict("A class with the same name already exists for the specified grade and year.");
            }
            var newClass = new Class
            {
                IsActive = classDto.IsActive,
                Grade = classDto.Grade,
                Year = classDto.Year,
                ClassName = classDto.ClassName,
                TeacherId = classDto.TeacherId,
            };
            var createdClass = await _services.CreateAsync(newClass);
            var tuitionFee = new TuitionFee
            {
                Amount = classDto.TuitionFeeAmount,
                ClassId = createdClass.Id
            };
            await _services.CreateTuitionFeeAsync(tuitionFee);
            var schedule = new Schedule
            {
                DateType = classDto.ScheduleDto.DateType,
                Shift = classDto.ScheduleDto.Shift,
                StartTime = classDto.ScheduleDto.StartTime,
                NumOfSession = classDto.ScheduleDto.NumOfSession,
                ClassId = createdClass.Id
            };
            await _services.CreateScheduleAsync(schedule);
            return Ok(classDto);
        }
    }
}
