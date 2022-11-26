using IComp.Core.Entities;
using IComp.Service.Exceptions;
using IComp.Service.Interfaces;
using IComp.Service.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin, Admin, Reader, Editor")]
    public class ContactUsController : Controller
    {
        private readonly IFeedBackService _feedBackService;
        private readonly IWebHostEnvironment _env;

        public ContactUsController(IFeedBackService feedBackService, IWebHostEnvironment env)
        {
            _feedBackService = feedBackService;
            _env = env;
        }

        public IActionResult Index(int page = 1)
        {
            var feedBacks = _feedBackService.GetAll(page);

            return View(feedBacks);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var feedBack = await _feedBackService.GetByIdAsync(id);
            if (feedBack.IsDeleted)
            {
                TempData["Error"] = "You answered the question";
                return RedirectToAction("Index");
            }
            return View(feedBack);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(FeedBack feedBackPost)
        {

            var feedBack = await _feedBackService.GetByIdAsync(feedBackPost.Id);

            try
            {
                if (feedBack.Name != feedBackPost.Name || feedBack.Email != feedBackPost.Email || feedBack.Text != feedBackPost.Text)
                {
                    throw new ItemNotFoundException("Item not found");
                }
            }
            catch (ItemNotFoundException)
            {
                TempData["Warning"] = "you can just answer the question";
                return RedirectToAction("Index");
            }
            await _feedBackService.UpdateAsync(feedBackPost);

            string path = _env.WebRootPath + Path.DirectorySeparatorChar.ToString() + "Templates" + Path.DirectorySeparatorChar.ToString() + "EmailTemplates" + Path.DirectorySeparatorChar.ToString() + "contactus.html";

            Dictionary<string, string> replaces = new Dictionary<string, string>();
            replaces.Add("{question}", feedBack.Text);
            replaces.Add("{answer}", feedBack.Answer);
            replaces.Add("{root}", _env.WebRootPath.ToString());
            await EmailUtil.SendEmailAsync(feedBack.Email, "Cavab", path, replaces);
            return RedirectToAction("Index");
        }
    }
}
