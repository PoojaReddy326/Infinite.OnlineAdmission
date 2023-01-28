using Infinite.OnlineAdmission.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Infinite.OnlineAdmission.Repository.IRepository;

namespace Infinite.OnlineAdmission.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _Context;

        public PaymentRepository(ApplicationDbContext context)
        {
            _Context = context;
        }

        [HttpGet("GetPayments")]
        public IEnumerable<Payment> DisplayPayments()
        {
            return _Context.Payment.ToList();
        }

        public async Task<Payment> GetById(int id)
        {
            var payment = await _Context.Payment.FindAsync(id);
            if(payment != null)
            {
                return payment;
            }
            return null;
        }
    }
}
