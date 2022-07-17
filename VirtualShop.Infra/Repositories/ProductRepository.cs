using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualShop.Domain.Entities;
using VirtualShop.Domain.Queries;
using VirtualShop.Domain.Repositories;
using VirtualShop.Infra.Contexts;

namespace VirtualShop.Infra.Repositories;

public class ProductRepository : IProductsRepository
{
    private readonly DataContext _context;

    public ProductRepository(DataContext context)
    {
        _context = context;
    }

    public void Create(Products product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void Update(Products product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    public void Delete(Products product)
    {
        _context.Products.Remove(product);
        _context.SaveChanges();
    }

    public Products GetProductById(Guid id)
    {
        return _context.Products.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<Products> GetByDescription(string description)
    {
        return _context.Products.Where(ProductQueries.GetAllByDescription(description)).OrderBy(x => x.StockQuantity);
    }
}
