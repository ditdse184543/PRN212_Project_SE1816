using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IUserRepository
    {
        public User Login(string username, string password);
        public List<User> getAll();
        public void Delete(int id);
        public void Update(User User);
        public User findById(int id);
        public void Insert(User User);
        public User findByEmail(string email);
        public User findByName(string username);
        public User findByEmailAndPass(string email, string pass);
    }
}
