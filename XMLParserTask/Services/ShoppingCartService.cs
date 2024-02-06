using XMLParserTask.Data;
using XMLParserTask.Model;

namespace XMLParser.Services;

public class ShoppingCartService
{
    private readonly AppDbContext _appDbContext;

    public ShoppingCartService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public ShoppingCart Insert(Product product, Order order, int quantity)
    {
        ShoppingCart shoppingCart = new ShoppingCart()
        {
            Product = _appDbContext.Products.Local.FirstOrDefault(x => x.Name == product.Name, product),
            Order = order,
            CountProduct = quantity
        };

        _appDbContext.ShoppingCarts.AddRange(shoppingCart);

        return shoppingCart;
    }
}