using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YungChingRealtyPreview.Repository
{
	public class ProductRepository : IProductRepository
	{
		private NORTHWNDEntities _entites;
		public ProductRepository()
		{
			this._entites = new NORTHWNDEntities();
		}		

		public IQueryable<Products> getAllProducts()
		{
			return from product in this._entites.Products select product;
		}

		public IQueryable<Products> getProduct(int id)
		{
			return from product in this._entites.Products
				   where product.ProductID == id
				   select product;
		}

		public Products insertProduct(Products product)
		{
			Products returnValue = null;
			using (var dbContextTransaction = this._entites.Database.BeginTransaction())
			{
				try
				{
					this._entites.Products.Add(product);

					int result = this._entites.SaveChanges();

					if (result > 0)
					{
						returnValue = getProduct(product.ProductID).FirstOrDefault();
					}

					dbContextTransaction.Commit();
				}
				catch (Exception)
				{
					dbContextTransaction.Rollback();
				}
			}
			return returnValue;
		}

		public Products updateProduct(Products product)
		{
			Products returnValue = null;
			using (var dbContextTransaction = this._entites.Database.BeginTransaction())
			{
				try
				{
					var origin = this._entites.Products.Find(product.ProductID);

					origin.ProductName = product.ProductName;
					origin.SupplierID = product.SupplierID;
					origin.CategoryID = product.CategoryID;
					origin.QuantityPerUnit = product.QuantityPerUnit;
					origin.UnitPrice = product.UnitPrice;
					origin.UnitsInStock = product.UnitsInStock;
					origin.UnitsOnOrder = product.UnitsOnOrder;
					origin.ReorderLevel = product.ReorderLevel;
					origin.Discontinued = product.Discontinued;

					int result = this._entites.SaveChanges();

					if (result > 0)
					{
						returnValue = getProduct(product.ProductID).FirstOrDefault();
					}

					dbContextTransaction.Commit();
				}
				catch (Exception ex)
				{
					dbContextTransaction.Rollback();
				}
			}
			return returnValue;
		}
		public bool deleteProduct(int id)
		{
			int result = -1;
			Products returnValue = null;
			using (var dbContextTransaction = this._entites.Database.BeginTransaction())
			{
				try
				{
					Products product = new Products() { ProductID = id };

					var origin = this._entites.Products.Find(product.ProductID);

					this._entites.Products.Remove(origin);

					result = this._entites.SaveChanges();

					if (result > 0)
					{
						returnValue = getProduct(product.ProductID).FirstOrDefault();
					}

					dbContextTransaction.Commit();
				}
				catch (Exception)
				{
					dbContextTransaction.Rollback();
				}
			}
			return result > -1;
		}
	}
}
