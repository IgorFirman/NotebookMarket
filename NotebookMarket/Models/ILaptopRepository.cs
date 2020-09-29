using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotebookMarket.Models
{
    public interface ILaptopRepository
    {
        IEnumerable<Laptop> AllLaptops { get; }
        IEnumerable<Laptop> LaptopsOnDiscount { get; }
        Laptop GetLaptopById(int id);
    }
}
