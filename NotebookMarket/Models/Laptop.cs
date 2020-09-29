using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotebookMarket.Models
{
    public class Laptop
    {
        public int LaptopId { get; set; }
        public string Model { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool OnDiscount { get; set; }
        public bool Available { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
