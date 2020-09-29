using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotebookMarket.Models
{
    public class OrderDetails
    {
        public int OrderDetailsId { get; set; }
        public int OrderId { get; set; }
        public int PieId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Laptop Laptop { get; set; }
        public Order Order { get; set; }
    }
}
