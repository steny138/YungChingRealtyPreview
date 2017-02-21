using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YungChingRealtyPreview.Service;
using YungChingRealtyPreview.ViewModel;

namespace YungChingRealtyPreview.Controllers
{
    public class ProductsController : ApiController
    {
		private IProductService productService;
		public ProductsController(IProductService service)
		{
			this.productService = service;
		}
		// GET: api/Products
		public IEnumerable<ProductViewModel> Get()
        {
			return this.productService.getAllProduct();
        }

        // GET: api/Products/5
        public ProductViewModel Get(int id)
        {
			return this.productService.getProduct(id);
		}

        // POST: api/Products
        public ProductViewModel Post([FromBody]ProductViewModel value)
        {
			return this.productService.createProduct(value);
        }

        // PUT: api/Products/5
        public ProductViewModel Put(ProductViewModel value)
        {
			return this.productService.updateProduct(value);
		}

		// PATCH: api/Products/5
		public ProductViewModel Patch(int id, [FromBody]string value)
		{
			ProductViewModel product = new ProductViewModel();
			product.ProductID = id;
			product.ProductName = value;
			return this.productService.updateProduct(product);
		}

		// DELETE: api/Products/5
		public bool Delete(int id)
        {
			return this.productService.removeProduct(id);
		}
    }
}
