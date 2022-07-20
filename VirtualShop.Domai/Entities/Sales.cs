using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualShop.Domain.Validations;

namespace VirtualShop.Domain.Entities;

public class Sales 
{
    public int Id { get; set; }
    public DateTime Date { get; set; }   
    public Items Items { get; set; }
    public Products Products { get; set; }
    public double TotalSaleValue { get; set; }
    public double TotalSalePaid { get; set; }
    public double SaleChange { get; set; }
    public SaleStatus SaleStatus { get; set; }

    public Sales(int id, DateTime date, Items items, Products products, double totalSaleValue, double totalSalePaid, double saleChange, SaleStatus saleStatus)
    {
        Id = id;
        Date = date;
        Items = items;
        Products = products;
        TotalSaleValue = totalSaleValue;
        TotalSalePaid = totalSalePaid;
        SaleChange = saleChange;
        SaleStatus = saleStatus;
    }

    public Sales()
    {
    }
}
