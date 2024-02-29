using BookWorm_cs.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookworm_cs.Models
{
    public class Language
    {
        [Key]
        public int LanguageId { get; set; }
        public string LanguageDesc { get; set; }
        public int ProductTypeId { get; set; }
    }

}
