using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ICourtConditionRepository
    {
        public List<CourtCondition> getAll();
        public void Delete(int id);
        public void Update(CourtCondition CourtCondition);
        public CourtCondition findById(int id);
        public void Insert(CourtCondition CourtCondition);
        public List<Court> LoadCourtBasedOnBooking(int userId);
    }
}

