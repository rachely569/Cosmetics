using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Cosmetics_Dal.Models
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int? UserId { get; set; }
        public decimal TotalAmount { get; set; }

        public virtual Users User { get; set; }
    }
}
