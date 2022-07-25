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
    public int Id { get; set; }
    public Items Items { get; set; }
    public Products Product { get; set; }
    public decimal TotalSalePaid { get; set; }
    public decimal SaleChange { get; set; }
    public SaleStatus SaleStatus { get; set; }
    public FinishSale()
    {
    }

    public FinishSale(int id, Items items, Products products, decimal totalSalePaid, decimal saleChange)
    {
        Id = id;
        Items = items;
        Product = products;
        TotalSalePaid = totalSalePaid;
        SaleChange = saleChange;
    }

    public void Validate()
    {
        if (SaleStatus != SaleStatus.Open)
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsFalse(true, "SaleStatus", "Only sales with openned sale status can be finished!")
       );
    }
}