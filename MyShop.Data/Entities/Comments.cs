using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Data.Entities
{
    public class Comments
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public string NameOfSender { get; set; }
    }
}
