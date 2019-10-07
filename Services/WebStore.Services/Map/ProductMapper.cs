using System;
using System.Collections.Generic;
using System.Text;
using WebStore.DomainNew.DTO;
using WebStore.DomainNew.Entities;

namespace WebStore.Services.Map
{
    public static class ProductMapper
    {
        public static ProductDTO ToDTO(this Product product)
        {
            return product is null ? null : new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Order = product.Order,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Brand = product.Brand.ToDTO(),
                Section = product.Section.ToDTO()
            };
        }

        public static Product FromDTO(this ProductDTO productDTO) => productDTO is null ? null : new Product
        {
            Id = productDTO.Id,
            Name = productDTO.Name,
            Order = productDTO.Order,
            Price = productDTO.Price,
            ImageUrl = productDTO.ImageUrl,
            Brand = productDTO.Brand.FromDTO(),
            Section = productDTO.Section.FromDTO()
        };
    }
}
