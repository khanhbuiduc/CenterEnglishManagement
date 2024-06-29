using CenterEnglishManagement.Context;
using CenterEnglishManagement.Dto.ModelDto.OtherModelDto;
using CenterEnglishManagement.Models.OtherModels;
using CenterEnglishManagement.Models.UserModels;
using CenterEnglishManagement.Service.IService.IOtherServices;
using Microsoft.EntityFrameworkCore;

namespace CenterEnglishManagement.Service.OtherServices
{
    public class ClassServices: CommonServices<Class>, IClassServices
    {
        private readonly ApplicationDbContext _context;
        public ClassServices(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

       

        public async Task<Schedule> CreateScheduleAsync(Schedule schedule)
        {
            try
            {
                _context.Set<Schedule>().Add(schedule);
                await _context.SaveChangesAsync();
                return schedule;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<TuitionFee> CreateTuitionFeeAsync(TuitionFee tuitionFee)
        {
            try
            {
                _context.Set<TuitionFee>().Add(tuitionFee);
                await _context.SaveChangesAsync();
                return tuitionFee;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
        public async Task<bool> ClassNameExistsAsync(string className, string grade, int year)
        {
            return await _context.Classes.AnyAsync(c => c.ClassName == className && c.Grade == grade && c.Year == year);
        }
        public async Task<UserDto> GetTeacherByClassIdAsync(int classId)
        {
            var classWithTeacher = await _context.Classes
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(c => c.Id == classId);
            var teacher= classWithTeacher?.Teacher;
            return  new UserDto
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Email = teacher.Email,
                IsActive = teacher.IsActive,
                Mobile = teacher.Mobile,
                DOB = teacher.DOB.HasValue?teacher.DOB.Value.ToString("yyyy-MM-dd"):null,
                Gender = teacher.Gender,
                Address = teacher.Address
            };
        }
    }
}
