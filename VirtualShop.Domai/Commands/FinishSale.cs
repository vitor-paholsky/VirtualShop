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

public class FinishSale : Notifiable, ICommand
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public Items Items { get; set; }
    public decimal TotalSaleValue { get; set; }
    public decimal TotalSalePaid { get; set; }
    public decimal SaleChange { get; set; }
    public SaleStatus SaleStatus { get; set; }
    public FinishSale()
    {
    }

    public FinishSale(Guid id, DateTime date, Items items, decimal totalSaleValue, decimal totalSalePaid, decimal saleChange)
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