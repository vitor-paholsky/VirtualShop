using Microsoft.AspNetCore.Mvc;
using VirtualShop.Domain.Commands;
using VirtualShop.Domain.Entities;
using VirtualShop.Domain.Handlers;

namespace VirtualShop.Api.Controllers;

[ApiController]
[Route("v1/sales")]
public class SalesController : ControllerBase
{
    [Route("")]
    [HttpPost]
    public CommandResult Create(
            [FromBody] BeginNewSale command,
            [FromServices] SaleHandler handler
            )
    {

        var products = new Products();
        {
            products.Id = new Guid();
            products.Description = command.Items.Product.Description;
            products.UnitPrice = command.Items.Product.UnitPrice;
            products.StockQuantity = command.Items.Product.StockQuantity;
            handler.Handle(command);
        }

        var items = new Items();
        {
            items.Id = new Guid();
            items.Product = command.Items.Product;
            items.Quantity = command.Items.Quantity;
            items.UnityPrice = command.Items.UnityPrice;
            items.Total = command.Items.Total;
            handler.Handle(command);
        }

        var sales = new Sales();
        {
            sales.Id = new Guid();
            sales.Date = new DateTime();
            sales.Items = command.Items;
            sales.TotalSaleValue = command.TotalSaleValue;
            sales.TotalSalePaid = command.TotalSalePaid;
            sales.SaleChange = command.SaleChange;
            handler.Handle(command);
        }

        return (CommandResult)handler.Handle(command);
    }
}
