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

public class Items 
{
    public int Id { get; set; }
    public double  Quantity { get; set; }
    public decimal UnityPrice { get; set; }
    public double Total { get; set; }

    public Items(int id, double quantity, decimal unityPrice, double total)
    {
        Id = id;     
        Quantity = quantity;
        UnityPrice = unityPrice;
        Total = total;
    }

    public Items()
    {
    }

    public Items(int id)
    {
        Id = id;
    }

    public Items(int id, double quantity)
    {
        Id = id;
        Quantity = quantity;
    }

    public Items(int id, decimal unityPrice, double total) : this(id)
    {
    }
}
