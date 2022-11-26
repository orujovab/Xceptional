using IComp.Core;
using IComp.Core.Entities;
using IComp.Service.DTOs.AppUserDTOs;
using IComp.Service.Exceptions;
using IComp.Service.Helpers;
using IComp.Service.Implementations;
using IComp.Service.Interfaces;
using IComp.Service.Utils;
using IComp.Service.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IComp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _env;
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IProductService productService, IWebHostEnvironment env, IUnitOfWork unitOfWork)
        {
            _signInManager = signInManager;
            _productService = productService;
            _env = env;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }


        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(AppUserRegisterPostDto postDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var appUser = await _userManager.FindByNameAsync(postDto.UserName);

            if (appUser != null)
            {
                ModelState.AddModelError("UserName", "The user has already logged in");
                return View();
            }

            appUser = new AppUser
            {
                UserName = postDto.UserName,
                Email = postDto.Email,
                FullName = postDto.FullName,
                IsAdmin = false
            };

            var result = await _userManager.CreateAsync(appUser, postDto.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            var role = await _userManager.AddToRoleAsync(appUser, "Member");

            if (!role.Succeeded)
            {
                foreach (var error in role.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            await _signInManager.SignInAsync(appUser, true);
            TempData["Success"] = "Succesfully registered and logged in.";
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public async Task<IActionResult> Login(AppUserLoginPostDto postDto)
        {


            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));

                return BadRequest(message);
            }

            var appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == postDto.UserName && !x.IsAdmin);

            if (appUser == null)
            {
                return BadRequest("UserName or Password is incorrect");
            }

            var result = await _signInManager.PasswordSignInAsync(appUser, postDto.Password, postDto.IsPersistent, false);

            if (!result.Succeeded)
            {
                return BadRequest("UserName or Password is incorrect");

            }



            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData["Success"] = "Succesfully Logged Out.";
            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> Profile()
        {
            AppUser appUser = null;
            if (User.Identity.IsAuthenticated)
            {
                appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            }

            if (appUser == null || appUser.IsAdmin)
            {
                return BadRequest("user not found");
            }

            var orders = await _productService.GetOrdersAsync(appUser);

            var profileVM = new ProfileViewModel
            {
                UserUpdate = new UserUpdateViewModel
                {
                    FullName = appUser.FullName,
                    UserName = appUser.UserName,
                    Email = appUser.Email,
                },
                Orders = orders
            };

            return View(profileVM);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(UserUpdateViewModel userUpdateVM)
        {
            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);

            if (appUser == null || appUser.IsAdmin)
            {
                throw new ItemNotFoundException("User not found");
            }

            var orders = await _productService.GetOrdersAsync(appUser);

            var profileVM = new ProfileViewModel
            {
                Orders = orders,
                UserUpdate = userUpdateVM
            };

            if (!ModelState.IsValid)
            {
                return View(profileVM);
            }

            if (appUser.UserName != userUpdateVM.UserName && _userManager.Users.Any(x => x.NormalizedUserName == userUpdateVM.UserName.ToUpper()))
            {
                ModelState.AddModelError("UserName", "UserName has already taken");
                return View(profileVM);
            }

            if (appUser.Email != userUpdateVM.Email && _userManager.Users.Any(x => x.NormalizedEmail == userUpdateVM.Email.ToUpper()))
            {
                ModelState.AddModelError("Email", "Email has already taken");
                return View(profileVM);
            }

            appUser.FullName = userUpdateVM.FullName;
            appUser.UserName = userUpdateVM.UserName;
            appUser.Email = userUpdateVM.Email;

            var result = await _userManager.UpdateAsync(appUser);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(profileVM);
            }
            if (userUpdateVM.Password != null)
            {
                if (string.IsNullOrWhiteSpace(userUpdateVM.CurrentPassword))
                {
                    ModelState.AddModelError("CurrentPassword", "CurrentPassword is required!");
                    return View(profileVM);
                }
                if (userUpdateVM.CurrentPassword == userUpdateVM.Password)
                {
                    ModelState.AddModelError("CurrentPassword", "New password is same with current password");
                    return View(profileVM);
                }
                if (!await _userManager.CheckPasswordAsync(appUser, userUpdateVM.CurrentPassword))
                {
                    ModelState.AddModelError("CurrentPassword", "CurrentPassword is incorrect!");
                    return View(profileVM);
                }

                var passResult = _userManager.ChangePasswordAsync(appUser, userUpdateVM.CurrentPassword, userUpdateVM.Password);

                if (!passResult.Result.Succeeded)
                {
                    foreach (var item in passResult.Result.Errors)
                    {
                        ModelState.AddModelError("Password", item.Description);
                    }
                    return View(profileVM);
                }
            }
            TempData["Success"] = appUser.FullName + " Your Account successfully updated";
            return View(profileVM);
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest();
            }
            var dbUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email && !x.IsAdmin);
            if (dbUser is null)
            {
                throw new ItemNotFoundException("User not found");
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(dbUser);

            string path = _env.WebRootPath + Path.DirectorySeparatorChar.ToString() + "Templates" + Path.DirectorySeparatorChar.ToString() + "EmailTemplates" + Path.DirectorySeparatorChar.ToString() + "ResetPass.html";

            var link = Url.Action("ResetPassword", "Account", new { dbUser.Id, token }, protocol: HttpContext.Request.Scheme);

            Dictionary<string, string> replaces = new Dictionary<string, string>();
            replaces.Add("{url}", link.ToString());

            await EmailUtil.SendEmailAsync(email, "Reset Password", path, replaces);
            return RedirectToAction("index", "home");
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
                return View(resetPasswordVm);
            }

            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> ContactUs()
        {
            AppUser appUser = null;
            if (User.Identity.IsAuthenticated)
            {
                appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == User.Identity.Name && !x.IsAdmin);
            }

            ContactUsViewModel contactUsViewModel = new ContactUsViewModel
            {
                Name = appUser?.UserName,
                Email = appUser?.Email,

            };

            return View(contactUsViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> ContactUs(ContactUsViewModel contactUsViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser appUser = null;
            if (User.Identity.IsAuthenticated)
            {
                appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == User.Identity.Name && !x.IsAdmin);
            }

            FeedBack feedBack = new FeedBack();
            if (appUser != null)
            {
                feedBack = new FeedBack
                {
                    AppUserId = appUser.Id,
                    CreatedAt = DateTime.UtcNow.AddHours(4),
                    ModifiedAt = DateTime.UtcNow.AddHours(4),
                    Name = contactUsViewModel.Name,
                    Email = contactUsViewModel.Email,
                    Text = contactUsViewModel.Text,
                    IsDeleted = false,
                };

                await _unitOfWork.FeedBackRepository.AddAsync(feedBack);
                await _unitOfWork.CommitAsync();

                return RedirectToAction("Index", "Home");
            }
            feedBack = new FeedBack
            {
                CreatedAt = DateTime.UtcNow.AddHours(4),
                ModifiedAt = DateTime.UtcNow.AddHours(4),
                Name = contactUsViewModel.Name,
                Email = contactUsViewModel.Email,
                Text = contactUsViewModel.Text,
                IsDeleted = false,
            };

            await _unitOfWork.FeedBackRepository.AddAsync(feedBack);
            await _unitOfWork.CommitAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
