using CenterEnglishManagement.Models.OtherModels;
using CenterEnglishManagement.Service.IService;
using CenterEnglishManagement.Service.IService.IOtherServices;
using Microsoft.AspNetCore.Mvc;

namespace CenterEnglishManagement.Controllers.OtherController
{
    [ApiController]
    [Route("api/[controller]")]
    public class TuitionFeeController:CommonController<TuitionFee>
    {
       private readonly ITuitionFeeServices _service;
       public TuitionFeeController(ICommonServices<TuitionFee> commonServices,ITuitionFeeServices service):base(commonServices)
        {
            _service = service;
        }
    }
}
