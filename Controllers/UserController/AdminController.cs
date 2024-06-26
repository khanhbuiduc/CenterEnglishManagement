using CenterEnglishManagement.Dto.ModelDto.OtherModelDto;
using CenterEnglishManagement.Dto.ModelDto.UserModelDto;
using CenterEnglishManagement.Extentions;
using CenterEnglishManagement.Models.OtherModels;
using CenterEnglishManagement.Models.UserModels;
using CenterEnglishManagement.Service;
using CenterEnglishManagement.Service.IService;
using CenterEnglishManagement.Service.IService.IOtherServices;
using CenterEnglishManagement.Service.IService.IUserServices;
using CenterEnglishManagement.Service.UserServices;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace CenterEnglishManagement.Controllers.UserController
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController:ControllerBase
    {

        private readonly IUserService _userServices;
        public AdminController( IUserService adminServices)
        {
            _userServices = adminServices;
        }
       
    }
}
