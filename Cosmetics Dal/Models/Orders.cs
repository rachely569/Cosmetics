using System;
using System.Collections.Generic;

namespace Cosmetics_Dal.Models
{
    public partial class Orders
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public int? UserId { get; set; }

        public virtual Users User { get; set; }
    }
}