using DataAccess.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class TimeSlotObject
    {

        private readonly ITimeSlotRepository timeSlotRepository;
        public TimeSlotObject()
        {
            timeSlotRepository = new TimeslotRepository();
        }
        public List<TimeSlot> GetAllTimeSlots() => timeSlotRepository.getAll();
        public void Checkin(int tsId) => timeSlotRepository.Checkin(tsId);
        public List<TimeSlot> getByDate(DateOnly date)
        {
            return timeSlotRepository.getByDate(date);
        }

    }
}
