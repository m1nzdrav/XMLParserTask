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

    public User Insert(OrderEntity orderEntity)
    {
        User user = _appDbContext.Users.Local.ToList()
            .FirstOrDefault(
                (x => x.UserName == orderEntity.User.fio), new User()
                {
                    UserName = orderEntity.User.fio,
                    Email = orderEntity.User.email
                });

        if (user.Id == 0 && !_appDbContext.Users.Any(x => x.Email == user.Email))
            _appDbContext.Users.Add(user);

        return user;
    }

    public User InsertFromList(OrderEntity orderEntity, List<User> baseValue)
    {
        User user = baseValue
            .FirstOrDefault(
                (x => x.UserName == orderEntity.User.fio), new User()
                {
                    UserName = orderEntity.User.fio,
                    Email = orderEntity.User.email
                });

        if (user.Id == 0 && !_appDbContext.Users.Any(x => x.Email == user.Email))
        {
            _appDbContext.Users.Add(user);
            baseValue.Add(user);
        }

        return user;
    }

    public List<User> GetUsersEmail(HashSet<string> hashSet)
    {
        return _appDbContext.Users
            .Where(users => users.Email != null && hashSet.Contains(users.Email)).ToList();
    }
}