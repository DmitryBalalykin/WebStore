using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using WebStore.DomainNew.Entities;

namespace WebStore.Interface.Services
{
    public interface IUserClient : IUserRoleStore<User>,
                                   IUserPasswordStore<User>,
                                   IUserEmailStore<User>,
                                   IUserPhoneNumberStore<User>,
                                   IUserClaimStore<User>,
                                   IUserTwoFactorStore<User>,
                                   IUserLoginStore<User>,
                                   IUserLockoutStore<User>
    {
    }
}
