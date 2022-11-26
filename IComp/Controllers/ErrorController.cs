using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace IComp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error()
        {
            return PartialView("_Error");
        }
    }
}
