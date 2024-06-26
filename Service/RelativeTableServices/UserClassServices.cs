using CenterEnglishManagement.Context;
using CenterEnglishManagement.Models.OtherModels;
using CenterEnglishManagement.Models.RelateTable;
using CenterEnglishManagement.Models.UserModels;
using CenterEnglishManagement.Service.IService.IRelativeTableServices;
using Microsoft.EntityFrameworkCore;

namespace CenterEnglishManagement.Service.RelativeTableServices
{
    public class UserClassServices: CommonServices<UserClass>,IUserClassServices
    {
        private readonly ApplicationDbContext _context;
        public UserClassServices(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Class>> GetClassesByUserIdAsync(int userId)
        {
            
            return await _context.UserClasses
                .Where(uc => uc.UserId == userId)
                .Select(uc => uc.Class!)
                .ToListAsync();
        }
        public async Task<IEnumerable<User>> GetUsersByClassIdAsync(int classId)
        {
            return await _context.UserClasses
                .Where(uc => uc.ClassId == classId)
                .Select(uc => uc.User!)
                .ToListAsync();
        }
    }
}
