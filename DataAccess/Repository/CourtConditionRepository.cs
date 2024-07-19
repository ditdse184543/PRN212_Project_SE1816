using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CourtConditionRepository : ICourtConditionRepository
    {
        private readonly Prn212Context _context;

        public CourtConditionRepository()
        {
            _context = new Prn212Context();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CourtCondition findById(int id)
        {
            throw new NotImplementedException();
        }

        public List<CourtCondition> getAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(CourtCondition CourtCondition)
        {
            _context.CourtConditions.Add(CourtCondition);
            _context.SaveChanges();
        }

        public List<Court> LoadCourtBasedOnBooking(int userId)
        {
            throw new NotImplementedException();
        }

        public void Update(CourtCondition CourtCondition)
        {
            throw new NotImplementedException();
        }
    }
}
