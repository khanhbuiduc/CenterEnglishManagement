using CenterEnglishManagement.Context;
using CenterEnglishManagement.Models.OtherModels;
using CenterEnglishManagement.Service.IService.IOtherServices;
using Microsoft.EntityFrameworkCore;

namespace CenterEnglishManagement.Service.OtherServices
{
    public class TuitionFeeServices:CommonServices<TuitionFee>,ITuitionFeeServices
    {
        private readonly ApplicationDbContext _context;
        public TuitionFeeServices(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
        public int GetTuitionFeeAmountByClassId(int classId)
        {
        var tuitionFee = _context.TuitionFees
            .FirstOrDefault(tf => tf.ClassId == classId);

        return tuitionFee.Amount;
        }
        public decimal CalculateTotalTuitionFees()
        {
            var totalFees = (from attendance in _context.StudentAttendances
                             where attendance.IsPresent
                             join userClass in _context.UserClasses on attendance.UserId equals userClass.UserId
                             join tuitionFee in _context.TuitionFees on userClass.ClassId equals tuitionFee.ClassId
                             select tuitionFee.Amount).Sum();

            return totalFees;
        }
        public async Task<int[]> TuitionFeeStatisticAsync(int year)
        {
            var monthlyTuitionStactic = new int[12];

            // Query attendance data, filter by presence and year, group by year and month, and sum the fees
            var totalFees = await (from attendance in _context.StudentAttendances
                                   where attendance.IsPresent && attendance.Date.Year == year
                                   join userClass in _context.UserClasses on attendance.UserId equals userClass.UserId
                                   join tuitionFee in _context.TuitionFees on userClass.ClassId equals tuitionFee.ClassId
                                   group tuitionFee by new { attendance.Date.Year, attendance.Date.Month } into g
                                   select new
                                   {
                                       g.Key.Month,
                                       TuitionSum = g.Sum(tf => tf.Amount)
                                   }).ToListAsync();

            // Populate the monthly tuition statistics array with the summed fees
            foreach (var data in totalFees)
            {
                monthlyTuitionStactic[data.Month - 1] = data.TuitionSum;
            }

            return monthlyTuitionStactic;
        }
        public decimal CalculateTotalTuitionFeeForUser(int userId)
        {
            var totalFee = (from attendance in _context.StudentAttendances
                            where attendance.IsPresent && attendance.UserId == userId
                            join userClass in _context.UserClasses on attendance.UserId equals userClass.UserId
                            join tuitionFee in _context.TuitionFees on userClass.ClassId equals tuitionFee.ClassId
                            select tuitionFee.Amount).Sum();

            return totalFee;
        }
    }
}
