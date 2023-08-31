using HI.BLL.Services.Abstract;
using HI.Model;
using HI.WebUI.Models.AdminModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;


namespace HI.WebUI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : BaseController
    {
        private readonly IContactService contactService;
        private readonly IUserService userService;
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IimagePathService imagePathService;
        private readonly IMainCategoryService mainCategoryService;
        public AdminController(IContactService contactService,
            IUserService userService,
            IProductService productService,
            ICategoryService categoryService,
            IimagePathService imagePathService,
            IMainCategoryService mainCategoryService) 
        {
            this.contactService = contactService;
            this.productService = productService;
            this.userService = userService;
            this.categoryService = categoryService;
            this.imagePathService = imagePathService;
            this.mainCategoryService = mainCategoryService;
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
            var selected = contactService.getEntity(id);
            if (selected.IsRead == false)
            {
                selected.IsRead = true;
                contactService.updateEntity(selected);
            }
            var model = new ContactDeailViewModel();
            model.User = CurrentUser;
            model.Contact = contactService.getEntity(id);
            return View(model);
        }


        #region Product
        public ActionResult ProductDetail(int id) 
        {
            var model = new ProductDetailViewModel();
            model.User = CurrentUser;
            model.Products = productService.getAll();
            model.Categories = categoryService.getAll();
            return View(model);
        }

        public IActionResult ProductAdd()
        {
            var model = new ProdcutAddViewModel();
            model.User = CurrentUser;
            model.Categories = categoryService.getAll();
            return View(model);
        }
        [HttpPost]
        public IActionResult ProductAdd(Product product, IFormFile file)
        {
            if (!productService.getAll().Any(z => z.Name == product.Name))
            {
                productService.newEntity(product);
            }
            return RedirectToAction("ProductDetail");
        }
        public ActionResult ProductActiveChange(int id) 
        {
            var selected = productService.getEntity(id);
            if (selected.Active == true)
            {
                selected.Active = false;
                productService.updateEntity(selected);
            }
            else
            {
                selected.Active=true;
                productService.updateEntity(selected);
            }
            return RedirectToAction("ProductDetail");
        }
        public ActionResult ProductChange(int id) 
        {
            var model = new ProductChangeViewModel();
            model.User = CurrentUser;
            model.Product = productService.getEntity(id);
            model.Categories = categoryService.getAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult ProductChange(Product product)
        {
            productService.updateEntity(product);
            return RedirectToAction("ProductDetail");
        }
        
        public ActionResult ProductDelete(int id)
        {
            //DeleteFile(productService.getEntity(id));
            productService.deleteEntity(id);
            return RedirectToAction("ProductDetail");
        }
        #endregion

        #region File
        public async void AddFile(IFormFile file, Product product)
        {
            if (file != null)
            {
                var extention = Path.GetExtension(file.FileName);
                var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\images\\ProductImages", randomName);
                var entityPath = new ImagePath();
                entityPath.Path = randomName;
                entityPath.ProductId = product.Id;
                imagePathService.newEntity(entityPath);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
        }
        
        public void DeleteFile(ImagePath imagePath)
        {
            if (imagePath.Path != null)
            {
                var pathDelete = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\images\\ProductImages", imagePath.Path);
                FileInfo fi = new FileInfo(pathDelete);
                if (fi != null)
                {
                    System.IO.File.Delete(pathDelete);
                    fi.Delete();
                }
            }
        }
        
        public IActionResult FileUpdate(int id)
        {
            var model = new ProductChangeViewModel();
            model.User = CurrentUser;
            model.Product = productService.getEntity(id);
            model.ImagePaths = imagePathService.getImagePathtoProdcutId(id);
            return View(model);
        }
        
        [HttpPost]
        public IActionResult FileUpdate(List<IFormFile> file,int id)
        {
            if (file.Count > 0)
            {
                foreach (var item in file)
                {
                    var product = productService.getEntity(id);
                    AddFile(item, product);
                }
            }
            return RedirectToAction("FileUpdate");
        }
        public IActionResult FileDelete(int id)
        {
            var imagePath = imagePathService.getEntity(id);
            var route = imagePath.ProductId;
            DeleteFile(imagePath);
            imagePathService.deleteEntity(id);
            return RedirectToAction("FileUpdate",new {id = route});
        }
        #endregion

        #region Category
        public IActionResult CategoryList() 
        {
            var model = new CategoryListViewModel();
            model.User = CurrentUser;
            model.MainCategories = mainCategoryService.getAll();
            model.Categories = categoryService.getAll();
            return View(model); 
        }
        public IActionResult MainCategoryAdd(MainCategory mainCategory) 
        {
            if (!mainCategoryService.getAll().Any(z => z.Name == mainCategory.Name))
            {
                mainCategoryService.newEntity(mainCategory);
            }
            return RedirectToAction("CategoryList");
        }
        public IActionResult MainCategoryDelete(int id) 
        {
            if (!categoryService.getAll().Any(z => z.MainCategoryId == id))
            {
                mainCategoryService.deleteEntity(id);
            }
            return RedirectToAction("CategoryList");
        }

        [HttpPost]
        public ActionResult CategoryAdd(Category category)
        {
            if (!categoryService.getAll().Any(z => z.Name == category.Name))
            {
                categoryService.newEntity(category);
            }
            return RedirectToAction("CategoryList");
        }
        public ActionResult CategoryDelete(int id)
        {
            if (!productService.getAll().Any(z => z.CategoryId == id))
            {
                categoryService.deleteEntity(id);
            }
            return RedirectToAction("ProductDetail");
        }

        #endregion
    }
}
