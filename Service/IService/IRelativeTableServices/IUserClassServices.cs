using CenterEnglishManagement.Models.OtherModels;
using CenterEnglishManagement.Models.RelateTable;
using CenterEnglishManagement.Models.UserModels;

namespace CenterEnglishManagement.Service.IService.IRelativeTableServices
{
    public interface IUserClassServices: ICommonServices<UserClass>
    {
        Task<IEnumerable<Class>> GetClassesByUserIdAsync(int userId);
        Task<IEnumerable<User>> GetUsersByClassIdAsync(int classId);
    }
}
