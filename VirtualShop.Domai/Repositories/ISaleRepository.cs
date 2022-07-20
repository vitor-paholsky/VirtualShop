using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualShop.Domain.Commands;
using VirtualShop.Domain.Entities;

namespace VirtualShop.Domain.Repositories;

public interface ISaleRepository
{  
    void Create(Sales sale);
    void Update(Sales sale);
    void Delete(Sales sale);
    Sales GetById(int id); 
    IEnumerable<Sales> GetAll(Items items);
    IEnumerable<Sales> GetAllFinished(Items items);
    IEnumerable<Sales> GetAllCanceled(Items items);
}
