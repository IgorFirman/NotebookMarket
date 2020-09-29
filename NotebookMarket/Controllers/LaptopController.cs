using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotebookMarket.Models;
using NotebookMarket.ViewModels;

namespace NotebookMarket.Controllers
{
    public class LaptopController : Controller
    {
        private readonly ILaptopRepository _laptopRepository;
        private readonly ICategoryRepository _categoryRepository;

        public LaptopController(ILaptopRepository laptopRepository, ICategoryRepository categoryRepository)
        {
            _laptopRepository = laptopRepository;
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult List(string category)
        {
            IEnumerable<Laptop> laptops;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                laptops = _laptopRepository.AllLaptops.OrderBy(l => l.LaptopId);
                currentCategory = "Усі ноутбуки";
            }
            else
            {
                laptops = _laptopRepository.AllLaptops.Where(p => p.Category.CategoryName == category)
                    .OrderBy(l => l.LaptopId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new LaptopListViewModel
            {
                Laptops = laptops,
                CurrentCategory = currentCategory
            });
        }

        public IActionResult Details(int id)
        {
            var laptop = _laptopRepository.GetLaptopById(id);
            if (laptop == null)
                return NotFound();

            return View(laptop);
        }
    }
}
