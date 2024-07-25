using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private Prn212Context _context;
        public PaymentRepository()
        {

            _context = new Prn212Context();

        }
        public List<Payment> getAllByUserId(int userId)
        {
            return null;
        }
    }
}
