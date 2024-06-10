using System;
using System.Collections.Generic;

namespace api_javascript_connection.Models
{
    public partial class OrderSubtotal
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
