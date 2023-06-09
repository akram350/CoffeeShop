using CoffeeShop.Data;
using CoffeeShop.Models.Interfaces;

namespace CoffeeShop.Models.Services
{
    public class OrderRepository : IOrderRepository
    {
        private CoffeeShopDbContext dbContext { get; set; }
        private IShoppingCartRepository shoppingCartRepository;
        public OrderRepository (CoffeeShopDbContext dbContext, IShoppingCartRepository shoppingCartRepository)
        {
            this.dbContext = dbContext;
            this.shoppingCartRepository = shoppingCartRepository;
        }
        public void PlaceOrder(Order order )
        {
            var shoppingCartItems = shoppingCartRepository.GetShoppingCartItems();
            order.OrderDetails = new List<OrderDetails>() ;
            foreach( var item in  shoppingCartItems )
            {
                var orderDetails = new OrderDetails
                {
                    Quantity =item.Qty,
                   ProductId = item.Product.Id,
                   ProductPrice =  item.Product.Price
                };
                order.OrderDetails.Add(orderDetails);
                    
                
            }
            order.OrderPlaced = DateTime.Now;
            order.OrderTotal= shoppingCartRepository.GetShoppingCartTotal();
            dbContext.Orders.Add( order );  
            dbContext.SaveChanges();
        }
    }
}
