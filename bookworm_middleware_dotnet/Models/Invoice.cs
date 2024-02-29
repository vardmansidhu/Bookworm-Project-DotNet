using Bookworm_cs.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookworm_cs.Models
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public float? InvoiceAmount { get; set; }
        public int? Quantity { get; set; }
    }

}
