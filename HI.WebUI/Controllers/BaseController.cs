using HI.Model;
using HI.WebUI.Core;
using Microsoft.AspNetCore.Mvc;

namespace HI.WebUI.Controllers
{
    public class BaseController : Controller
    {
        public User CurrentUser
        {
            get
            {
                var customerjson = HttpContext.User.Claims.FirstOrDefault(z => z.Type == "User").Value;
                return HIConvert.HIJsonDeSerializeUser(customerjson);
            }
        }
    }
}
