using CoffeeShop.Models;
using CoffeeShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository orderRepository;
        private  IShoppingCartRepository shopCartRepository;
        public OrderController( IOrderRepository orderRepository, IShoppingCartRepository shopCartRepository)
        {
            this.orderRepository = orderRepository;
            this.shopCartRepository = shopCartRepository;
        }
        public IActionResult Checkout()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            orderRepository.PlaceOrder(order);
            shopCartRepository.ClearCart();
            HttpContext.Session.SetInt32("cartCount", 0);
            return RedirectToAction("CheckoutComplete");
        }
        public IActionResult CheckoutComplete()
        {

            return View();
        }
    }
}
