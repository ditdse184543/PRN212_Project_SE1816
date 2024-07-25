using DataAccess.Models;
using DataAccess.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class CourtObject
    {
        private readonly ICourtRepository _courtRepository;



        public CourtObject()
        {
            _courtRepository = new CourtRepository();
        }
       public void AddCourt(Court Court)
        {
            _courtRepository.Insert(Court);

        }
        public List<Court> GetAll()
        {
            return _courtRepository.getAll();
        }
        public List<Court> GetCourtBySearch(string search)
        {
            return _courtRepository.findBySearch(search);
        }
        public void Delete(int id)
        {
          _courtRepository.Delete(id);
        }
        public void Update(Court court)
        {
            _courtRepository.Update(court);
        }
        public List<Court> LoadCourtBasedOnBooking(int userId)
        {
            return _courtRepository.LoadCourtBasedOnBooking(userId);
        }
        public List<Court> SearchCourt(string search)
        {
            return _courtRepository.search(search);
        }
        public Court GetCourt(int courtId)
        {
            return _courtRepository.findById(courtId);
        }
        public List<Court> getAllPaymentByUserId(int userId)
        {
            return _courtRepository.getByUserID(userId);
        }

        public IEnumerable getCourtByUserID(int userId)
        {
            return _courtRepository.getCourtByUserID(userId);
        }
    }
}
