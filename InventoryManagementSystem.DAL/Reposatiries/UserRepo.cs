using InventoryManagementSystem.DAL.Data.DbHelper;
using InventoryManagementSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.DAL.Reposatiries
{
	public class UserRepo : IUserRepo
	{
		private readonly InventoryManagementSystemContext _context;
        public UserRepo(InventoryManagementSystemContext context)
        {
			_context = context;   
        }
        public void Add(User user)
		{
			_context.Users.Add(user);
		}

		public void Delete(User user)
		{
			_context.Users.Remove(user);
		}

		public IEnumerable<User> GetAll()
		{
			return _context.Users.AsNoTracking().ToList();
		}

		public User GetbyID(int id)
		{
			return _context.Users.Find(id);
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public void Update(User user)
		{
			
		}
	}
}
