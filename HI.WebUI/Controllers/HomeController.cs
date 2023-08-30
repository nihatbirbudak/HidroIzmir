using HI.BLL.Services.Abstract;
using HI.BLL.Services.HIServices;
using HI.Model;
using HI.WebUI.Models;
using HI.WebUI.Models.HomeViewModel;
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
        private readonly ISliderService sliderService;
        private readonly IAboutService aboutService;
        private readonly IContactPageService contactPageService;
        private readonly IDealersService dealersService;
        private readonly IimagePathService imagePathService;

        public HomeController(ILogger<HomeController> logger,
            IContactService contactService,
            IProductService productService,
            ICategoryService categoryService,
            IMainCategoryService mainCategoryService,
            ISliderService sliderService,
            IAboutService aboutService,
            IContactPageService contactPageService,
            IDealersService dealersService,
            IimagePathService imagePathService)
        {
            _logger = logger;
            this.contactService = contactService;
            this.productService = productService;
            this.categoryService = categoryService;
            this.mainCategoryService = mainCategoryService;
            this.sliderService = sliderService;
            this.aboutService = aboutService;
            this.contactPageService = contactPageService;
            this.dealersService = dealersService;
            this.imagePathService = imagePathService;
        }

        public IActionResult Index()
        {
            var model = new IndexViewModel();
            model.Sliders = sliderService.getAll();
            model.Dealers = dealersService.getAll();
            model.ContactPage = contactPageService.getEntity();
            model.Products = productService.GetHomePageProduct();
            return View(model);
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
            var model = new ContactViewModel();
            model.ContactPage = contactPageService.getEntity();
            return View(model);
        }

        public IActionResult About(string name)
        {
            var model = new AboutViewModel();
            model.Name = name;
            model.About = aboutService.getEntity(1);
            model.ContactPage = contactPageService.getEntity();
            return View(model);
        }

        public IActionResult ProductList()
        {
            var model = new ProductListViewModel();
            model.Products = productService.getAll();
            model.Categories = categoryService.getAll();
            model.MainCategories = mainCategoryService.getAll();
            model.ContactPage = contactPageService.getEntity();
            return View(model);
        }

        public IActionResult ProductListDetail(int id) 
        {
            var model = new ProductListViewModel();
            model.Products = productService.GetProdcutstoCategoryId(id);
            model.Categories = categoryService.getAll();
            model.MainCategories = mainCategoryService.getAll();
            model.ContactPage = contactPageService.getEntity();
            return View(model);
        }


        public IActionResult ProductDetail(int id)
        {
            var model = new ProdcutDetailHomeViewModel();
            model.ContactPage = contactPageService.getEntity();
            model.Product = productService.getEntity(id);
            model.ImagePaths = imagePathService.getImagePathtoProdcutId(id);
            return View(model);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}