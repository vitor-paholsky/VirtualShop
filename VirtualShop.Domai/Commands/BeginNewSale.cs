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
    public Items Item { get; set; }
    public DateTime Date { get; set; }
    public SaleStatus SaleStatus { get; set; }

    public BeginNewSale(int id, Items item, DateTime date, SaleStatus saleStatus)
    {
        Id = id;
        Item = item;
        Date = date;
        SaleStatus = saleStatus;
    }

    public BeginNewSale()
    {
    }

    public void Validate()
    {
        throw new NotImplementedException();
    }
}
