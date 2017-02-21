using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YungChingRealtyPreview.Repository
{
	public interface IProductRepository
	{
		IQueryable<Products> getAllProducts();
		IQueryable<Products> getProduct(int id);
		Products insertProduct(Products product);
		Products updateProduct(Products product);
		bool deleteProduct(int id);
	}
}
