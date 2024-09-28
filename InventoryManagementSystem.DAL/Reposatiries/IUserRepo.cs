using InventoryManagementSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.DAL.Reposatiries
{
	public interface IUserRepo
	{
		IEnumerable<User> GetAll();
		User GetbyID(int id);
		void Delete(User user);
		void Update(User user);
		void Add(User user);
		void SaveChanges();
	}
}
