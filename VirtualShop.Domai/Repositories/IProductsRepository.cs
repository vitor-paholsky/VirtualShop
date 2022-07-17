﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualShop.Domain.Entities;

namespace VirtualShop.Domain.Repositories;

public interface IProductsRepository
{
    void Create(Products products);
    void Update(Products products);
    void Delete(Products products);
    Products GetProductById(Guid id);
    IEnumerable<Products> GetByDescription(string user);
}