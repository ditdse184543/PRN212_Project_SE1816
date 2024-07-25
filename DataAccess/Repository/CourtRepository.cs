using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CourtRepository:ICourtRepository
    {
        private readonly Prn212Context _context;
        public CourtRepository()
        {

            _context = new Prn212Context();

        }

        public void Delete(int id)
        {
            var delete = findById(id);
            delete.CoStatus = false;
            _context.Courts.Update(delete);
            _context.SaveChanges();



        }

        public Court findById(int id)
        {
            return _context.Courts.FirstOrDefault(c => c.CoId == id);
        }

        public List<Court> getAll()
        {
            return _context.Courts.Where(c => c.CoStatus == true).ToList();
        }

        public void Insert(Court Court)
        {
            _context.Courts.Add(Court);
            _context.SaveChanges();

        }
        public List<Court> findBySearch(string search)
        {
            return _context.Courts
                            .Where(ac => EF.Functions.Like(ac.CoName, $"{search}%") ||
                                        EF.Functions.Like(ac.CoAddress.ToString(), $"{search}%"))
                            .ToList();
        }
        public void Update(Court Court)
        {
            var existingCourt = findById(Court.CoId);
            if (existingCourt != null)
            {
                // Update the existing court's properties
                existingCourt.CoName = Court.CoName;
                existingCourt.CoPath = Court.CoPath;
                existingCourt.CoStatus = Court.CoStatus;
                existingCourt.CoAddress = Court.CoAddress;
                existingCourt.CoInfo = Court.CoInfo;
                existingCourt.CoPrice = Court.CoPrice;
                existingCourt.UserId = Court.UserId;

                // Save the changes
                _context.SaveChanges();
            }
        }
        public List<Court> LoadCourtBasedOnBooking(int userId)
        {
            return _context.Courts.Where(c => _context.Bookings.Any(b => b.UserId == userId)).ToList();
        }
        public List<Court> search(string search)
        {
            if (int.TryParse(search, out int id))
            {

                return _context.Courts.Where(c => c.CoId == id || c.CoPrice == id).ToList();
            }
            else
            {
                search = search.ToLower();
                // Search by string
                return _context.Courts.Where(c => string.IsNullOrEmpty(search) || c.CoName.ToLower().Contains(search) || c.CoInfo.ToLower().Contains(search)).ToList();
            }
        }

        public List<Court> getByUserID(int userId)
        {
            return _context.Courts.Include(c => c.Bookings).ThenInclude(b => b.Payments).Where(c => c.UserId == userId).ToList();
        }

        public List<Court> getCourtByUserID(int userId)
        {
            User user = _context.Users.Include(u=> u.Roles).SingleOrDefault(u => u.UserId == userId);
            if(user.Roles.First().RoleId == 2)
            {
                return _context.Courts.Where(c => c.CoStatus == true).ToList();
            }
            else
            {
                return _context.Courts.Where(c => c.CoStatus == true && c.User.UserId==userId).ToList();
            }
        }
    }
}
