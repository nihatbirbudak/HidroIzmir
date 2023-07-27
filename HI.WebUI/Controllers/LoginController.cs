using HI.BLL.Services.Abstract;
using HI.WebUI.Core;
using HI.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HI.WebUI.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        public LoginController(IUserService userService, IRoleService roleService)
        {
            this.userService = userService;
            this.roleService = roleService;
        }

        #region UserLoginPat
        public IActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserLogin(LoginViewModel userModel)
        {
            var user = userService.FindwithUsernameandMail(userModel.UserName, userModel.Password);
            if (user != null)
            {
                user.Role = roleService.getEntity((int)user.Role.Id);
                var userClaims = new List<Claim>()
                {
                    new Claim("User",HIConvert.HIJsonSerialize(user))
                };
                var userIdentity = new ClaimsIdentity(userClaims, "User Identity");
                var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                var userPros = new AuthenticationProperties
                {
                    IsPersistent = userModel.RememberMe,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(60)
                };
                HttpContext.SignInAsync(userPrincipal, userPros);
                if (user.rememberMe != userModel.RememberMe)
                {
                    user.rememberMe = userModel.RememberMe;
                    userService.updateEntity(user);
                }
                return RedirectToAction("HomePage", "Admin");
            }
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("UserLogin");
        }
        public ActionResult AccessDenied()
        {
            return View();
        }
        #endregion
    }
}
