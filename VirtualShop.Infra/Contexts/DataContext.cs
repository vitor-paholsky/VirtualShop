using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualShop.Domain.Entities;

namespace VirtualShop.Infra.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
            : base(options)
    {
    }

    public DbSet<Items> Items { get; set; }
    public DbSet<Products> Products { get; set; }
    public DbSet<Sales> Sales { get; set; }
}
