using System;
using System.Collections.Generic;

namespace GuestCheckApp.Models
{
    public partial class TblGuestCheck
    {
        public int GuestCheckId { get; set; }
        public string GuestCheckStatus { get; set; }
        public decimal GuestCheckValue { get; set; }
    }
}
