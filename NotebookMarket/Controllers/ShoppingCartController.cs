using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotebookMarket.Models;
using NotebookMarket.ViewModels;

namespace NotebookMarket.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ILaptopRepository _pieRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(ILaptopRepository pieRepository, ShoppingCart shoppingCart)
        {
            _pieRepository = pieRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int pieId)
        {
            var selectedPie = _pieRepository.AllLaptops.FirstOrDefault(p => p.LaptopId == pieId);

            if (selectedPie != null)
            {
                _shoppingCart.AddToShoppingCart(selectedPie, 1);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int pieId)
        {
            var selectedPie = _pieRepository.AllLaptops.FirstOrDefault(p => p.LaptopId == pieId);

            if (selectedPie != null)
            {
                _shoppingCart.RemoveFromShoppingCart(selectedPie);
            }
            return RedirectToAction("Index");
        }



    }
}
