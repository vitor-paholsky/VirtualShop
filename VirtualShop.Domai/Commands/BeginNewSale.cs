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

public class BeginNewSale : Notifiable, ICommand
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public Items Item { get; set; }
    public Products Product { get; set; }
    public double TotalSaleValue { get; set; }
    public double TotalSalePaid { get; set; }
    public double SaleChange { get; set; }
    public SaleStatus SaleStatus { get; set; }

    public BeginNewSale(int id, DateTime date, Items item, Products product, double totalSaleValue, double totalSalePaid, double saleChange, SaleStatus saleStatus)
    {
        Id = id;
        Date = date;
        Item = item;
        Product = product;
        TotalSaleValue = totalSaleValue;
        TotalSalePaid = totalSalePaid;
        SaleChange = saleChange;
        SaleStatus = saleStatus;
    }

    public BeginNewSale()
    {
    }
    
    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()              
                .IsGreaterThan(TotalSaleValue, 0, "TotalSaleValue", "Total value should be higher than 0")
                .IsGreaterThan(TotalSalePaid, 0, "TotalSalePaid", "Total value paid should be higher than 0")
       );
    }
}
