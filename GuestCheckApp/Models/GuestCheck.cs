using System;
using System.Collections.Generic;

namespace GuestCheckApp.Models
{
    public partial class GuestCheck
    {
        public int GuestCheckId { get; set; }
        public string GuestCheckStatus { get; set; }
        public decimal GuestCheckValue { get; set; }
        public DateTime DateCreated { get; set; }
        public List<GuestCheckProduct> GuestCheckProducts { get; set; }
    }
}
