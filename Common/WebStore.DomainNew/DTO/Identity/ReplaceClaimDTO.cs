using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace WebStore.DomainNew.DTO.Identity
{
    public class ReplaceClaimDTO:UserDTO
    {
        public Claim claim { get; set; }

        public Claim newClaim { get; set; }
    }
}
