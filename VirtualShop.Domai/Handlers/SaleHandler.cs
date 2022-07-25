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

public class SaleHandler : Notifiable,
    IHandler<BeginNewSale>,
    IHandler<CancelSale>,
    IHandler<FinishSale>,
    IHandler<IncludeItemsToTheSale>

{
    private readonly ISaleRepository _repository;

    public SaleHandler(ISaleRepository repository)
    {
        _repository = repository;
    }

    public ICommandResult Handle(BeginNewSale command)
    {
         var items = new Items(
            command.Id
            );

        var products = new Products(
            command.Id
            );

        var sale = new Sales(            
            command.Id,
            command.Date,
            items,
            products,
            command.SaleStatus = (SaleStatus)1
            );

        _repository.Create(sale);

        return new CommandResult(true, "Sale started successfully", sale);
    }

    public ICommandResult Handle(IncludeItemsToTheSale command)
    {
        command.Validate();
        if (command.Invalid)
            return new CommandResult(false, "Please, check yor sale details carefully!", command.Notifications);

        var items = new Items(
           command.Item.Id,
           command.Item.Quantity
           ); 

        var products = new Products(
            command.Product.Id
            );

        var sale = new Sales(
            command.Id,
            items,
            products,
            command.TotalSaleValue,
            command.SaleStatus = (SaleStatus)1
            );

        _repository.Update(sale);

        return new CommandResult(true, "Sale started successfully", sale);
    }

    public ICommandResult Handle(FinishSale command)
    {
        command.Validate();
        if (command.Invalid)
            return new CommandResult(false, "Please, check yor sale details carefully!", command.Notifications);

        var items = new Items(
         command.Items.Id,
         command.Items.UnityPrice,
         command.Items.Total
         );

        var products = new Products(
            command.Product.Id
            );

        var sale = new Sales(
           command.Id,
           items,
           products,
           command.TotalSalePaid,
           command.SaleChange,
           command.SaleStatus = (SaleStatus)2
           );

        _repository.Update(sale);

        return new CommandResult(true, "Sale started successfully", sale);
    }

    public ICommandResult Handle(CancelSale command)
    {
        command.Validate();
        if (command.Invalid)
            return new CommandResult(false, "Please, check your sale status carefully carefully!", command.Notifications);

        var sale = new Sales(
           command.Id,
           command.SaleStatus = (SaleStatus)3
           );

        _repository.Update(sale);

        return new CommandResult(true, "Sale cancelled successfully", sale);
    }  
}
