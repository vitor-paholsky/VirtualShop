using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VirtualShop.Domain.Entities;

namespace VirtualShop.Domain.Queries;

public static class SaleQueries
{
    public static Expression<Func<Sales, bool>> GetAll(Items Items)
    {
        return x => x.Items == Items;
    }

    public static Expression<Func<Sales, bool>> GetAllFinished(Guid Id)
    {
        return x => x.Id == Id && x.SaleStatus.Equals(2);
    }

    public static Expression<Func<Sales, bool>> GetById(Guid Id)
    {
        return x => x.Id == Id;
    }
}
