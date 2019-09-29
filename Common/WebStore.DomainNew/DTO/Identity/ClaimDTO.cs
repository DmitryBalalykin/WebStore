using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace WebStore.DomainNew.DTO.Identity
{
    public abstract class ClaimDTO:UserDTO
    {
        public IEnumerable<Claim> claims { get; set; }
    }
}
