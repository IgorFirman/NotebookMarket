using NotebookMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotebookMarket.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Laptop> LaptopsOnDiscount { get; set; }
    }
}
