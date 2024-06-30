using CenterEnglishManagement.Models.RelateTable;
using CenterEnglishManagement.Models.UserModels;

namespace CenterEnglishManagement.Service.IService.IRelativeTableServices
{
    public interface IStudentParentServices:ICommonServices<StudentParent>
    {
        User GetParentByStudentId(int studentId);
       List<User> GetStudentsByParentId(int parentId);
    }
}
