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

public class CancelSale : Notifiable, ICommand
{  

    public int Id { get; set; }  
    public SaleStatus SaleStatus { get; set; }
    public CancelSale()
    {
    }
    public CancelSale(int id, SaleStatus saleStatus)
    {
        Id = id;
        SaleStatus = saleStatus;
    }

    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()
                .AreEquals(1, 1, "SaleStatus", "Only sales with openned status can be cancelled")
       );
    }
}