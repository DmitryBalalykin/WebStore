using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.DomainNew.DTO.Identity
{
    public class AddLoginDTO:UserDTO
    {
        public UserLoginInfo userLoginInfo { get; set; }
    }
}
