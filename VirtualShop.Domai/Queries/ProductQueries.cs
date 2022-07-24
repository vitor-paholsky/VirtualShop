using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VirtualShop.Domain.Entities;

namespace VirtualShop.Domain.Queries;

public class ProductQueries
{
    public static Expression<Func<Products, bool>> GetAllByDescription(string description)
    {
        return x => x.Description == description;
    }

    public static Expression<Func<Products, bool>> GetStock(double StockQuantity)
    {
        return x => x.StockQuantity == StockQuantity;
    }
}
