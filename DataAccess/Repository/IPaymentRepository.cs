using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IPaymentRepository
    {
        public Payment? GetPaymentById(int id);
        public List<Payment> GetAllPayment();
        public void InsertPayment(Payment payment);
        public void UpdatePayment(Payment payment);
        public void DeletePayment(int id);
        public InvoiceViewModel CreateInvoiceView(int bookingId);
        List<Payment> getAllByUserId(int userId);
    }
}
