using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YungChingRealtyPreview.Repository;
using YungChingRealtyPreview.ViewModel;

namespace YungChingRealtyPreview.Service
{
	public class ProductService: IProductService
	{
		IProductRepository _repo;
		private IMapper _mapper;
		public ProductService(IProductRepository repository)
		{
			this._repo = repository;
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<Products, ProductViewModel>();
				cfg.CreateMap<ProductViewModel, Products>();
			});
			this._mapper = config.CreateMapper();
		}

		public IEnumerable<ProductViewModel> getAllProduct()
		{
			IQueryable<Products> productData = this._repo.getAllProducts();
			
			return _mapper.Map<List<ProductViewModel>>(productData.ToList());
		}

		public ProductViewModel getProduct(int id)
		{
			IQueryable<Products> productData = this._repo.getProduct(id);

			return _mapper.Map<ProductViewModel>(productData.ToList().FirstOrDefault());
		}

		public ProductViewModel createProduct(ProductViewModel product)
		{
			var productData = _mapper.Map<Products>(product);

			productData = _repo.insertProduct(productData);

			return _mapper.Map<ProductViewModel>(productData);
		}

		public ProductViewModel updateProduct(ProductViewModel product)
		{
			var productData = _mapper.Map<Products>(product);

			productData = _repo.updateProduct(productData);

			return _mapper.Map<ProductViewModel>(productData);
		}

		public bool removeProduct(int id)
		{
			return _repo.deleteProduct(id);
		}
	}
}
