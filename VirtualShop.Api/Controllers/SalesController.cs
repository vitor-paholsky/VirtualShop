using Microsoft.AspNetCore.Mvc;
using VirtualShop.Domain.Commands;
using VirtualShop.Domain.Commands.Contracts;
using VirtualShop.Domain.Entities;
using VirtualShop.Domain.Handlers;

namespace VirtualShop.Api.Controllers;

[ApiController]
[Route("v1/sales")]
public class SalesController : ControllerBase
{
    private readonly ISaleContract _service;

    public SalesController(ISaleContract service)
    {
        _service = service;
    }

    [Route("")]
    [HttpPost]
    public CommandResult Create(
            [FromBody] BeginNewSale command,
            [FromServices] SaleHandler handler
            )
        {
        var items = new Items();
        {
            items.Id = command.Id;
        }

            var sales = new Sales();
        {
            sales.Date = new DateTime();
            handler.Handle(command);     

            return (CommandResult)handler.Handle(command);
        }
    }

    [Route("include/items")]
    [HttpPut]
    public CommandResult Include(
        [FromBody] IncludeItemsToTheSale command,
        [FromServices] SaleHandler handler
        )
    {
        var items = new Items();
        {
            items.Quantity = command.Item.Quantity;
            items.UnityPrice = command.Item.UnityPrice;
            items.Total = command.Item.Total;
            handler.Handle(command);

            var products = new Products();
            {
                products.Description = command.Product.Description;
                products.UnitPrice = command.Product.UnitPrice;
                products.StockQuantity = command.Product.StockQuantity;
                handler.Handle(command);

                var stock = _service.CalculateStockQuantity;

            }

            var sales = new Sales();
            {
                sales.TotalSaleValue = command.TotalSaleValue;
                sales.TotalSalePaid = command.TotalSalePaid;
                sales.SaleChange = command.SaleChange;
                handler.Handle(command);
            }

            return (CommandResult)handler.Handle(command);
        }
    }
}
