using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualShop.Domain.Validations;

namespace VirtualShop.Domain.Entities;

public class Products 
{
    public int Id { get; set; }
    public string Description { get; set; }
    public double UnitPrice { get; set; }
    public double StockQuantity { get; set; }

    public Products(int id, string description, double unitPrice, double stockQuantity)
    {
        Id = id;
        Description = description;
        UnitPrice = unitPrice;
        StockQuantity = stockQuantity;
    }

    public Products()
    {
    }

    public Products(int id)
    {
        Id = id;
    }
}
