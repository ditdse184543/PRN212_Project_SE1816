using DataAccess.Models;
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
            throw new NotImplementedException();
        }

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
