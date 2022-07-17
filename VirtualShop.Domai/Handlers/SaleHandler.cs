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
   // IHandler<CancelSale>,
   // IHandler<FinishSale>,
    IHandler<IncludeItemsToTheSale>

{
    private readonly ISaleRepository _saleRepository;
    private readonly IProductsRepository _productRepository;

    public SaleHandler(ISaleRepository saleRepository, IProductsRepository productRepository)
    {
        _saleRepository = saleRepository;
        _productRepository = productRepository;
    }

    public ICommandResult Handle(BeginNewSale command)
    {
        command.Validate();
        if (command.Invalid)
            return new CommandResult(false, "Please, check yor sale details carefully!", command.Notifications);

        var sale = new Sales(
            command.Id,
            command.Date,
            command.TotalSaleValue,
            command.TotalSalePaid,
            command.SaleChange,
            command.SaleStatus = (SaleStatus)1
            );

        _saleRepository.Create(sale);

        return new CommandResult(true, "Sale started successfully", sale);
    }

    public ICommandResult Handle(IncludeItemsToTheSale command)
    {
        command.Validate();
        if (command.Invalid)
            return new CommandResult(false, "Please, check yor sale details carefully!", command.Notifications);

        var sale = new Sales(
            command.Id,
            command.Date,
            command.TotalSaleValue,
            command.TotalSalePaid,
            command.SaleChange,
            command.SaleStatus = (SaleStatus)1
            );

        _saleRepository.Create(sale);

        return new CommandResult(true, "Sale started successfully", sale);
    }

    /*public ICommandResult Handle(FinishSale command)
    {
        command.Validate();
        if (command.Invalid)
            return new CommandResult(false, "Please, check yor sale details carefully!", command.Notifications);

        var sale = new Sales(
           command.Id,
           command.Date,
           command.TotalSaleValue,
           command.TotalSalePaid,
           command.SaleChange,
           command.SaleStatus = (SaleStatus)2
           );

        _saleRepository.Finish(sale);

        return new CommandResult(true, "Sale started successfully", sale);
    }

    public ICommandResult Handle(CancelSale command)
    {
        command.Validate();
        if (command.Invalid)
            return new CommandResult(false, "Please, check yor sale details carefully!", command.Notifications);

        var sale = new Sales(
           command.Id,
           command.Date,
           command.TotalSaleValue,
           command.TotalSalePaid,
           command.SaleChange,
           command.SaleStatus = (SaleStatus)3
           );

        _saleRepository.Cancel(sale);

        return new CommandResult(true, "Sale started successfully", sale);
    }  */
}
