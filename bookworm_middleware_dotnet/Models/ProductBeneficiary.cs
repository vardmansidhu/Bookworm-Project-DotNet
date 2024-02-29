using Bookworm_cs.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookworm_cs.Models
{
    public class ProductBeneficiary
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdBenId { get; set; }
        public int BenId { get; set; }
        //public Beneficiary Beneficiary { get; set; }
        public int ProductId { get; set; }
        //public Product Product { get; set; }
        public double Percentage { get; set; }
        public override string ToString()
        {
            return $"ProductBeneficiary [ProdBenId={ProdBenId}, BenId={BenId}, ProductId={ProductId}, Percentage={Percentage}]";
        }
    }
}
