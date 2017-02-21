using Autofac;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YungChingRealtyPreview.Controllers;
using Autofac.Integration.WebApi;
using YungChingRealtyPreview.ViewModel;
using YungChingRealtyPreview.Service;
using YungChingRealtyPreview.Repository;

namespace YungChingRealtyPreview.Tests.Controllers
{

	[TestFixture()]
	public class ProductsControllerTests
	{
		protected IContainer container = null;
		[SetUp]
		public void init()
		{
			
		}
		/// <summary>
		/// Arrange
		/// 	初始化目標物件
		/// 	初始化方法參數
		/// 	建立模擬物件行為
		/// 	設定環境變數, 期望結果
		/// Act
		/// 	實際呼叫目標測試物件的方法
		/// Assert
		/// 	驗證目標物件是否如同預期運作
		/// </summary>
		[Test()]
		public void product_create_returnNewObject()
		{
			// Arrange
			ProductsController controller = new ProductsController(new ProductService(new ProductRepository()));
			ProductViewModel expected = new ProductViewModel();
			expected.ProductName = "YUCHEN LIU";
			expected.SupplierID = 1;
			expected.CategoryID = 1;
			expected.QuantityPerUnit = "24 - 12 oz bottles";
			expected.UnitPrice = 19;
			expected.UnitsInStock = 17;
			expected.UnitsOnOrder = 40;
			expected.ReorderLevel = 25;
			expected.Discontinued = false;

			// Act
			var actual = controller.Post(expected);

			// Assert
			Assert.IsNotNull(actual);
			Assert.Greater(actual.ProductID, 0);
			Assert.AreEqual(expected.ProductName, actual.ProductName);
		}

		[Test()]
		public void product_GetAll_returnNewObject()
		{
			// Arrange
			ProductsController controller = new ProductsController(new ProductService(new ProductRepository()));

			// Act
			IEnumerable<ProductViewModel> result = controller.Get();
			int expectedCount = 70;

			// Assert
			Assert.IsNotNull(result);
			Assert.GreaterOrEqual(result.Count(), expectedCount);
			Assert.AreEqual("Chai", result.ElementAt(0).ProductName);
			Assert.AreEqual("Chang", result.ElementAt(1).ProductName);
		}

		[Test()]
		public void product_GetById_returnNewObject()
		{
			// Arrange
			ProductsController controller = new ProductsController(new ProductService(new ProductRepository()));

			// Act
			int expectedId = 1;
			string expectedName = "Chai";
			ProductViewModel result = controller.Get(expectedId);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(expectedId, result.ProductID);
			Assert.AreEqual(expectedName, result.ProductName);
		}

		[Test()]
		public void product_update_returnSameIdObject()
		{
			// Arrange
			ProductsController controller = new ProductsController(new ProductService(new ProductRepository()));
			ProductViewModel expected = controller.Get(1);
			expected.UnitPrice = expected.UnitPrice + 1;
			// Act
			var actual = controller.Put(expected);

			// Assert
			Assert.IsNotNull(expected);
			Assert.IsNotNull(actual);
			Assert.AreEqual(expected.UnitPrice, actual.UnitPrice);
		}

		[Test()]
		public void product_delete_returnTrue()
		{
			// Arrange
			ProductsController controller = new ProductsController(new ProductService(new ProductRepository()));
			var expects = controller.Get();

			// Act
			bool actual = controller.Delete(expects.ToList().LastOrDefault().ProductID);
			int actualCount = controller.Get().Count();

			// Assert
			Assert.IsTrue(actual);
			Assert.AreEqual(expects.Count(), actualCount + 1);
		}
	}
}
