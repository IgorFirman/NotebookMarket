using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotebookMarket.Models
{
    public class LaptopRepository : ILaptopRepository
    {
        private readonly ApplicationContext _applicationContext;

        public LaptopRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public IEnumerable<Laptop> AllLaptops
        {
            get
            {
                return _applicationContext.Laptops.Include(c => c.Category);
            }
        }

        public IEnumerable<Laptop> LaptopsOnDiscount
        {
            get
            {
                return _applicationContext.Laptops.Include(c => c.Category).Where(p => p.OnDiscount);
            }
        }
        public Laptop GetLaptopById(int id)
        {
            return _applicationContext.Laptops.FirstOrDefault(l => l.LaptopId == id);
        }
    }
}
