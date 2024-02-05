using System.Diagnostics;
using XMLParser.XML;
using XMLParserTask.Data;
using XMLParserTask.Model;

namespace XMLParser.Services;

public class ProductService
{
    private readonly AppDbContext _appDbContext;

    public ProductService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public Products Insert(ProductEntity product)
    {
        Products products = _appDbContext.Products.ToList()
            .FirstOrDefault(
                (x => x.Name == product.Name),
                new Products()
                {
                    Name = product.Name,
                    Cost = product.Price
                });

        if (!_appDbContext.Products.Any(x => x.Name == products.Name) &&
            !_appDbContext.Products.Local.Any(x => x.Name == products.Name))
            _appDbContext.Products.Add(products);

        return products;
    }
}