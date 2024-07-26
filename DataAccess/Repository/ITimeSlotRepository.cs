using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ITimeSlotRepository
    {
        public List<TimeSlot> getAll();
        public void Delete(int id);
        public void Update(TimeSlot TimeSlot);
        public TimeSlot findById(int id);
        public void Insert(TimeSlot TimeSlot);
        public void Checkin(int id);
        public List<TimeSlot> getByDate(DateOnly date, int courtId);
    }
}
