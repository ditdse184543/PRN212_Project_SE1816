using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
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
        public List<User> forDataGrid()
        {
            return _context.Users.Include(x => x.Roles).ToList();
        }
        public void Delete(int id)
        {
            try
            {

                User? userToDelete = _context.Users.FirstOrDefault(us => us.UserId == id);
                userToDelete.Status = false;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            };

        }
        public User findByName(string username)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == username);
        }

        public User findByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }
        public User findByEmailAndPass(string email, string pass)
        {
            return _context.Users.Include(u => u.Roles)
                   .FirstOrDefault(u => u.Email == email && u.Password == pass);
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
        public void AddUserAdmin(User User, bool Admin = false, bool Manager = false, bool Staff = false, bool Customer = false)
        {
            if (Admin)
            {
                var AdminRole = _context.Roles.SingleOrDefault(r => r.RoleName == "Admin");
                User.Roles.Add(AdminRole);
            }
            if (Manager)
            {
                var ManagerRole = _context.Roles.SingleOrDefault(r => r.RoleName == "Manager");
                User.Roles.Add(ManagerRole);
            }
            if (Staff)
            {
                var StaffRole = _context.Roles.SingleOrDefault(r => r.RoleName == "Staff");
                User.Roles.Add(StaffRole);
            }
            if (Customer)
            {
                var CustomerRole = _context.Roles.SingleOrDefault(r => r.RoleName == "Customer");
                User.Roles.Add(CustomerRole);
            }

            Insert(User);
        }
    }
}
