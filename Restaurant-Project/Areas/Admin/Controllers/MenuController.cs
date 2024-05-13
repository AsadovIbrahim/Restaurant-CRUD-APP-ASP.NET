using Microsoft.AspNetCore.Mvc;
using RestaurantDB.Entities;
using RestaurantDB.Repositories.Abstracts;

namespace Restaurant_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        protected readonly IProductRepository _productRepository;

        public MenuController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
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
            var existingItem =await  _productRepository.GetByIdAsync(id);
            return View(existingItem);
        }

        [HttpPost]

        public IActionResult Update(Menu menu)
        {
            _productRepository.Update(menu);
            return RedirectToAction("Index");
        }
    }
}
