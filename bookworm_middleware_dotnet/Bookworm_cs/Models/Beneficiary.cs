using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookworm_cs.Models
{
    public class Beneficiary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BenId { get; set; }
        public String BenName { get; set; }
        public String Email { get; set; }
        public String? Contact { get; set; }
        public String? BankName { get; set; }
        public String? BankBranch { get; set; }
        public String? IFSC { get; set; }
        public String? AccountNo { get; set; }
        public String? AccountType { get; set; }
        public String? PAN { get; set;}

        public override string? ToString()
        {
            return $"BenId={BenId}, BenName={BenName}";
        }
    }
}
