using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Bookworm_cs.Models
{
    public class InvoiceDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvDtlId { get; set; }
        public int? InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
        public double? BasePrice { get; set; }
        public double SellingPrice { get; set; }
        public int? TransactionTypeId { get; set; }
        public TransactionType? TransactionType { get; set; }
        public int? RentingDays { get; set; }
    }

}
