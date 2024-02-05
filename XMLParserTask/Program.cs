using XMLParser.Services;
using XMLParser.XML;
using XMLParserTask.Data;
using XMLParserTask.Model;

AppDbContext appDbContext = new AppDbContext();
OrderService orderService = new OrderService(appDbContext);
ProductService productService = new ProductService(appDbContext);
ShoppingCartService shoppingCartService = new ShoppingCartService(appDbContext);
UserService userService = new UserService(appDbContext);

ShoppingCartEntity shoppingCart = XMLParsingService.ParseData("data.xml");

foreach (OrderEntity orderEntity in shoppingCart?.order)
{
    Users users = userService.Insert(orderEntity);
    Order order = orderService.Insert(orderEntity, users);

    foreach (ProductEntity product in orderEntity.Products)
    {
        Products products = productService.Insert(product);
        shoppingCartService.Insert(products, order, product.Quantity);
    }
}

appDbContext.SaveChanges();