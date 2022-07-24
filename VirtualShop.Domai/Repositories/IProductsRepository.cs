using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualShop.Domain.Entities;

namespace VirtualShop.Domain.Repositories;

public interface IProductsRepository
{
    void Create(Products products);
    void Update(Products products);
    void Delete(Products products);
    Products GetProductById(int id);
    IEnumerable<Products> GetByDescription(string description);
    IEnumerable<Products> GetStock(double StockQuantity);
}
