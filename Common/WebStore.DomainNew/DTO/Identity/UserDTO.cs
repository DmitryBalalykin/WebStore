using System;
using System.Collections.Generic;
using System.Text;
using WebStore.DomainNew.Entities;

namespace WebStore.DomainNew.DTO.Identity
{
    public abstract class UserDTO
    {
        public User user { get; set; }
    }
}
