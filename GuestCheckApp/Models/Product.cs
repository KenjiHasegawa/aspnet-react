using System;
using System.Collections.Generic;

namespace GuestCheckApp.Models
{
    public partial class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductType { get; set; }
        public decimal ProductValue { get; set; }

        public List<GuestCheckProduct> GuestCheckProducts { get; set; }
    }
}
