using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace WebShop.DAL.Context
{
    public class WebShopDB : DbContext
    {
        public WebShopDB(DbContextOptions<WebShopDB> options) : base(options)
        {
            
        }
    }
}
