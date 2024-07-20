using CenterEnglishManagement.Context;
using CenterEnglishManagement.Dto.ModelDto;
using CenterEnglishManagement.Models.OtherModels;
using CenterEnglishManagement.Service.IService.IOtherServices;
using Microsoft.EntityFrameworkCore;

namespace CenterEnglishManagement.Service.OtherServices
{
    public class StudentAttendanceServices:CommonServices<StudentAttendance>,IStudentAttendanceServices
    {
        private readonly ApplicationDbContext _context;
        public StudentAttendanceServices(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
        public async Task<int[]> GetMonthlyStudentAttendanceAsync(int year)
        {

            var monthlyStatistics = new int[12];
            var attendanceData =await _context.StudentAttendances.Where(a=>a.Date.Year==year)
                .GroupBy(a => new { a.Date.Year, a.Date.Month })
                .Select(g => new MonthlyStudentStatisticDto
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    StudentCount = g.Select(a => a.UserId).Distinct().Count()
                })
                .ToListAsync();
            foreach (var data in attendanceData)
            {
                monthlyStatistics[data.Month - 1] = data.StudentCount;
            }
            return monthlyStatistics;
        }
        public async Task<int[]> GetQuarterlyStudentAttendanceAsync(int year)
        {
            var quaterlyStatistics = new int[4];
            var attendanceData = await _context.StudentAttendances.Where(a=>a.Date.Year==year)
                .GroupBy(a => new
                {
                    a.Date.Year,
                    Quarter = ((a.Date.Month - 1) / 3) + 1
                })
                .Select(g => new QuarterlyStudentStatisticDto
                {
                    Year = g.Key.Year,
                    Quarter = g.Key.Quarter,
                    StudentCount = g.Select(a => a.UserId).Distinct().Count()
                })
                .ToListAsync();
            foreach (var data in attendanceData)
            {
                quaterlyStatistics[data.Quarter - 1] = data.StudentCount;
            }
            return quaterlyStatistics;
        }

        public async Task<int[]> GetYearlyStudentAttendanceAsync(int year)
        {
            var yearlyStatistics = new int[1];
            var attendanceData = await _context.StudentAttendances.Where(a=> a.Date.Year == year)
                .GroupBy(a => a.Date.Year)
                .Select(g => new YearlyStudentStatisticDto
                {
                    Year = g.Key,
                    StudentCount = g.Select(a => a.UserId).Distinct().Count()
                })
                .ToListAsync();
            foreach(var data in attendanceData)
            {
                yearlyStatistics[0] = data.StudentCount;
            }
            return yearlyStatistics;
        }

        /*public async Task*/
    }
}
