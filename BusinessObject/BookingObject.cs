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
    }
}
