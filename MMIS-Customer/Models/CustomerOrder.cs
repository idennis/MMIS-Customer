//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MMIS_Customer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomerOrder
    {
        public int OrderID { get; set; }
        public string CustomerUN { get; set; }
        public decimal TotalPrice { get; set; }
        public System.TimeSpan PurchaseTime { get; set; }
    
        public virtual Customer Customer { get; set; }
    }
}
