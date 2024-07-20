using CenterEnglishManagement.Context;
using CenterEnglishManagement.Models.OtherModels;
using CenterEnglishManagement.Service.IService.IOtherServices;
using Microsoft.EntityFrameworkCore;

namespace CenterEnglishManagement.Service.OtherServices
{
    public class PaymentServices:CommonServices<Payment>,IPaymentServices
    {
        private readonly ApplicationDbContext _context;
        public PaymentServices(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
        public int CalculateTotalPayments()
        {
            return _context.Payments.Sum(p => p.Amount);
        }

        // Calculate total payment amount for a specific student by their Id
        public int CalculateTotalPaymentsForStudent(int studentId)
        {
            return _context.Payments.Where(p => p.StudentId == studentId).Sum(p => p.Amount);
        }
        public async Task<int[]> PaymentStatisticAsync(int year)
        {
            var monthlyPaymentStatistic = new int[12];

            // Query Payments data, filter by presence and year, and month, and sum the Payments
            var totalPayments = await _context.Payments
                .Where(t => t.Date.Year == year)
                .GroupBy(t => new { t.Date.Month })
                .Select(g => new
                {
                    g.Key.Month,
                    TotalAmount = g.Sum(p => p.Amount)
                })
                .ToListAsync();



            // Populate the monthly tuition statistics array with the summed fees
            foreach (var data in totalPayments)
            {
                monthlyPaymentStatistic[data.Month - 1] = data.TotalAmount;
            }

            return monthlyPaymentStatistic;
        }
    }
}
