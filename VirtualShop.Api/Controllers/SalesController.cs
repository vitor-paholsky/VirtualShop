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
            items.Id = command.Item.Id;
            items.Quantity = command.Item.Quantity;
            handler.Handle(command);

            var products = new Products();
            {
                products.Id = command.Product.Id;
                products.StockQuantity = command.Product.StockQuantity;
                handler.Handle(command);
            }

            var sales = new Sales();
            {
                sales.TotalSaleValue = command.TotalSaleValue;
                handler.Handle(command);
            }

            return (CommandResult)handler.Handle(command);
        }
    }

    [Route("finish/sales")]
    [HttpPut]
    public CommandResult Finish(
    [FromBody] FinishSale command,
    [FromServices] SaleHandler handler
    )
    {
        var items = new Items();
        {
            items.Id = command.Items.Id;
            items.Quantity = command.Items.Quantity;
            handler.Handle(command);

            var stock = _service.CalculateStockQuantity;

            var products = new Products();
            {
                products.Id = command.Product.Id;
                products.StockQuantity = command.Product.StockQuantity;
                handler.Handle(command);
            }

            var sales = new Sales();
            {
                sales.TotalSalePaid = command.TotalSalePaid;
                sales.SaleChange = command.SaleChange;
                handler.Handle(command);
            }

            return (CommandResult)handler.Handle(command);
        }
    }

    [Route("cancel/sales")]
    [HttpPut]
    public CommandResult Cancel(
    [FromBody] CancelSale command,
    [FromServices] SaleHandler handler
    )
    {
        var sales = new Sales();
        {
            sales.Id = command.Id;
            sales.SaleStatus = command.SaleStatus;
        }

            return (CommandResult)handler.Handle(command);
        }
    }


