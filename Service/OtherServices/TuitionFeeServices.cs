using CenterEnglishManagement.Context;
using CenterEnglishManagement.Models.OtherModels;
using CenterEnglishManagement.Service.IService.IOtherServices;

namespace CenterEnglishManagement.Service.OtherServices
{
    public class TuitionFeeServices:CommonServices<TuitionFee>,ITuitionFeeServices
    {
        private readonly ApplicationDbContext _context;
        public TuitionFeeServices(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
    }
}
