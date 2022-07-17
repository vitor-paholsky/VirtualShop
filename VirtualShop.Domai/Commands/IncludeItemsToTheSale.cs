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
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public Items Items { get; set; }
    public double TotalSaleValue { get; set; }
    public double TotalSalePaid { get; set; }
    public double SaleChange { get; set; }
    public SaleStatus SaleStatus { get; set; }
    public IncludeItemsToTheSale()
    {
    }

    public IncludeItemsToTheSale(Guid id, DateTime date, Items items, double totalSaleValue, double totalSalePaid, double saleChange)
    {
        Id = id;
        Date = date;
        Items = items;
        TotalSaleValue = totalSaleValue;
        TotalSalePaid = totalSalePaid;
        SaleChange = saleChange;
    }

    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()
                .IsLowerThan(TotalSaleValue, 0, "TotalSaleValue", "Total value should be higher than 0")
                .IsLowerThan(TotalSalePaid, 0, "TotalSalePaid", "Total value paid should be higher than 0")
       );
    }
}