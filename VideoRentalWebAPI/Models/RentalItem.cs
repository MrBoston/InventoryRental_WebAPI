//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VideoRentalWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RentalItem
    {
        public int RentalItemId { get; set; }
        public int RentalId { get; set; }
        public int ToolId { get; set; }
    
        public virtual Rental Rental { get; set; }
        public virtual Tool Tool { get; set; }
    }
}
