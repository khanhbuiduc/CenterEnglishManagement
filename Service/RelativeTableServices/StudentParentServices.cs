using CenterEnglishManagement.Context;
using CenterEnglishManagement.Models.RelateTable;
using CenterEnglishManagement.Models.UserModels;
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
        public  List<User> GetStudentsByParentId(int parentId)
        {
            
                var students=  _context.StudentParents
                              .Where(sp => sp.ParentId == parentId)
                              .Select(sp => sp.Student)
                              .ToList();

            return students!;
        }
        public User GetParentByStudentId(int studentId)
        { 
            var parent= _context.StudentParents.Where(sp=>sp.StudentId==studentId).Select(sp=>sp.Parent).FirstOrDefault();
            return parent;
        }
        }
}
