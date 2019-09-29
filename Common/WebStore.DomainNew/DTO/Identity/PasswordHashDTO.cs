using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.DomainNew.DTO.Identity
{
    public class PasswordHashDTO : UserDTO
    {
        public string Hash { get; set; }
    }
}
