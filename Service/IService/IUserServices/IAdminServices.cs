using CenterEnglishManagement.Models.UserModels;
using System.Collections.Generic;

namespace CenterEnglishManagement.Service.IService.IUserServices
{
    public interface IAdminServices
    {
        Task CreateAdminAsync(Admin admin);
        Task DeleteAdminAsync(Admin admin);
        Task UpdateAdminAsync(Admin admin);
        Task<Admin> GetAdminByIdAsync(int adminId);
        Task<IEnumerable<Admin>> GetAllAdminAsync(int pageIndex, int pageSize);
    }
}
