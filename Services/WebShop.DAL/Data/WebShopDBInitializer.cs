using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebShop.DAL.Context;
using WebShop.Domain.Identity;
using WebShop.Infrastructure.Data;

namespace WebShop.Data
{
    public class WebShopDBInitializer
    {
        private readonly WebShopDB _db;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public WebShopDBInitializer(WebShopDB db, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            var db = _db.Database;

            //if (db.EnsureDeleted())
            //    if (db.EnsureCreated())
            //        throw new InvalidOperationException("Ошибка при создании БД");

            db.Migrate();
            InitializeProducts();
            InitializeEmployees();
            InitializeIdentityAsync().Wait();
        }
        
        private void InitializeProducts()
        {
            var db = _db.Database;
            //if (_db.Products.Any()) return;

            //using (db.BeginTransaction())
            //{
            //    _db.Sections.AddRange(TestData.Sections);

            //    db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[ProductSections] ON");
            //    _db.SaveChanges();
            //    db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[ProductSections] OFF");
            //    db.CommitTransaction();
            //}


            //using (db.BeginTransaction())
            //{
            //    _db.Brands.AddRange(TestData.Brands);

            //    db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[ProductBrands] ON");
            //    _db.SaveChanges();
            //    db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[ProductBrands] OFF");
            //    db.CommitTransaction();
            //}

            //using (db.BeginTransaction())
            //{
            //    _db.Products.AddRange(TestData.Products);

            //    db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Products] ON");
            //    _db.SaveChanges();
            //    db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Products] OFF");
            //    db.CommitTransaction();
            //}

            var products = TestData.Products;
            var sections = TestData.Sections;
            var brands = TestData.Brands;

            var product_section = products.Join(
                sections,
                p => p.SectionId,
                s => s.Id,
                (product, section) => (product, section));

            foreach (var (product, section) in product_section)
            {
                product.Section = section;
                product.SectionId = 0;
            }

            var product_brand = products.Join(
                brands,
                p => p.BrandId,
                b => b.Id,
                (product, brand) => (product, brand));

            foreach (var (product, brand) in product_brand)
            {
                product.Brand = brand;
                product.BrandId = null;
            }

            foreach (var product in products) product.Id = 0;

            var child_sections = sections.Join(
                sections,
                child => child.ParentId,
                parent => parent.Id,
                (child, parent) => (child, parent));

            foreach (var (child, parent) in child_sections)
            {
                child.ParentSection = parent;
                child.ParentId = null;
            }

            foreach (var section in sections) section.Id = 0;

            foreach (var brand in brands) brand.Id = 0;


            using (db.BeginTransaction())
            {
                _db.Sections.AddRange(sections);
                _db.Brands.AddRange(brands);
                _db.Products.AddRange(products);
                _db.SaveChanges();
                db.CommitTransaction();
            }
        }

        private void InitializeEmployees()
        {
            if (_db.Employees.Any()) return;

            using (_db.Database.BeginTransaction())
            {
                TestData.Empolyees.ForEach(employee => employee.Id = 0);

                _db.Employees.AddRange(TestData.Empolyees);

                _db.SaveChanges();

                _db.Database.CommitTransaction();
            }
        }

        private async Task InitializeIdentityAsync()
        {
            async Task CheckRoleExist(string roleName)
            {
                if (!await _roleManager.RoleExistsAsync(roleName))
                    await _roleManager.CreateAsync(new Role {Name = roleName});
            }

            await CheckRoleExist(Role.Administrator);
            await CheckRoleExist(Role.User);

            if (await _userManager.FindByNameAsync(User.Administrator) is null)
            {
                var admin = new User {UserName = User.Administrator};
                var creationResult = await _userManager.CreateAsync(admin, User.DefaultAdminPassword);
                if (creationResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(admin, Role.Administrator);
                }
                else
                {
                    var errors = creationResult.Errors.Select(e => e.Description);
                    throw  new InvalidOperationException($"Ошибка при создании пользователя Администратор: {string.Join(", ", errors)}");
                }

            }



        }
    }
}
