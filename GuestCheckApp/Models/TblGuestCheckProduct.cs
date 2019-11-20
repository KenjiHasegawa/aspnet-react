using System;
using System.Collections.Generic;

namespace GuestCheckApp.Models
{
    public partial class TblGuestCheckProduct
    {
        public int GuestCheckProductId { get; set; }
        public int GuestCheckId { get; set; }
        public int ProductId { get; set; }
        public int ProductQty { get; set; }
    }
}
