using HI.BLL.Services.Abstract;
using HI.BLL.Services.HIServices;
using HI.WebUI.Core;
using HI.WebUI.Models;
using HI.WebUI.Models.AdminModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace HI.WebUI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : BaseController
    {
        private readonly IContactService contactService;
        public AdminController(IContactService contactService) 
        {
            this.contactService = contactService;
        }
        public ActionResult Index(string filter, int page = 1)
        {
            var model = new AdminIndexViewModel();
            model.User = CurrentUser;
            model.Contacts = contactService.getAll();
            if (filter == "UnRead")
            {
                model.Value = contactService.getAll().Where(z => z.IsRead == false).ToPagedList(page, 20);
            }
            else
            {
                model.Value = contactService.getAll().OrderBy(z => z.UploadTime).Reverse().ToPagedList(page, 20);
            }
            return View(model);
        }

        public ActionResult ContactDetail (int id)
        {
            return View();
        }

    }
}
