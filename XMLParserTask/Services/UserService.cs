using Microsoft.EntityFrameworkCore;
using XMLParser.XML;
using XMLParserTask.Data;
using XMLParserTask.Model;

namespace XMLParser.Services;

public class UserService
{
    private readonly AppDbContext _appDbContext;

    public UserService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public Users Insert(OrderEntity orderEntity)
    {
        Users users = _appDbContext.Users.Local.ToList()
            .FirstOrDefault(
                (x => x.UserName == orderEntity.User.fio), new Users()
                {
                    UserName = orderEntity.User.fio,
                    Email = orderEntity.User.email
                });

        if (users.Id == 0 && !_appDbContext.Users.Any(x => x.Email == users.Email))
            _appDbContext.Users.Add(users);

        return users;
    }
}