using DataAccess;
using DataAccess.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class InvoiceObject
    {
        private readonly IPaymentRepository paymentRepository;

        public InvoiceObject()
        {
            this.paymentRepository = new PaymentRepository();
        }
        public InvoiceViewModel CreateInvoice(int bookingId) => paymentRepository.CreateInvoiceView(bookingId);
    }
}
