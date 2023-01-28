using Infinite.OnlineAdmission.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Infinite.OnlineAdmission.Repository.IRepository;

namespace Infinite.OnlineAdmission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentsController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        [HttpGet]
        [Route("Payments")]
        public IEnumerable<Payment> GetPayments()
        {
            return _paymentRepository.DisplayPayments();
        }

        [HttpGet]
        [Route("GetPaymentById/{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var payment = await _paymentRepository.GetById(id);
            if(payment != null)
            {
                return Ok(payment);
            }
            return NotFound();
        }
    }
}
