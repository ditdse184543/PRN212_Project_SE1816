using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    internal interface IRoleRepository
    {
        public List<Role> getAll();
        public void Delete(int id);
        public void Update(Role Role);
        public Role findById(int id);
        public void Insert(Role Role);
    }
}

