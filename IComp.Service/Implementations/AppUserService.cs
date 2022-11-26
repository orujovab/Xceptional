using IComp.Core;
using IComp.Core.Entities;
using IComp.Service.DTOs.AppUserDTOs;
using IComp.Service.Helpers;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Implementations
{
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;

        public AppUserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IUnitOfWork unitOfWork)
        {
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task DeleteAdmin(string id)
        {
            await _unitOfWork.AppUserRepository.DeleteAdmin(id);
        }

        public async Task<List<IdentityRole>> GetRolesAsync()
        {
            return await _unitOfWork.AppUserRepository.GetRolesAsync();
            
        }

        public async Task<bool> RegisterUser(AppUserRegisterPostDto viewModel)
        {
            var appUser = await _userManager.FindByNameAsync(viewModel.UserName);

            appUser = new AppUser
            {
                UserName = viewModel.UserName,
                Email = viewModel.Email,
                FullName = viewModel.FullName,
                IsAdmin = false
            };

            var result = await _userManager.CreateAsync(appUser, viewModel.Password);

            await _signInManager.SignInAsync(appUser, true);
            return true;
        }

       
    }
}
