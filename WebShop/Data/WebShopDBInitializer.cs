using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebShop.DAL.Context;
using WebShop.Infrastructure.Data;

namespace WebShop.Data
{
    public class WebShopDBInitializer
    {
        private readonly WebShopDB _db;

        public WebShopDBInitializer(WebShopDB db) => _db = db;

        public void Initialize()
        {
            var db = _db.Database;

            //if (db.EnsureDeleted())
            //    if (db.EnsureCreated())
            //        throw new InvalidOperationException("Ошибка при создании БД");

            db.Migrate();

            if (_db.Products.Any()) return;

            using (db.BeginTransaction())
            {
                _db.Sections.AddRange(TestData.Sections);

                db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[ProductSections] ON");
                _db.SaveChanges();
                db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[ProductSections] OFF");
                db.CommitTransaction();
            }


            using (db.BeginTransaction())
            {
                _db.Brands.AddRange(TestData.Brands);

                db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[ProductBrands] ON");
                _db.SaveChanges();
                db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[ProductBrands] OFF");
                db.CommitTransaction();
            }

            using (db.BeginTransaction())
            {
                _db.Products.AddRange(TestData.Products);

                db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Products] ON");
                _db.SaveChanges();
                db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Products] OFF");
                db.CommitTransaction();
            }
        }
    }
}
