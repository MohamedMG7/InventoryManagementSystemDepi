using InventoryManagementSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.DAL.Reposatiries
{
	public interface ICartProductRepo
	{
		IEnumerable<CartProduct> GetAll();
		CartProduct GetbyID(int ShoppingCartid, int ProductId);
		void Delete(CartProduct CartProduct);
		void Update(CartProduct CartProduct);
		void Add(CartProduct CartProduct);
		void SaveChanges();
	}
}
