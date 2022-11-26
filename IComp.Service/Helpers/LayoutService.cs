using IComp.Core;
using IComp.Core.Entities;
using IComp.Service.DTOs.AppUserDTOs;
using IComp.Service.Exceptions;
using IComp.Service.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Helpers
{
    public class LayoutService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;


        public LayoutService(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<Dictionary<string,string>> GetSetting()
        {
            return await _unitOfWork.SettingRepository.GetAll().ToDictionaryAsync(x => x.Key , x => x.Value);
        }

        public async Task<List<Category>> GetCagegories()
        {
            return await _unitOfWork.CategoryRepository.GetAll(x => !x.IsDeleted).ToListAsync();
        }
        public AppUserLoginPostDto GetLoginPost()
        {
            return new AppUserLoginPostDto();
        }

        public async Task<CommonBasketViewModel> GetBasketItems()
        {
            CommonBasketViewModel basketItems = new CommonBasketViewModel
            {
                BasketItems = new List<BasketProductViewModel>(),
                TotalPrice = 0
            };

            List<BasketCookieItemViewModel> cookieItems = new List<BasketCookieItemViewModel>();

            AppUser appUser = null;

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name && !x.IsAdmin);
            }

            if (appUser == null)
            {
                string cookieItemsStr = _httpContextAccessor.HttpContext.Request.Cookies["basket"];

                if (!string.IsNullOrWhiteSpace(cookieItemsStr))
                {
                    cookieItems = JsonConvert.DeserializeObject<List<BasketCookieItemViewModel>>(cookieItemsStr);

                }
            }
            else
            {
                cookieItems = _unitOfWork.BasketItemRepository.GetAll(x => x.AppUserId == appUser.Id).Select(b => new BasketCookieItemViewModel { ProductId = b.ProductId, Count = b.Count }).ToList();
            }



            foreach (var item in cookieItems)
            {
                var product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == item.ProductId, "ProductImages");

                if (product != null)
                {
                    BasketProductViewModel basketProduct = new BasketProductViewModel
                    {
                        Product = product,
                        Count = item.Count
                    };

                    basketItems.BasketItems.Add(basketProduct);
                    decimal totalPrice = product.DiscountPercent > 0 ? (product.SalePrice * (1 - product.DiscountPercent / 100)) : product.SalePrice;
                    basketItems.TotalPrice += totalPrice * item.Count;
                }
            }

            return basketItems;
        }
    }
}
