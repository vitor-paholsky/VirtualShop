using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualShop.Domain.Commands;
using VirtualShop.Domain.Commands.Contracts;
using VirtualShop.Domain.Entities;
using VirtualShop.Domain.Handlers.Contracts;
using VirtualShop.Domain.Repositories;

namespace VirtualShop.Domain.Handlers;

public class ProductHandler : Notifiable,
    IHandler<ProductValidation>
{
    private readonly IProductsRepository _repository;

    public ProductHandler(IProductsRepository repository)
    {
        _repository = repository;
    }

    public ICommandResult Handle(ProductValidation command)
    {
        command.Validate();
        if (command.Invalid)
            return new CommandResult(false, "Please, check the product details", command.Notifications);

        var product = new Products(
            command.Id,
            command.Description,
            command.UnitPrice,
            command.StockQuantity
            );        

        _repository.Create(product);

        return new CommandResult(true, "Product has been registered successfully", product);
    }

    public ICommandResult Handle(ProductUpdate command)
    {
        command.Validate();
        if (command.Invalid)
            return new CommandResult(false, "Please, check the product details", command.Notifications);

        var product = new Products(
            command.Id,
            command.Description,
            command.UnitPrice,
            command.StockQuantity
            );

        _repository.Update(product);

        return new CommandResult(true, "Product has been updated successfully", product);
    }

    public ICommandResult Handle(ProductDelete command)
    {
        var product = new Products(
            command.Id
            );

        _repository.Delete(product);

        return new CommandResult(true, "Product has been deleted successfully", product);
    }
}
