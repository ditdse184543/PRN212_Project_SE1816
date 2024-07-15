using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRatingRepository
    {
        public Court getCourtDetail(int courtId);
        public void Add(Rating rating);
        
    }
}
