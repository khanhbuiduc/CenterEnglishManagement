using CenterEnglishManagement.Context;
using CenterEnglishManagement.Models.RelateTable;
using CenterEnglishManagement.Service.IService;
using CenterEnglishManagement.Service.IService.IOtherServices;
using CenterEnglishManagement.Service.IService.IRelativeTableServices;

namespace CenterEnglishManagement.Service.RelativeTableServices
{
    public class StudentParentServices : CommonServices<StudentParent>,IStudentParentServices
    {
        private readonly ApplicationDbContext _context;
        public StudentParentServices(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
    }
}
