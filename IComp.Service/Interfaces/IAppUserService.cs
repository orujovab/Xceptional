using IComp.Core.Entities;
using IComp.Service.DTOs.AppUserDTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Interfaces
{
    public interface IAppUserService
    {
        Task<bool> RegisterUser(AppUserRegisterPostDto viewModel);
        Task<List<IdentityRole>> GetRolesAsync();
        Task DeleteAdmin(string id);

    }
}
