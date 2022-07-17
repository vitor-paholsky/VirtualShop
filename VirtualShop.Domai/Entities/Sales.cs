using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualShop.Domain.Validations;

namespace VirtualShop.Domain.Entities;

public class Sales 
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public Items Items { get; set; }
    public double TotalSaleValue { get; set; }
    public double TotalSalePaid { get; set; }
    public double SaleChange { get; set; }
    public SaleStatus SaleStatus { get; set; }

    public Sales(Guid id, DateTime date, double totalSaleValue, double totalSalePaid, double saleChange, SaleStatus saleStatus)
    {
        Id = id;
        Date = date;
        TotalSaleValue = totalSaleValue;
        TotalSalePaid = totalSalePaid;
        SaleChange = saleChange;
        SaleStatus = saleStatus;
    }

    public Sales()
    {
    }
}
