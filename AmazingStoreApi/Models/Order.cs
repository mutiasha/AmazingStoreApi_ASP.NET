//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AmazingStoreApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int order_id { get; set; }
        public System.DateTime order_date { get; set; }
        public string customer_id { get; set; }
        public string product_id { get; set; }
        public int quantity { get; set; }
        public decimal total_price { get; set; }
        public Nullable<decimal> discount { get; set; }
    }
}
