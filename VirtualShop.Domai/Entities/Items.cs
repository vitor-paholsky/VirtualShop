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
    public double UnityPrice { get; set; }
    public double Total { get; set; }

    public Items(int id, double quantity, double unityPrice, double total)
    {
        Id = id;     
        Quantity = quantity;
        UnityPrice = unityPrice;
        Total = total;
    }

    public Items()
    {
    }
}
