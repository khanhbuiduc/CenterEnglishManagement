using CenterEnglishManagement.Models.OtherModels;
using CenterEnglishManagement.Service.IService.IOtherServices;
using CenterEnglishManagement.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace CenterEnglishManagement.Controllers.OtherController
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController:CommonController<Payment>
    {
        private readonly IPaymentServices _services;
        public PaymentController(ICommonServices<Payment> commonServices, IPaymentServices services):base(commonServices)
        {
            _services = services;
        }
    }
}
