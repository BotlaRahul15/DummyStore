using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DummyStore.Models.Admin
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public Rating rating { get; set; }
    }
    public class Rating
    {
        public double Rate { get; set; }
        public int Count { get; set; }
    }
}
