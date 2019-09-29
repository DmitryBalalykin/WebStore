using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStore.DAL;
using WebStore.DomainNew.DTO.Identity;
using WebStore.DomainNew.Entities;

namespace WebStore.ServiceHosting.Controllers
{
    [Route("api/users")]
    [ApiController, Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly UserStore<User> _usersStore;

        public UsersController(WebStoreContext context) => _usersStore = new UserStore<User>(context) { AutoSaveChanges = true };

        #region one
        [HttpGet("AllUsers")]
        public async Task<IEnumerable<User>> GetAllUsers() => await _usersStore.Users.ToArrayAsync();

        [HttpPost("UserId")]
        public async Task<string> GetUserIdAsync([FromBody] User user) => await _usersStore.GetUserIdAsync(user);

        [HttpPost("UserName")]
        public async Task<string> GetUserNameAsync([FromBody] User user) => await _usersStore.GetUserNameAsync(user);

        [HttpPost("UserName/{name}")]
        public async Task SetUserNameAsync([FromBody] User user, string name) => await _usersStore.SetUserNameAsync(user, name);

        [HttpPost("NormalUserName")]
        public async Task<string> GetNormalizedUserNameAsync([FromBody] User user) => await _usersStore.GetNormalizedUserNameAsync(user);

        [HttpPost("NormalUserName/{name}")]
        public Task SetNormalizedUserNameAsync([FromBody] User user, string name) => _usersStore.SetNormalizedUserNameAsync(user, name);

        [HttpPost("user")]
        public async Task<bool> CreateAsync([FromBody] User user) => (await _usersStore.CreateAsync(user)).Succeeded;

        [HttpPut("user")]
        public async Task<bool> UpdateAsync([FromBody] User user) => (await _usersStore.UpdateAsync(user)).Succeeded;

        [HttpPost("User/Delete")]
        public async Task<bool> DeleteAsync([FromBody] User user) => (await _usersStore.DeleteAsync(user)).Succeeded;

        [HttpGet("User/Find/{id}")]
        public async Task<User> FindByIdAsync(string id) => await _usersStore.FindByIdAsync(id);

        [HttpGet("User/Normal/{name}")]
        public async Task<User> FindByNameAsync(string name) => await _usersStore.FindByNameAsync(name);

        [HttpPost("Role/{role}")]
        public async Task AddToRoleAsync([FromBody] User user, string role) => await _usersStore.AddToRoleAsync(user, role);

        [HttpPost("Role/Delete/{role}")]
        public async Task RemoveFromRoleAsync([FromBody] User user, string role) => await _usersStore.RemoveFromRoleAsync(user, role);

        [HttpPost("Roles")]
        public async Task<IList<string>> GetRolesAsync([FromBody] User user) => await _usersStore.GetRolesAsync(user);

        [HttpPost("InRole/{role}")]
        public async Task<bool> IsInRoleAsync([FromBody] User user, string role) => await _usersStore.IsInRoleAsync(user, role);

        [HttpPost("UsersInRole/{role}")]
        public async Task<IList<User>> GetUsersInRoleAsync(string role) => await _usersStore.GetUsersInRoleAsync(role);

        [HttpPost("GetPasswordHash")]
        public async Task<string> GetPasswordHashAsync([FromBody] User user) => await _usersStore.GetPasswordHashAsync(user);

        [HttpPost("SetPasswordHash")]
        public async Task<string> SetPasswordHashAsync([FromBody] PasswordHashDTO hash)
        {
            await _usersStore.SetPasswordHashAsync(hash.user, hash.Hash);
            return hash.user.PasswordHash;
        }

        [HttpPost("HasPassword")]
        public async Task<bool> HasPasswordAsync([FromBody] User user) => await _usersStore.HasPasswordAsync(user);
        #endregion

        #region Claims
        [HttpPost("GetClaims")]
        public async Task<IList<Claim>> GetClaimsAsync([FromBody] User user) => await _usersStore.GetClaimsAsync(user);

        [HttpPost("AddClaims")]
        public async Task AddClaimsAsync([FromBody] AddClaimDTO ClaimInfo) => await _usersStore.AddClaimsAsync(ClaimInfo.user, ClaimInfo.claims);

        [HttpPost("ReplaseClaim")]
        public async Task ReplaseClaimAsync([FromBody] ReplaceClaimDTO ClaimInfo) =>
            await _usersStore.ReplaceClaimAsync(ClaimInfo.user, ClaimInfo.claim, ClaimInfo.newClaim);

        [HttpPost("RemoveClaim")]
        public async Task RemoveClaimsAsync([FromBody] RemoveClaimDTO ClaimInfo) =>
            await _usersStore.RemoveClaimsAsync(ClaimInfo.user, ClaimInfo.claims);

        [HttpPost("GetUsersForClaim")]
        public async Task<IList<User>> GetUsersForClaimAsync([FromBody] Claim claim) =>
            await _usersStore.GetUsersForClaimAsync(claim);
        #endregion

        #region TwoFactor
        [HttpPost("GetTwoFactorEnabled")]
        public async Task GetTwoFactorEnabledAsync([FromBody] User user) =>
            await _usersStore.GetTwoFactorEnabledAsync(user);

        [HttpPost("SetTwoFactor/{enable}")]
        public async Task SetTwoFactorEnabledAsync([FromBody] User user, bool enable) =>
            await _usersStore.SetTwoFactorEnabledAsync(user, enable);
        #endregion

        #region Email
        [HttpPost("GetEmail")]
        public async Task<string> GetEmailAsync([FromBody] User user) =>
            await _usersStore.GetEmailAsync(user);

        [HttpPost("SetEmail/{email}")]
        public async Task SetEmailAsync([FromBody]User user, string email) =>
            await _usersStore.SetEmailAsync(user,email);

        [HttpPost("GetEmailConfirmed")]
        public async Task<bool> GetEmailConfirmedAsync([FromBody] User user) =>
            await _usersStore.GetEmailConfirmedAsync(user);

        [HttpPost("SetEmailConfirmed/{enable}")]
        public async Task SetEmailConfirmedAsync([FromBody] User user, bool enable) =>
            await _usersStore.SetEmailConfirmedAsync(user, enable);

        [HttpGet("FindByEmail/{email}")]
        public async Task<User> FindByEmailAsync(string email) => await _usersStore.FindByEmailAsync(email);

        [HttpPost("GetNormalizedEmail")]
        public async Task<string> GetNormalizedEmailAsync([FromBody] User user) =>
            await _usersStore.GetNormalizedEmailAsync(user);

        [HttpPost("SetNormalizedEmail/{email?}")]
        public async Task SetNormalizedEmailAsync([FromBody] User user, string email) =>
            await _usersStore.SetNormalizedEmailAsync(user, email);

        [HttpPost("GetPhoneNumber")]
        public async Task<string> GetPhoneNumberAsync([FromBody] User user) =>
            await _usersStore.GetPhoneNumberAsync(user);

        [HttpPost("SetPhoneNumber/{phone}")]
        public async Task SetPhoneNumberAsync([FromBody] User user, string phone) =>
            await _usersStore.SetPhoneNumberAsync(user, phone);

        [HttpPost("GetPhoneNumberConfirmed")]
        public async Task<bool> GetPhoneNumberConfirmedAsync([FromBody] User user) =>
            await _usersStore.GetPhoneNumberConfirmedAsync(user);

        [HttpPost("SetPhoneNumberConfirmed/{confirmed}")]
        public async Task SetPhoneNumberConfirmedAsync([FromBody] User user, bool confirmed) =>
            await _usersStore.SetPhoneNumberConfirmedAsync(user, confirmed);
        #endregion

        #region Login/Lockout
        [HttpPost("AddLogin")]
        public async Task AddLoginAsync([FromBody] AddLoginDTO login) =>
            await _usersStore.AddLoginAsync(login.user, login.userLoginInfo);

        [HttpPost("RemoveLogin/{loginProvider}/{providerKey}")]
        public async Task RemoveLoginAsync([FromBody] User user, string loginProvider, string providerKey) =>
            await _usersStore.RemoveLoginAsync(user, loginProvider, providerKey);

        [HttpPost("GetLogin")]
        public async Task<IList<UserLoginInfo>> GetLoginAsync([FromBody] User user) =>
            await _usersStore.GetLoginsAsync(user);

        [HttpGet("FindByLogin/{loginProvider}/{providerKey}")]
        public async Task<User> FindByLoginAsync(string loginProvider, string providerKey) =>
            await _usersStore.FindByLoginAsync(loginProvider, providerKey);

        [HttpPost("GetLockoutEndDate")]
        public async Task<DateTimeOffset?> GetLockoutEndDateAsync([FromBody] User user) =>
            await _usersStore.GetLockoutEndDateAsync(user);

        [HttpPost("SetLockoutEndDate")]
        public async Task SetLockoutEndDateAsync([FromBody] SetLockoutDTO lockoutInfo) =>
            await _usersStore.SetLockoutEndDateAsync(lockoutInfo.user, lockoutInfo.lockoutEnd);

        [HttpPost("IncrementAccessFailedCount")]
        public async Task<int> IncrementAccessFailedCountAsync([FromBody] User user) =>
            await _usersStore.IncrementAccessFailedCountAsync(user);

        [HttpPost("ResetAccessFailedCount")]
        public async Task ResetAccessFailedCountAsync([FromBody]User user) =>
            await _usersStore.ResetAccessFailedCountAsync(user);

        [HttpPost("GetAccessFailedCount")]
        public async Task<int> GetAccessFailedCountAsync([FromBody] User user) =>
            await _usersStore.GetAccessFailedCountAsync(user);

        [HttpPost("GetLockoutEnabled")]
        public async Task<bool> GetLockoutEnabledAsync([FromBody] User user) =>
            await _usersStore.GetLockoutEnabledAsync(user);

        [HttpPost("SetLockoutEnabled/{enable}")]
        public async Task SetLockoutEnabledAsync([FromBody] User user, bool enable) =>
            await _usersStore.SetLockoutEnabledAsync(user, enable);
        #endregion
    }
}