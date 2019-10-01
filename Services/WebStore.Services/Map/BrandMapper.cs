using System;
using System.Collections.Generic;
using System.Text;
using WebStore.DomainNew.DTO;
using WebStore.DomainNew.Entities;

namespace WebStore.Services.Map
{
    public static class BrandMapper
    {
        public static BrandDTO ToDTO(this Brand brand) => brand is null ? null : new BrandDTO
        {
            Id = brand.Id,
            Name = brand.Name
        };

        public static Brand FromDTO(this BrandDTO brandDTO) => brandDTO is null ? null: new Brand
        {
            Id = brandDTO.Id,
            Name = brandDTO.Name
        };
    }
}
