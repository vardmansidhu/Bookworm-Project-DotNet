using System;
namespace Bookworm_cs.Models
{   
    public class Customer
    {
        public int CustomerId { get; set; }
        public string? ContactNo { get; set; }
        public string CustomerEmail { get; set; }
        public string? CustomerName { get; set; }
        public DateTime? Dob { get; set; }
        public string Password { get; set; }
    }

}
