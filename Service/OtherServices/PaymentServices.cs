using CenterEnglishManagement.Context;
using CenterEnglishManagement.Models.OtherModels;
using CenterEnglishManagement.Service.IService.IOtherServices;

namespace CenterEnglishManagement.Service.OtherServices
{
    public class PaymentServices:CommonServices<Payment>,IPaymentServices
    {
        private readonly ApplicationDbContext _context;
        public PaymentServices(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
    }
}
