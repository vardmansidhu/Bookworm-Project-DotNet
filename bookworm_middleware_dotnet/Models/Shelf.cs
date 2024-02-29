using Bookworm_cs.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookworm_cs.Models
{
    public class Shelf
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShelfId { get; set; }
        public int CustomerId { get; set; }
        //public Customer Customer { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        //public Product Product { get; set; }
        public int TransactionTypeId { get; set; }
        //public TransactionType TransactionType { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool IsActive { get; set; }
    }
}
