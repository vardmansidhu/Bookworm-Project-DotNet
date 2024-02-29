using BookWorm_cs.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookworm_cs.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string? ISBN { get; set; }
        public string? Author { get; set; }
        public double? BasePrice { get; set; }
        public bool? IsLibrary { get; set; }
        public bool? IsRentable { get; set; }
        public string? LongDesc { get; set; }
        public int? MinRentDays { get; set; }
        public string? OfferExpDate { get; set; }
        public double? OfferPrice { get; set; }
        public string? ProductEngName { get; set; }
        public string? ProductName { get; set; }
        public string? Publisher { get; set; }
        public double? RentPerDay { get; set; }
        public string? ShortDesc { get; set; }
        public double? SpecialCost { get; set; }
        public int? GenreId { get; set; }
        public int? LanguageId { get; set; }
       // public Language? Language { get; set; }
        public int? ProductTypeId { get; set; }
        //public ProductType? ProductType { get; set; }
    }
}
