using DataAccess.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{

    public class BookingObject
    {
        private readonly IBookingRepository bookingRepository;
        public BookingObject()
        {
            bookingRepository = new BookingRepository();
        }
        public void Insert(Booking booking)
        {
            bookingRepository.Insert(booking);

        }
        public List<Booking> showListBookingBasedOnCourt(int courtId, int userId)
        {
            return bookingRepository.showListBookingBasedOnCourt(courtId, userId);
        }
        public List<Booking> SearchBooking(string search, int courtId, int userId)
        {
            return bookingRepository.SearchBooking(search, courtId, userId);
        }
        public List<Booking> getAllPaymentByUserId(int userId)
        {
            return bookingRepository.getByUserID(userId);
        }
    }
}
