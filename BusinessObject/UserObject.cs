using DataAccess.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class UserObject
    {
        private readonly IUserRepository _userRepository;

       

        public UserObject()
        {
          _userRepository = new UserRepository();
        }
        public void Register(User User)
        {
            _userRepository.Insert(User);
        }
        public User Login(string username,string pass)
        {
           return _userRepository.findByEmailAndPass(username,pass);
        }
        public User findByEmail(string email)
        {
          return  _userRepository.findByEmail(email);
        }
        public User findByUserName(string username)
        {
            return _userRepository.findByName(username);

        }
    }
}
