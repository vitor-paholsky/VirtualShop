using Microsoft.AspNetCore.Mvc;
using VirtualShop.Domain.Commands;
using VirtualShop.Domain.Entities;
using VirtualShop.Domain.Handlers;
using VirtualShop.Domain.Repositories;

namespace VirtualShop.Api.Controllers;

[ApiController]
[Route("v1/products")]
public class ProductController : ControllerBase
{
    // Register a new product
    [Route("")]
    [HttpPost]
    public CommandResult Create(
            [FromBody] ProductValidation command,
            [FromServices] ProductHandler handler
            )
    {
        var products = new Products();
        {
            products.Description = command.Description;
            products.UnitPrice = command.UnitPrice;
            products.StockQuantity = command.StockQuantity;
            handler.Handle(command);
        }

        return (CommandResult)handler.Handle(command);
    }

    // Get product by Id
    [Route("id")]
    [HttpGet]
    public IEnumerable<Products> GetById(
        [FromServices] IProductsRepository repository, int id)
    {
        var result = repository.GetProductById(id);

        var product = new Products()
        {
            Id = result.Id,
            Description = result.Description,
            UnitPrice = result.UnitPrice,
            StockQuantity = result.StockQuantity
        };

        yield return product;
    }

    // Get product by description
    [Route("by-description")]
    [HttpGet]
    public IEnumerable<Products> GetByDescription(
        [FromServices] IProductsRepository repository, string description)
    {
        try
        {
            var result = repository.GetByDescription(description);

            var product = new List<Products>();

            foreach (var findProducts in result)
            {
                var products = (new Products
                {
                    Description = findProducts.Description
                });

                product.Add(findProducts);
            };

            return product;
        }
        catch (Exception ex)
        {
            return (IEnumerable<Products>)BadRequest(ex);
        }
    }

    // Update
    [Route("update")]
    [HttpPut]
    public CommandResult Update(
        [FromBody] ProductUpdate command,
        [FromServices] ProductHandler handler)
    {
        var products = new Products();
        {
            products.Id = command.Id;
            products.Description = command.Description;
            products.UnitPrice = command.UnitPrice;
            products.StockQuantity = command.StockQuantity;
            handler.Handle(command);
        }

        return (CommandResult)handler.Handle(command);
    }

    // Delete
    [Route("delete")]
    [HttpDelete]
    public CommandResult Delete(
        [FromBody] ProductDelete command,
        [FromServices] ProductHandler handler)
    {
        var products = new Products();
        {
            products.Id = command.Id;
        }

        return (CommandResult)handler.Handle(command);
    }
}


