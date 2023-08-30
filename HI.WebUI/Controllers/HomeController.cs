using HI.BLL.Services.Abstract;
using HI.Model;
using HI.WebUI.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Diagnostics;


namespace HI.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContactService contactService;
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IMainCategoryService mainCategoryService;

        public HomeController(ILogger<HomeController> logger,IContactService contactService,IProductService productService,ICategoryService categoryService,IMainCategoryService mainCategoryService)
        {
            _logger = logger;
            this.contactService = contactService;
            this.productService = productService;
            this.categoryService = categoryService;
            this.mainCategoryService = mainCategoryService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ContactAddIndex(Contact contact) 
        {
            var mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Sistem Mail", "test.arzmedya@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            var mailboxAddressTo = new MailboxAddress("Admin", "nihatbirbudak.94@hotmail.com");
            mimeMessage.To.Add(mailboxAddressTo);

            if (contact.Title == null)
            {
                contact.Title = "Anasayfa iletişim isteği";
                contact.Context = "Anasayfa iletişim isteği";
            }
            mimeMessage.Subject = contact.Title;

            var bodyBuiler = new BodyBuilder();
            bodyBuiler.TextBody = string.Format(@"Mesaj:{0},

Ad: {1}
Mail: {2}
Telefon: {3}", contact.Context, contact.Name,contact.Email,contact.Phone);
            mimeMessage.Body = bodyBuiler.ToMessageBody();

            using (var client = new SmtpClient()) {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("test.arzmedya@gmail.com", "wkubwcohrcubahnt");
                client.Send(mimeMessage);
                client.Disconnect(true);
            }

            contact.UploadTime = DateTime.UtcNow;
            contactService.newEntity(contact);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact() 
        {

            return View();
        }

        public IActionResult About(string name)
        {
            ViewBag.Name = name;
            return View();
        }

        public IActionResult ProductList()
        {
            var model = new ProductListViewModel();
            model.Products = productService.getAll();
            model.Categories = categoryService.getAll();
            model.MainCategories = mainCategoryService.getAll();
            return View(model);
        }

        public IActionResult ProductListDetail(int id) 
        {
            var model = new ProductListViewModel();
            model.Products = productService.GetProdcutstoCategoryId(id);
            model.Categories = categoryService.getAll();
            model.MainCategories = mainCategoryService.getAll();
            return View(model);
        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}