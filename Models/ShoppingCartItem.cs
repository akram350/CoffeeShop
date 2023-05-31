namespace CoffeeShop.Models
{
    public class ShoppingCartItem
    {

        public int Id { get; set; }
        public int Qty { get; set; }
        public Product Product { get; set; }
        public int ShoppingCartId { get; set; }
    }
}
