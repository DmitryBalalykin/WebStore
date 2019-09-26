using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using WebStore.DomainNew.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using WebStore.DomainNew.DTO;

namespace WebStore.DAL
{
    public class DbInitializer
    {
        public static void Initializre(WebStoreContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return;
            }

            //Заполнение БД
            var _brands = new List<BrandDTO>
            {
                new BrandDTO
                {
                    Id =1,
                    Name ="ACNE",
                    Order = 0
                },
                new BrandDTO
                {
                    Id = 2,
                    Name = "Grüne Erde",
                    Order =1,
                },
                new BrandDTO
                {
                    Id = 3,
                    Name = "Albiro",
                    Order =2,
                },
                new BrandDTO
                {
                    Id = 5,
                    Name = "Ronhill",
                    Order =3,
                },
                new BrandDTO
                {
                    Id = 6,
                    Name = "Boudestijn",
                    Order =4,
                },
                new BrandDTO
                {
                    Id = 7,
                    Name = "Rösch creative culture",
                    Order =5,
                }
            };
            using (var trans = context.Database.BeginTransaction())
            {
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].Brands ON");

                foreach (var brand in _brands)
                {
                    context.Brands.Add(brand);
                }

                context.SaveChanges();

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].Brands OFF");

                trans.Commit();
            }

            var _sections = new List<Section>
            {
                new Section
                {
                    Id=1,
                    Name="SPORTSWEAR",
                    Order=0,
                    ParentId=null,
                },
                new Section
                {
                    Id=2,
                    Name="NIKE",
                    Order=0,
                    ParentId=1,
                },
                new Section
                {
                    Id=3,
                    Name="UNDER ARMOUR",
                    Order=1,
                    ParentId=1,
                },
                new Section
                {
                    Id=4,
                    Name="ADIDAS",
                    Order=2,
                    ParentId=1,
                },
                new Section
                {
                    Id=5,
                    Name="PUMA",
                    Order=3,
                    ParentId=1,
                },
                new Section
                {
                    Id=6,
                    Name="ASICS",
                    Order=4,
                    ParentId=1,
                },
                new Section
                {
                    Id=7,
                    Name="MENS",
                    Order=1,
                    ParentId=null,
                },
                new Section
                {
                    Id=8,
                    Name="FENDI",
                    Order=0,
                    ParentId=7,
                },
                new Section
                {
                    Id=9,
                    Name="GUESS",
                    Order=1,
                    ParentId=7,
                },
                new Section
                {
                    Id=10,
                    Name="VALENTINO",
                    Order=2,
                    ParentId=7,
                },
                new Section
                {
                    Id=11,
                    Name="DIOR",
                    Order=3,
                    ParentId=7,
                },
                new Section
                {
                    Id=12,
                    Name="VERSACE",
                    Order=4,
                    ParentId=7,
                },
                new Section
                {
                    Id=13,
                    Name="ARMANI",
                    Order=5,
                    ParentId=7,
                },
                new Section
                {
                    Id=14,
                    Name="PRADA",
                    Order=6,
                    ParentId=7,
                },
                new Section
                {
                    Id=15,
                    Name="DOLCE AND GABBANA",
                    Order=7,
                    ParentId=7,
                },
                new Section
                {
                    Id=16,
                    Name="CHANEL",
                    Order=8,
                    ParentId=7,
                },
                new Section
                {
                    Id=17,
                    Name="GUCCI",
                    Order=9,
                    ParentId=7,
                },
                new Section
                {
                    Id=18,
                    Name="WOMENS",
                    Order=2,
                    ParentId=null,
                },
                new Section
                {
                    Id=19,
                    Name="FENDI",
                    Order=0,
                    ParentId=18,
                },
                new Section
                {
                    Id=20,
                    Name="GUESS",
                    Order=1,
                    ParentId=18,
                },
                new Section
                {
                    Id=21,
                    Name="VALENTINO",
                    Order=2,
                    ParentId=18,
                },
                new Section
                {
                    Id=22,
                    Name="DIOR",
                    Order=3,
                    ParentId=18,
                },
                new Section
                {
                    Id=23,
                    Name="VERSACE",
                    Order=4,
                    ParentId=18,
                },
                new Section
                {
                    Id=24,
                    Name="KIDS",
                    Order=3,
                    ParentId=null,
                },
                new Section
                {
                    Id=25,
                    Name="FASHION",
                    Order=4,
                    ParentId=null,
                },
                new Section
                {
                    Id=26,
                    Name="HOUSEHOLDS",
                    Order=5,
                    ParentId=null,
                },
                new Section
                {
                    Id=27,
                    Name="INTERIORS",
                    Order=6,
                    ParentId=null,
                },
                new Section
                {
                    Id=28,
                    Name="CLOTHING",
                    Order=7,
                    ParentId=null,
                },
                new Section
                {
                    Id=29,
                    Name="BAGS",
                    Order=8,
                    ParentId=null,
                },
                new Section
                {
                    Id=30,
                    Name="SHOES",
                    Order=9,
                    ParentId=null,
                },
            };
            using (var trans = context.Database.BeginTransaction())
            {
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].Sections ON");

                foreach (var section in _sections)
                {
                    context.Sections.Add(section);
                }

                context.SaveChanges();

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].Sections OFF");

                trans.Commit();
            }

            var _products = new List<ProductDTO>
            {
                new ProductDTO
                {
                    Id=1,
                    Name = "Easy Polo Black Edition",
                    Order = 0,
                    Price = 15,
                    BrandId = 1,
                    SectionId = 24,
                    ImageUrl = "product12.jpg"
                },
                new ProductDTO
                {
                    Id=2,
                    Name = "Easy Polo Black Edition",
                    Order = 1,
                    Price = 20,
                    BrandId = 1,
                    SectionId = 24,
                    ImageUrl = "product11.jpg"
                },
                new ProductDTO
                {
                    Id=3,
                    Name = "Easy Polo Black Edition",
                    Order = 2,
                    Price = 25,
                    BrandId = 2,
                    SectionId = 2,
                    ImageUrl = "product10.jpg"
                },
                new ProductDTO
                {
                    Id=4,
                    Name = "Easy Polo Black Edition",
                    Order = 3,
                    Price = 30,
                    BrandId = 2,
                    SectionId = 2,
                    ImageUrl = "product9.jpg"
                },
                new ProductDTO
                {
                    Id=5,
                    Name = "Easy Polo Black Edition",
                    Order = 4,
                    Price = 35,
                    BrandId = 2,
                    SectionId = 4,
                    ImageUrl = "product8.jpg"
                },
                new ProductDTO
                {
                    Id=6,
                    Name = "Easy Polo Black Edition",
                    Order = 5,
                    Price = 40,
                    BrandId = 2,
                    SectionId = 4,
                    ImageUrl = "product1.jpg",
                    StatusHome =true
                },
                new ProductDTO
                {
                    Id=7,
                    Name = "Easy Polo Black Edition",
                    Order = 6,
                    Price = 40,
                    BrandId = 2,
                    SectionId = 4,
                    ImageUrl = "product2.jpg",
                    StatusHome =true
                },
                new ProductDTO
                {
                    Id=8,
                    Name = "Easy Polo Black Edition",
                    Order = 7,
                    Price = 40,
                    BrandId = 2,
                    SectionId = 4,
                    ImageUrl = "product3.jpg",
                    StatusHome =true
                },
                new ProductDTO
                {
                    Id=9,
                    Name = "Easy Polo Black Edition",
                    Order = 8,
                    Price = 40,
                    BrandId = 2,
                    SectionId = 4,
                    ImageUrl = "product4.jpg",
                    StatusNew = true
                },
                new ProductDTO
                {
                    Id=10,
                    Name = "Easy Polo Black Edition",
                    Order = 9,
                    Price = 40,
                    BrandId = 2,
                    SectionId = 4,
                    ImageUrl = "product5.jpg",
                    StatusSale = true
                },
                new ProductDTO
                {
                    Id=11,
                    Name = "Easy Polo Black Edition",
                    Order = 10,
                    Price = 40,
                    BrandId = 2,
                    SectionId = 4,
                    ImageUrl = "product6.jpg",
                    StatusHome =true
                },
            };
            using (var trans = context.Database.BeginTransaction())
            {
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].Products ON");

                foreach (var product in _products)
                {
                    context.Products.Add(product);
                }

                context.SaveChanges();

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].Products OFF");

                trans.Commit();
            }
        }

        public static void InitializreUsers(IServiceProvider services)
        {
            var roleManager = services.GetService<RoleManager<IdentityRole>>();
            EnsureRole(roleManager, "User");
            EnsureRole(roleManager, "Admin");

            EnsureRoleToUser(services, "Admin", "Admin", "Admin@123");
        }

        private static void EnsureRoleToUser(IServiceProvider services, string userName, string roleName, string password)
        {
            var userManager = services.GetService<UserManager<User>>();

            var users = services.GetService<IUserStore<User>>();

            if (users.FindByNameAsync(userName, CancellationToken.None).Result != null)
            {
                return;
            }

            var admin = new User
            {
                UserName = userName,
                Email = $"{userName}@domain.com"
            };

            if (userManager.CreateAsync(admin, password).Result.Succeeded)
                userManager.AddToRoleAsync(admin, roleName).Wait();

        }

        private static void EnsureRole(RoleManager<IdentityRole> roleManager, string roleName)
        {

            if (!roleManager.RoleExistsAsync(roleName).Result)
            roleManager.CreateAsync(new IdentityRole(roleName)).Wait();

        }
    }
}
