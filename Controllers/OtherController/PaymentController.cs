using CenterEnglishManagement.Models.OtherModels;
using CenterEnglishManagement.Service.IService.IOtherServices;
using CenterEnglishManagement.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet("total")]
        public IActionResult TotalPayments()
        {
            var entity = _services.CalculateTotalPayments();
            return Ok(entity);
        }
        [HttpGet("total/{idStudent}")]

        public IActionResult PaymentsForStudent(int idStudent)
        {
            var entity = _services.CalculateTotalPaymentsForStudent(idStudent);
            return Ok(entity);
        }
    }
}
