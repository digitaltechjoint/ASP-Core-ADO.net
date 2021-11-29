using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ADONETCOre.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        public string Customername { get; set; }
        public string EmailAddress { get; set; }
        public string Mobile { get; set; }
    }
}
