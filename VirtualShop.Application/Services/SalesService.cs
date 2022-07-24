using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualShop.Domain.Commands;
using VirtualShop.Domain.Commands.Contracts;
using VirtualShop.Domain.Entities;
using VirtualShop.Domain.Repositories;

namespace VirtualShop.Application.Services;

public class SalesService : ISaleContract
{
    private readonly IProductsRepository _repository;

    public SalesService(IProductsRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Products> CalculateStockQuantity(double stockQuantity)
    {
        try
        {   
            var getStock = _repository.GetStock(stockQuantity);

            foreach (var item in getStock)
            {
                _ = item.StockQuantity;                   
            
            };       
         
            return getStock;
        }
        catch (Exception e)
        {
            throw;
        }
    }

    private static IncludeItemsToTheSale IncludeItemsToTheSale(double stockQuantity)
    {
        var itemsInput = new IncludeItemsToTheSale();
        itemsInput.Product.StockQuantity = stockQuantity;   

        return itemsInput;
    }
}
