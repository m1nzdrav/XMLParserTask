using System.Xml;
using XMLParser.XML;
using XMLParserTask.Data;
using XMLParserTask.Model;

namespace XMLParser.Services;

public class OrderService
{
    private readonly AppDbContext _appDbContext;

    public OrderService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public Order Insert(OrderEntity orderEntity, Users users)
    {
        Order order = _appDbContext.Orders.ToList()
            .FirstOrDefault(
                (x => x.Id == orderEntity.No), new Order()
                {
                    Id = orderEntity.No,
                    Date = orderEntity.Reg_date,
                    Sum = orderEntity.Sum,
                    Users = users,
                });
       
        
        if (_appDbContext.Orders.Local.Any(x => x.Id == order.Id) || _appDbContext.Orders.Any(x => x.Id == order.Id))
            return order;

        _appDbContext.Orders.Add(order);
        return order;
    }
}