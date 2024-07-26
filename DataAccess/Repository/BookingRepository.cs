﻿using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
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

        public Booking getFlexible(int courtId, int userId)
        {
            return _context.Bookings.FirstOrDefault(x => x.BTotalHours.HasValue && x.BTotalHours > 0 && x.CoId == courtId && x.UserId == userId);
        }

        public void Insert(Booking Booking)
        {
            _context.Bookings.Add(Booking);
            _context.SaveChanges();
        }

        public void Update(Booking Booking)
        {
            _context.Bookings.Update(Booking);
        }
        public List<Booking> showListBookingBasedOnCourt(int courtId, int userid)
        {
            return _context.Bookings.Where(b => b.CoId == courtId && b.UserId == userid).Include(b => b.TimeSlots).ToList();
        }
        public List<Booking> SearchBooking(string search, int courtId, int userId)
        {
            var query = _context.Bookings
                .Include(b => b.TimeSlots)
                .Where(b => b.CoId == courtId && b.UserId == userId);

            if (!string.IsNullOrEmpty(search))
            {
                if (int.TryParse(search, out int numericSearch))
                {
                    query = query.Where(b => b.BId == numericSearch ||
                                             b.TimeSlots.Any(ts => ts.TsId == numericSearch));
                }
                else
                {
                    query = query.Where(b => b.BBookingType.Contains(search) ||
                                             b.TimeSlots.Any(ts => ts.TsCheckedIn.ToString().Contains(search) || ts.TsTime.ToString().Contains(search)));
                }
            }

            return query.ToList();
        }

        public List<Booking> getAll()
        {
            throw new NotImplementedException();
        }

        public double getPrice(int courtId)
        {
            return _context.Courts.FirstOrDefault(x => x.CoId == courtId).CoPrice.Value;
        }

        public List<int> FindBookingIdByUser(int userId)
        {
            return _context.Bookings.Where(b => b.UserId == userId).Select(b => b.BId).ToList();
        }

        public int NewestBookingIdJustCreatedByUser(List<int>BeforInsert, List<int> AfterInsert)
        {
            return AfterInsert.Except(BeforInsert).FirstOrDefault();
        }
    }
}
