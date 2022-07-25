using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualShop.Domain.Entities;
using VirtualShop.Domain.Validations;

namespace VirtualShop.Domain.Commands;

public class IncludeItemsToTheSale : Notifiable, ICommand
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public Items Item { get; set; }
    public Products Product { get; set; }
    public decimal TotalSaleValue { get; set; }
    public SaleStatus SaleStatus { get; set; }

    public IncludeItemsToTheSale()
    {
    }

    public IncludeItemsToTheSale(int id, DateTime date, Items item, Products product, decimal totalSaleValue, SaleStatus saleStatus)
    {
        Id = id;
        Date = date;
        Item = item;
        Product = product;
        TotalSaleValue = totalSaleValue;
        SaleStatus = saleStatus;
    }

    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()
                .IsGreaterThan(TotalSaleValue, 0, "TotalSaleValue", "Total value should be higher than 0")
       );
    }
}