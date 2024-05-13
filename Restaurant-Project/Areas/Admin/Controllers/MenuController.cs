using Microsoft.AspNetCore.Mvc;
using RestaurantDB.Entities;
using RestaurantDB.Repositories.Abstracts;

namespace Restaurant_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        protected readonly IProductRepository _productRepository;
        protected readonly IWebHostEnvironment _webHostEnvironment;

        public MenuController(IProductRepository productRepository, IWebHostEnvironment webHostEnvironment)
        {
            _productRepository = productRepository;
            _webHostEnvironment = webHostEnvironment;

        }
        public async Task<IActionResult> Index()
        {
            var menus = await _productRepository.GetAllAsync();
            return View(menus);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Menu menu)
        {
            if (!ModelState.IsValid)
            {
                return View(menu);
            }

            string path = _webHostEnvironment.WebRootPath + @"\Upload\Menu\";
            string fileName = Guid.NewGuid() + menu.ImgFile.FileName;
            using (FileStream stream = new FileStream(path + fileName, FileMode.Create))
            {
                menu.ImgFile.CopyTo(stream);
            }
            menu.ImageUrl = fileName;

            await _productRepository.AddAsync(menu);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Remove(int id)
        {
            await _productRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var existingItem = await _productRepository.GetByIdAsync(id);
            return View(existingItem);
        }


        [HttpPost]
        public IActionResult Update(Menu menu)
        {
            if (!ModelState.IsValid)
            {
                return View(menu);
            }

            if (menu.ImgFile != null)
            {
                string path = _webHostEnvironment.WebRootPath + @"\Upload\Menu\";
                string fileName = Guid.NewGuid().ToString() + menu.ImgFile.FileName;
                string filePath = Path.Combine(path, fileName);

                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    menu.ImgFile.CopyTo(stream);
                }

                menu.ImageUrl = fileName;
            }
            _productRepository.Update(menu);
            return RedirectToAction("Index");
        }

    }
}
