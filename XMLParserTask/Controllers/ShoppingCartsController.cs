using XMLParserTask.Data;

namespace XMLParser.Controllers;

public class ShoppingCartsController
{
    private AppDbContext _appDbContext;
    
    public ShoppingCartsController(AppDbContext appDbContext)
    {
        this._appDbContext = appDbContext;
    }
    
    
}