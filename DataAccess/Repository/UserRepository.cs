using DataAccess.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Prn212Context _context;
        public UserRepository()
        {

            _context = new Prn212Context();

        }
        public void Delete(int id)
        {
            
            
        }
        public User findByName(string username)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == username);
        }

        public User findByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }
        public User findByEmailAndPass(string email,string pass)
        {
            return _context.Users.FirstOrDefault(u=>u.Email==email&&u.Password==pass);
        }
        public User findById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == id);
            
        }

        public List<User> getAll()
        {
            return _context.Users.ToList();
        }

        public void Insert(User User)
        {
            _context.Users.Add(User);
            _context.SaveChanges();

        }

        public User Login(string username, string password)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
        }

        public void Update(User User)
        {
            _context.Users.Update(User);
            _context.SaveChanges();
        }

    }
}
