using DataAccess.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    
    public class RatingObject
    {
        private readonly IRatingRepository _ratingRepository;
        public RatingObject()
        {
            _ratingRepository = new RatingRepository();
        }
        public Court getCourtDetail(int courtId)
        {
         return _ratingRepository.getCourtDetail(courtId);
        }
        public void SubmitRating(Rating rating)
        {
            _ratingRepository.Add(rating);
        }
    }
}
