using XMLParser.Services;
using XMLParser.XML;
using XMLParserTask.Data;
using XMLParserTask.Model;

AppDbContext appDbContext = new AppDbContext();
OrderService orderService = new OrderService(appDbContext);
ProductService productService = new ProductService(appDbContext);
ShoppingCartService shoppingCartService = new ShoppingCartService(appDbContext);
UserService userService = new UserService(appDbContext);

HashSet<string> nameProducts = new HashSet<string>();
HashSet<string> emailUsers = new HashSet<string>();
HashSet<int> idOrders = new HashSet<int>();

ShoppingCartEntity shoppingCart = XMLParsingService.ParseData("data.xml");

shoppingCart.order.ForEach(x =>
{
    x.Products.ForEach(x => nameProducts.Add(x.Name));
    emailUsers.Add(x.User.email);
    idOrders.Add(x.No);
});

List<Product> products = productService.GetProductsName(nameProducts);
List<User> users = userService.GetUsersEmail(emailUsers);
List<Order> orders = orderService.GetOrders(idOrders);

foreach (OrderEntity orderEntity in shoppingCart.order)
{
    User user = userService.InsertFromList(orderEntity, users);
    Order order = orderService.InsertFromList(orderEntity, user, orders);

    foreach (ProductEntity productEntity in orderEntity.Products)
    {
        Product product = productService.InsertFromList(productEntity, products);
        shoppingCartService.Insert(product, order, productEntity.Quantity);
    }
}

appDbContext.SaveChanges();