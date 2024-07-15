using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IBookingRepository
    {
        public List<Booking> getAll();
        public void Delete(int id);
        public void Update(Booking Booking);
        public Booking findById(int id);
        public void Insert(Booking Booking);
        public List<Booking> showListBookingBasedOnCourt(int courtId, int userid);
        public List<Booking> SearchBooking(string search, int courtId, int userId);
    }
}
