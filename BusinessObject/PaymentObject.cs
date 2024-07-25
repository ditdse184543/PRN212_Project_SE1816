using DataAccess.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class PaymentObject
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentObject()
        {
            _paymentRepository = new PaymentRepository();
        }
        public List<Payment> getAll(int userId)
        {
            return _paymentRepository.getAllByUserId(userId);   
        }
    }
}
