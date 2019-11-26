using System;
using System.Collections.Generic;

namespace GuestCheckApp.Models
{
    public partial class GuestCheckProduct
    {
        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int GuestCheckID { get; set; }
        public GuestCheck GuestCheck { get; set; }
    }
}
