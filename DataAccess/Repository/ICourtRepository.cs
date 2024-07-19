using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ICourtRepository
    {
        public List<Court> getAll();
        public void Delete(int id);
        public void Update(Court Court);
        public Court findById(int id);
        public void Insert(Court Court);
        public List<Court> LoadCourtBasedOnBooking(int userId);
        public List<Court> findBySearch(string search);
        public List<Court> search(string search);
    }
}
