using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YungChingRealtyPreview.ViewModel;

namespace YungChingRealtyPreview.Service
{
	public interface IProductService
	{
		IEnumerable<ProductViewModel> getAllProduct();
		ProductViewModel getProduct(int id);
		ProductViewModel createProduct(ProductViewModel product);
		ProductViewModel updateProduct(ProductViewModel product);
		bool removeProduct(int id);
	}
}
