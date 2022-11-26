using FluentValidation.AspNetCore;
using IComp.Core;
using IComp.Core.Entities;
using IComp.Data;
using IComp.Service.DTOs.ProcessorDTOs;
using IComp.Service.Helpers;
using IComp.Service.Implementations;
using IComp.Service.Interfaces;
using IComp.Service.Profiles;
using IComp.Service.Utils;
using IComp.ServiceExtentions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace IComp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            services.AddDbContext<StoreDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("Default"));
            }).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProcessorPostDTOValidator>());
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProcessorService, ProcessorService>();
            services.AddScoped<IProcessorSerieService, ProcessorSerieService>();
            services.AddScoped<IVideoCardService, VideoCardService>();
            services.AddScoped<IVCSerieService, VCSerieService>();
            services.AddScoped<IMemoryService, MemoryService>();
            services.AddScoped<IMemoryCapacityService, MemoryCapacityService>();
            services.AddScoped<IHardDiscService, HardDiscService>();
            services.AddScoped<IHardDiscCapacityService, HardDiscCapacityService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IDestinationService, DestinationService>();
            services.AddScoped<IProdTypeService, ProdTypeService>();
            services.AddScoped<IMotherBoardService, MotherBoardSevice>();
            services.AddScoped<ISoftwareService, SoftwareService>();
            services.AddScoped<ISSDCapacityService, SSDCapacityService>();
            services.AddScoped<ISSDService, SSDService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IFeedBackService, FeedBackService>();
            services.AddScoped<LayoutService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddIdentity<AppUser, IdentityRole>(c =>
            {
                c.Password.RequireDigit = true;
                c.Password.RequiredLength = 8;
                c.Password.RequireUppercase = true;
                c.Password.RequireNonAlphanumeric = false;
                c.User.RequireUniqueEmail = true;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<StoreDbContext>();

            services.AddAutoMapper(cnf =>
            {
                cnf.AddProfile(new MapProfile());
            });

            Constant.EmailAddress = Configuration["Gmail:emailAddress"];
            Constant.Password = Configuration["Gmail:Password"];
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.ExceptionHandler();

            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "Areas",
                   pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                   );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
