using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotebookMarket.Models;
using NotebookMarket.ViewModels;

namespace NotebookMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILaptopRepository _laptopRepository;
        public HomeController(ILaptopRepository laptopRepository)
        {
            _laptopRepository = laptopRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel()
            {
                LaptopsOnDiscount = _laptopRepository.LaptopsOnDiscount
            };
            return View(homeViewModel);
        }
    }
}
