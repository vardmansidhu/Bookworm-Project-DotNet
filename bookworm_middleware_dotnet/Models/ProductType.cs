using System.ComponentModel.DataAnnotations;

namespace BookWorm_cs.Models
{
    public class ProductType
    {
        [Key]
        public int TypeId {  get; set; }
        public string TypeDesc {  get; set; }
    }
}
