using DataAccess.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class RoleObject
    {
        private readonly IRoleRepository roleRepository;

        public RoleObject()
        {
            this.roleRepository = new RoleRepository();
        }

       
        public List<Role> GetAllRoles() => roleRepository.getAll();
        public void addRole(Role ac) => roleRepository.Insert(ac);
        public void removeRole(int id) => roleRepository.Delete(id);
        public void UpdateRole(Role ac) => roleRepository.Update(ac);
        
    }
}
