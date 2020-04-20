using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Data.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public Guid CategoryId { get; set; }

        public List<Comments> Comments { get; set; } = new List<Comments>();
    }
}
