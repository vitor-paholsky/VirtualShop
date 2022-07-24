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
    public decimal TotalSaleValue { get; set; }
    public decimal TotalSalePaid { get; set; }
    public decimal SaleChange { get; set; }
    public SaleStatus SaleStatus { get; set; }


    public Sales(int id, DateTime date, Items items, Products products, decimal totalSaleValue, decimal totalSalePaid, decimal saleChange, SaleStatus saleStatus)
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

    public Sales(int id, DateTime date, SaleStatus saleStatus)
    {
        Id = id;
        Date = date;
        SaleStatus = saleStatus;
    }

    public Sales(int id, DateTime date, Items items, Products products, SaleStatus saleStatus)
    {
        Id = id;
        Date = date;
        Items = items;
        Products = products;
        SaleStatus = saleStatus;
    }
}
