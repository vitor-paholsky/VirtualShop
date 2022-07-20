using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualShop.Domain.Commands;
using VirtualShop.Domain.Entities;
using VirtualShop.Domain.Queries;
using VirtualShop.Domain.Repositories;
using VirtualShop.Infra.Contexts;

namespace VirtualShop.Infra.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly DataContext _context;

    public SaleRepository(DataContext context)
    {
        _context = context;
    }

    public void Create(Sales sale)
    {
        _context.Sales.Add(sale);
        _context.SaveChanges();
    }

    public void Update(Sales sale)
    {
        _context.Sales.Update(sale);
        _context.SaveChanges();
    }

    public void Delete(Sales sale)
    {
        _context.Sales.Remove(sale);
        _context.SaveChanges();
    }      

    public Sales GetById(int id)
    {
        return _context.Sales.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<Sales> GetAll(Items items)
    {
        return _context.Sales.Where(SaleQueries.GetAll(items)).OrderBy(x => x.Date);
    }

    public IEnumerable<Sales> GetAllFinished(Items items)
    {
        return _context.Sales.Where(SaleQueries.GetAll(items)).OrderBy(x => x.SaleStatus == SaleStatus.Finished);
    }

    public IEnumerable<Sales> GetAllCanceled(Items items)
    {
        return _context.Sales.Where(SaleQueries.GetAll(items)).OrderBy(x => x.SaleStatus == SaleStatus.Canceled);
    }

}
