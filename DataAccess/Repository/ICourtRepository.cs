using DataAccess.Models;
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
    }
}
