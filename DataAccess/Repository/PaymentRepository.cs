using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly Prn212Context _context;

        public PaymentRepository()
        {

            _context = new Prn212Context();
        }

        public Payment? GetPaymentById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Payment> GetAllPayment()
        {
            throw new NotImplementedException();
        }
        public List<Payment> getAllByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public void InsertPayment(Payment payment)
        {
            throw new NotImplementedException();
        }

        public void UpdatePayment(Payment payment)
        {
            throw new NotImplementedException();
        }

        public void DeletePayment(int id)
        {
            throw new NotImplementedException();
        }

        public Payment? GetPaymentByBookingId(int bookingId)
        {
            return _context.Payments.FirstOrDefault(p => p.BId == bookingId);
        }

        public InvoiceViewModel CreateInvoiceView(int bookingId)
        {
            InvoiceViewModel ViewModel = null;
            Payment payment =  _context.Payments.FirstOrDefault(p => p.BId == bookingId);
            if (payment != null)
            {
                string formattedDate = payment.PDateTime.ToString("MMMM dd, yyyy");
                string formattedTime = payment.PDateTime.ToString("hh:mm tt");
                var booking = _context.Bookings.Include(b => b.TimeSlots).FirstOrDefault(b => b.BId == bookingId);
                string typeOfBooking = booking.BBookingType;
                string courtName = _context.Courts.FirstOrDefault(c => c.CoId == booking.CoId).CoName;
                int? quantity;
                if (booking.BBookingType == "Flexible")
                {
                    quantity = booking.BTotalHours;
                }
                else
                {
                    quantity = booking.TimeSlots.Count;
                }
                string UserName = _context.Users.SingleOrDefault(u => u.UserId == booking.UserId).UserName;
                ViewModel = new InvoiceViewModel()
                {
                    PId = payment.PId,
                    formattedDate = formattedDate,
                    formattedTime = formattedTime,
                    toUser = UserName,
                    typeOfBooking = typeOfBooking,
                    courtName = courtName,
                    amount = payment.PAmount,
                    Quantity = quantity
                };
            }
            return ViewModel;
        }
    }
}
