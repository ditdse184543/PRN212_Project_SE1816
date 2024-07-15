using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private Prn212Context _context;
        public RatingRepository()
        {

            _context = new Prn212Context();

        }
        public Court getCourtDetail(int courtId)
        {
            return _context.Courts.FirstOrDefault(c => c.CoId == courtId);
        }
        public void Add(Rating rating)
        {
            _context.Ratings.Add(rating);
            _context.SaveChanges();
        }
    }
}
