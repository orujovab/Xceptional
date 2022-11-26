using IComp.Core.Entities;
using IComp.Core.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Data.Repositories
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        private readonly StoreDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public AppUserRepository(StoreDbContext context, UserManager<AppUser> userManager) : base(context)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task DeleteAdmin(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user.UserName == "SuperAdmin")
            {
                throw new Exception("This user is superadmin");
            }

            var logins = await _userManager.GetLoginsAsync(user);
            var rolesForUser = await _userManager.GetRolesAsync(user);

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                var result = IdentityResult.Success;
                foreach (var login in logins)
                {
                    result = await _userManager.RemoveLoginAsync(user, login.LoginProvider, login.ProviderKey);
                    if (result != IdentityResult.Success)
                        break;
                }
                if (result == IdentityResult.Success)
                {
                    foreach (var item in rolesForUser)
                    {
                        result = await _userManager.RemoveFromRoleAsync(user, item);
                        if (result != IdentityResult.Success)
                            break;
                    }
                }
                if (result == IdentityResult.Success)
                {
                    result = await _userManager.DeleteAsync(user);
                    if (result == IdentityResult.Success)
                        transaction.Commit();
                }
            }
        }

        public async Task<List<IdentityRole>> GetRolesAsync()
        {
            var roleStore = new RoleStore<IdentityRole>(_context);
            List<IdentityRole> roles = await roleStore.Roles.ToListAsync();
            return roles;
        }
    }
}
