using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly Prn212Context _context;
        public BookingRepository()
        {

            _context = new Prn212Context();

        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Booking findById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Booking> getAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Booking Booking)
        {
            _context.Bookings.Add(Booking);
            _context.SaveChanges();
        }

        public void Update(Booking Booking)
        {
            throw new NotImplementedException();
        }
    }
}
