using IComp.Areas.ViewModels;
using IComp.Core;
using IComp.Core.Entities;
using IComp.Data;
using IComp.Service.Exceptions;
using IComp.Service.Interfaces;
using IComp.Service.Utils;
using IComp.Service.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IWebHostEnvironment _env;
        private readonly IAppUserService _appUserService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, IWebHostEnvironment env, StoreDbContext context, IAppUserService appUserService, IUnitOfWork unitOfWork, IProductService productService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _env = env;
            _appUserService = appUserService;
            _unitOfWork = unitOfWork;
            _productService = productService;
        }
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Create()
        {
            var roles = await _appUserService.GetRolesAsync();
            roles = roles.Where(x => x.Name != "SuperAdmin" && x.Name != "Member").ToList();
            AdminRegisterViewModel VM = new AdminRegisterViewModel
            {
                Roles = roles.Select(x => x.Name).ToList(),
            };

            return View(VM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AdminRegisterViewModel admin)
        {
            if (!ModelState.IsValid)
            {
                var roles = await _appUserService.GetRolesAsync();
                roles = roles.Where(x => x.Name != "SuperAdmin" && x.Name != "Member").ToList();
                admin.Roles = roles.Select(x => x.Name).ToList();
                return View(admin);
            }
            AppUser appUser = new AppUser
            {
                FullName = admin.FullName,
                UserName = admin.UserName,
                Email = admin.Email,
                IsAdmin = true
            };

            var result = await _userManager.CreateAsync(appUser, admin.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                var roles = await _appUserService.GetRolesAsync();
                roles = roles.Where(x => x.Name != "SuperAdmin" && x.Name != "Member").ToList();
                admin.Roles = roles.Select(x => x.Name).ToList();
                return View(admin);
            }

            foreach (var role in admin.Roles)
            {
                var result2 = await _userManager.AddToRoleAsync(appUser, role.ToString());

                if (!result2.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    var roles = await _appUserService.GetRolesAsync();
                    admin.Roles = roles.Select(x => x.Name).ToList();
                    return View(admin);
                }
            }

            return RedirectToAction("index", "dashboard");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(AdminLoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View();

            AppUser admin = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == viewModel.UserName && x.IsAdmin);

            if (admin == null)
            {
                ModelState.AddModelError("", "UserName or Password is incorrect");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(admin, viewModel.Password, viewModel.IsPersistent, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "UserName or Password is incorrect");
                return View();
            }

            return RedirectToAction("index", "dashboard");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("login", "account", "manage");
        }

        public async Task<IActionResult> Profile()
        {
            AppUser appUser = null;
            if (User.Identity.IsAuthenticated)
            {
                appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            }

            if (appUser == null || !appUser.IsAdmin)
            {
                return BadRequest("user not found");
            }

            var profileVM = new ProfileViewModel
            {
                UserUpdate = new UserUpdateViewModel
                {
                    FullName = appUser.FullName,
                    UserName = appUser.UserName,
                    Email = appUser.Email,
                },
            };

            return View(profileVM);
        }

        [Authorize(Roles = "SuperAdmin")]
        public IActionResult UserList()
        {
            var users = _userManager.Users.Where(x => x.IsAdmin && x.UserName != "SuperAdmin");
            return View(users);
        }
        [Authorize(Roles = "SuperAdmin")]

        public async Task<IActionResult> Remove(string id)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return BadRequest();
                }
                await _appUserService.DeleteAdmin(id);
                return RedirectToAction("UserList");
            }
            return RedirectToAction("UserList");
        }
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Edit(string id)
        {
            AppUser appUser = await _userManager.FindByIdAsync(id);

            if (appUser == null) return NotFound();

            var currentRoles = await _userManager.GetRolesAsync(appUser);
            
            var Roles = await _appUserService.GetRolesAsync();
            List<string> RoleStr = Roles.Select(x => x.Name).ToList();
            AdminEditViewModel viewModel = new AdminEditViewModel
            {
                CurrentRoles = currentRoles.ToList(),
                Roles = RoleStr.Where(x => x != "SuperAdmin" && x != "Member").ToList(),
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string id, AdminEditViewModel viewModel)
        {
            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (appUser is null)
            {
                return NotFound();
            }
            var roles = await _userManager.GetRolesAsync(appUser);

            if (!ModelState.IsValid)
            {
                AdminEditViewModel VM = new AdminEditViewModel
                {
                    CurrentRoles = roles.ToList(),
                };
                return View(VM);
            }
            await _userManager.RemoveFromRolesAsync(appUser, roles);
            await _userManager.AddToRolesAsync(appUser, viewModel.Roles);
            await _unitOfWork.CommitAsync();
            return RedirectToAction("index", "dashboard");
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.Email))
            {
                return BadRequest();
            }
            var dbUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == viewModel.Email && x.IsAdmin);

            if (dbUser is null)
            {
                throw new ItemNotFoundException("User not found");
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(dbUser);

            string path = _env.WebRootPath + Path.DirectorySeparatorChar.ToString() + "Templates" + Path.DirectorySeparatorChar.ToString() + "EmailTemplates" + Path.DirectorySeparatorChar.ToString() + "ResetPass.html";

            var link = Url.Action("ResetPassword", "Account", new { dbUser.Id, token }, protocol: HttpContext.Request.Scheme);

            Dictionary<string, string> replaces = new Dictionary<string, string>();
            replaces.Add("{url}", link.ToString());

            await EmailUtil.SendEmailAsync(viewModel.Email, "Reset Password", path, replaces);
            return RedirectToAction("login", "account", new {area = "manage"});
        }
        public async Task<IActionResult> ResetPassword(string id, string token)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(token))
                return BadRequest();

            var dbUser = await _userManager.FindByIdAsync(id);
            if (dbUser is null)
                return NotFound();

            ResetPasswordViewModel resetPasswordViewModel = new ResetPasswordViewModel
            {
                Token = token
            };

            return View(resetPasswordViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(string id, ResetPasswordViewModel resetPasswordVm)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(resetPasswordVm.Token))
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return View(resetPasswordVm);
            }

            var dbUser = await _userManager.FindByIdAsync(id);
            if (dbUser is null)
                return NotFound();

            var result = await _userManager.ResetPasswordAsync(dbUser, resetPasswordVm.Token, resetPasswordVm.NewPassword);
            if (result.Errors == null)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            return RedirectToAction("login", "account", new { area = "manage" });

        }

    }
}
