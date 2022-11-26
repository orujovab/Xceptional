using IComp.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Core.Repositories
{
    public interface IAppUserRepository : IRepository<AppUser>
    {
        Task<List<IdentityRole>> GetRolesAsync();
        Task DeleteAdmin(string id);
    }
}
