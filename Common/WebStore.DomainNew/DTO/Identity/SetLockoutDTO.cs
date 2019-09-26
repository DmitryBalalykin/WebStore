using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.DomainNew.DTO.Identity
{
    public class SetLockoutDTO:UserDTO
    {
        public DateTimeOffset? lockoutEnd { get; set; }
    }
}
