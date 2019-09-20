using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DomainNew.Entities;
using WebStore.DomainNew.Filters;
using WebStore.Infrastucture.Interfaces;

namespace WebStore.Infrastucture.Implementations
{
    public class InMemoryProductService : IProductService
    {
        private readonly List<Brand> _brands;

        private readonly List<Section> _sections;

        private readonly List<Product> _products;

        public InMemoryProductService()
        {
            _brands = new List<Brand>
            {
                new Brand
                {
                    Id =1,
                    Name ="ACNE",
                    Order = 0
                },
                new Brand
                {
                    Id = 2,
                    Name = "Grüne Erde",
                    Order =1,
                },
                new Brand
                {
                    Id = 3,
                    Name = "Albiro",
                    Order =2,
                },
                new Brand
                {
                    Id = 5,
                    Name = "Ronhill",
                    Order =3,
                },
                new Brand
                {
                    Id = 6,
                    Name = "Boudestijn",
                    Order =4,
                },
                new Brand
                {
                    Id = 7,
                    Name = "Rösch creative culture",
                    Order =5,
                }
            };
            _sections = new List<Section>
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
            _products = new List<Product>
            {
                new Product
                {
                    Id=1,
                    Name = "Easy Polo Black Edition",
                    Order = 0,
                    Price = 15,
                    BrandId = 1,
                    SectionId = 24,
                    ImageUrl = "product12.jpg"
                },
                new Product
                {
                    Id=2,
                    Name = "Easy Polo Black Edition",
                    Order = 1,
                    Price = 20,
                    BrandId = 1,
                    SectionId = 24,
                    ImageUrl = "product11.jpg"
                },
                new Product
                {
                    Id=3,
                    Name = "Easy Polo Black Edition",
                    Order = 2,
                    Price = 25,
                    BrandId = 2,
                    SectionId = 2,
                    ImageUrl = "product10.jpg"
                },
                new Product
                {
                    Id=4,
                    Name = "Easy Polo Black Edition",
                    Order = 3,
                    Price = 30,
                    BrandId = 2,
                    SectionId = 2,
                    ImageUrl = "product9.jpg"
                },
                new Product
                {
                    Id=5,
                    Name = "Easy Polo Black Edition",
                    Order = 4,
                    Price = 35,
                    BrandId = 2,
                    SectionId = 4,
                    ImageUrl = "product8.jpg"
                },
                new Product
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
                new Product
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
                new Product
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
                new Product
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
                new Product
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
                new Product
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
        }

        public IEnumerable<Brand> GetBrands()
        {
            return _brands;
        }

        public IEnumerable<Section> GetSections()
        {
            return _sections;
        }

        public IEnumerable<Product> GetProducts(ProductFilter filter)
        {
            var products = _products;

            if (filter.SectionId.HasValue)//Если фильтр .HesValue-задан
                products = products.Where(x => x.SectionId == filter.SectionId.Value).ToList();

            if (filter.BrandId.HasValue)
                products = products.Where(x => x.BrandId == filter.BrandId.Value).ToList();

            return products;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }
    }
}
