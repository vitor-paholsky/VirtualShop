using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualShop.Domain.Commands;
using VirtualShop.Domain.Entities;

namespace VirtualShop.Domain.Tests.CommandTests;

[TestClass]
public class BeginNewSaleTests
{
    private readonly Items _items = new();
    private readonly Products _products = new();
    private readonly BeginNewSale _invalidCommand = new();
    private readonly BeginNewSale _validCommand = new();

  /*  public BeginNewSaleTests()
    {
        _items = new (default, _products, 50, 8.99, 449.5);
        _products = new(default, "Coca Cola 2lts", 0, 200);
        _invalidCommand = new(default, DateTime.Now, _items, 10, 10, 5);
        _validCommand = new(default, DateTime.Now, _items, 10, 5, 5);
    } */
 

    [TestMethod]
    public void Start_a_invalid_sale()
    {
        Assert.AreEqual(_invalidCommand.Valid, true);
    }

    [TestMethod]
    public void Start_a_valid_sale()
    {
        Assert.AreEqual(_validCommand.Valid, true);
    }
}
