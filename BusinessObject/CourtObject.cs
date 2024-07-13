using DataAccess.Models;
using DataAccess.Repository;
using System;
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
        public void Delete(int id)
        {
          _courtRepository.Delete(id);
        }
        public void Update(Court court)
        {
            _courtRepository.Update(court);
        }
    }
}
