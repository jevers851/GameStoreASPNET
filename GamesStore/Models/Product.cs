using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesStore.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public bool Disabled { get; set; }
        public bool featured { get; set; }
        public bool hot { get; set; }

    }
}