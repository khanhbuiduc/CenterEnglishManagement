using CenterEnglishManagement.Context;
using CenterEnglishManagement.Models.OtherModels;
using CenterEnglishManagement.Service.IService.IOtherServices;

namespace CenterEnglishManagement.Service.OtherServices
{
    public class ScheduleServices:CommonServices<Schedule>,IScheduleServices
    {
        private readonly ApplicationDbContext _context;
        public ScheduleServices(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
    }
}
