using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualShop.Domain.Entities;

namespace VirtualShop.Domain.Commands.Contracts;

public interface ISaleContract
{
    public IEnumerable<Products> CalculateStockQuantity(double stockQuantity);
}
