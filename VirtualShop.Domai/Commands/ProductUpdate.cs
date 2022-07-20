using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualShop.Domain.Validations;

namespace VirtualShop.Domain.Commands;

public class ProductUpdate : Notifiable, ICommand
{
    public int Id { get; set; }
    public string Description { get; set; }
    public double UnitPrice { get; set; }
    public double StockQuantity { get; set; }

    public ProductUpdate(int id, string description, double unitPrice, double stockQuantity)
    {
        Id = id;
        Description = description;
        UnitPrice = unitPrice;
        StockQuantity = stockQuantity;
    }

    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()
                .HasMinLen(Description, 2, "Description", "Please do a better description of the product")
                .IsGreaterThan(UnitPrice, 0, "UnitPrice", "Unit price should be higher than 0")
                .IsGreaterThan(StockQuantity, 0, "StockQuantity", "Stock quantity value paid should be higher than 0")
       );
    }
}
