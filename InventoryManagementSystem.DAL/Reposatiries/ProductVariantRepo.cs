﻿using InventoryManagementSystem.DAL.Data.DbHelper;
using InventoryManagementSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace InventoryManagementSystem.DAL.Reposatiries
{
	public class ProductVariantRepo : IProductVariantRepo
	{
		private readonly InventoryManagementSystemContext _context;
        public ProductVariantRepo(InventoryManagementSystemContext context)
        {
            _context = context;	
        }
        public void Add(ProductVariant ProductVariant)
		{
			_context.productVariants.Add(ProductVariant);
		}

		public void Delete(ProductVariant ProductVariant)
		{
			_context.productVariants.Remove(ProductVariant);
		}

		public IEnumerable<ProductVariant> GetAll()
		{
			return _context.productVariants.AsNoTracking().ToList();
		}

		public ProductVariant GetbyID(int id)
		{
			return _context.productVariants.Find(id);
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public void Update(ProductVariant ProductVariant)
		{
			
		}
	}
}
