using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{

    public class RoleRepository : IRoleRepository
    {
        public List<Role> getAll()
        {
            try
            {
                using var context = new Prn212Context();
                return context.Roles.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            };
        }

        public void Delete(int id)
        {
            try
            {
                using var context = new Prn212Context();
                Role? DeletedRole = context.Roles.FirstOrDefault(r => r.RoleId == id) ?? throw new Exception("Role not found");
                context.Roles.Remove(DeletedRole);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Update(Role Role)
        {
            try
            {
                using var context = new Prn212Context();
                context.Entry(Role).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Role findById(int id)
        {
            try
            {
                using var context = new Prn212Context();
                return context.Roles.FirstOrDefault(r => r.RoleId == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            };
        }

        public void Insert(Role Role)
        {
            try
            {
                using var context = new Prn212Context();
                context.Roles.Add(Role);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            };
        }
    }
}

