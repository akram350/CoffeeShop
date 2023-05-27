using CoffeeShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
	
	public class HomeController : Controller
	{

		private IProductRepository productRepository;
		public HomeController(IProductRepository productRepository)
		{
			this.productRepository = productRepository;
		}
		public IActionResult Index()
		{
			var trendingProducts = productRepository.GetTrendingProducts();
			return View(trendingProducts);
		}
	}
}
