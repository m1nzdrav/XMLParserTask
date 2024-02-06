using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
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

    public Product Insert(ProductEntity productEntity)
    {
        Product product = _appDbContext.Products
            .FirstOrDefault(
                (x => x.Name == productEntity.Name),
                new Product()
                {
                    Name = productEntity.Name,
                    Cost = productEntity.Price
                });

        if (!_appDbContext.Products.Any(x => x.Name == product.Name) &&
            _appDbContext.Products.Local.All(x => x.Name != product.Name))
            _appDbContext.Products.Add(product);

        return product;
    }

    public Product InsertFromList(ProductEntity productEntity, List<Product> baseValue)
    {
        Product product = baseValue
            .FirstOrDefault(
                (x => x.Name == productEntity.Name),
                new Product()
                {
                    Name = productEntity.Name,
                    Cost = productEntity.Price
                });

        if (baseValue.Any(x => x.Name == product.Name) ||
            _appDbContext.Products.Local.Any(x => x.Name == product.Name)) return product;

        _appDbContext.Products.Add(product);
        baseValue.Add(product);

        return product;
    }

    public List<Product> GetProductsName( HashSet<string> hashSet)
    {
        return _appDbContext.Products
            .Where(product => product.Name != null && hashSet.Contains(product.Name)).ToList();
    }
}