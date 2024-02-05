using XMLParser.XML;
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

    public ShoppingCart Insert(Products products, Order order, int quantity)
    {
        ShoppingCart shoppingCart = new ShoppingCart()
        {
            Products = _appDbContext.Products.Local.FirstOrDefault(x => x.Name == products.Name, products),
            Order = order,
            CountProduct = quantity
        };

        _appDbContext.ShoppingCarts.AddRange(shoppingCart);
        return shoppingCart;
    }
}