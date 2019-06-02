using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoRentalWebAPI.Models;

namespace InventoryRentalWebAPI.ViewModels
{
    public class CustomerRentalDetailsViewModel
    {
        public Rental Rental { get; set; }
        public string CustomerName { get; set; }
        public List<CustomerToolsViewModel> RentedTools { get; set; }
    }
}