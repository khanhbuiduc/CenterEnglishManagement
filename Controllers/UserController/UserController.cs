using CenterEnglishManagement.Models.OtherModels;
using CenterEnglishManagement.Service.IService.IOtherServices;
using CenterEnglishManagement.Service.IService;
using Microsoft.AspNetCore.Mvc;
using CenterEnglishManagement.Models.UserModels;
using CenterEnglishManagement.Service.IService.IUserServices;
using CenterEnglishManagement.Extentions;
using CenterEnglishManagement.Service.UserServices;

namespace CenterEnglishManagement.Controllers.UserController
{
    
        [ApiController]
        [Route("api/[controller]")]
        public class UserController : CommonController<User>
        {
            private readonly IUserService _services;
            public UserController(ICommonServices<User> commonServices, IUserService service) : base(commonServices)
            {
                _services = service;
            }
        
        
        [HttpGet("student")]
        public async Task<IActionResult> GetAllStudent(int pageIndex, int pageSize, string sortBy, bool sortDesc)
        {
            var entities = await _services.GetAllStudentAsync(pageIndex, pageSize, sortBy, sortDesc);
            return Ok(entities);
        }
        [HttpGet("role")]
        public async Task<IActionResult> GetAllStudent(int pageIndex, int pageSize, string sortBy, bool sortDesc, UserRole role)
        {
            var entities = await _services.GetAllByRoleAsync(pageIndex, pageSize, sortBy, sortDesc, role);
            return Ok(entities);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _services.GetbyIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
    
}
