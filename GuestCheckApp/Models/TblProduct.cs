using System;
using System.Collections.Generic;

namespace GuestCheckApp.Models
{
    public partial class TblProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductType { get; set; }
        public decimal ProductValue { get; set; }
    }
}
