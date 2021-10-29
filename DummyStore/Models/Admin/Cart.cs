using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DummyStore.Models.Admin
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }
    }

    public class Products
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
