using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualShop.Domain.Validations;

namespace VirtualShop.Domain.Commands;

public class ProductDelete 
{
    public int Id { get; set; }

    public ProductDelete(int id)
    {
        Id = id;
    }
}
