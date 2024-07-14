using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class TimeslotRepository : ITimeSlotRepository
    {
        private readonly Prn212Context _context;
        public TimeslotRepository()
        {

            _context = new Prn212Context();

        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TimeSlot findById(int id)
        {
            throw new NotImplementedException();
        }

        public List<TimeSlot> getAll()
        {
            return _context.TimeSlots.Include(ts => ts.BIdNavigation).Include(ts => ts.Co).ToList();
        }


            //var data = timeslot.Select(ts => new
            //{
            //    TS_ID = ts.TsId,
            //    CO_Name = ts.Co.CoName,
            //    B_ID = ts.BIdNavigation.BId,
            //    TS_Date = ts.TsDate,
            //    TS_Start = ts.TsStart,

            //});



        public void Insert(TimeSlot TimeSlot)
        {
            _context.TimeSlots.Add(TimeSlot);
            _context.SaveChanges();
        }

        public void Update(TimeSlot TimeSlot)
        {
            throw new NotImplementedException();
        }
    }
}
