using System;
using System.Collections.Generic;
using System.Text;
using WebStore.DomainNew.DTO;
using WebStore.DomainNew.Entities;

namespace WebStore.Services.Map
{
    public static class SectionMapper
    {
        public static SectionDTO ToDTO(this Section section) => section is null ? null : new SectionDTO
        {
            Id = section.Id,
            Name = section.Name
        };

        public static Section FromDTO(this SectionDTO sectionDTO) => sectionDTO is null ? null : new Section
        {
            Id = sectionDTO.Id,
            Name = sectionDTO.Name
        };

    }
}
