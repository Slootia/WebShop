using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WebShop.Domain.Entities;

namespace WebShop.DAL.Context
{
    public class WebShopDB : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Brand> Brands { get; set; }


        public WebShopDB(DbContextOptions<WebShopDB> options) : base(options) { }
    }
}
