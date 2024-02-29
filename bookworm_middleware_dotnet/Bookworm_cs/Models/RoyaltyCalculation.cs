using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookworm_cs.Models
{
    public class RoyaltyCalculation
    {
        public RoyaltyCalculation(int invoiceId, int benId, DateTime roycalTrandate, int prodId, int trantype, double saleprice, double baseprice, double royaltyOnBasePrice)
        {
            InvoiceId = invoiceId;
            BenId = benId;
            RoycalTrandate = roycalTrandate;
            ProdId = prodId;
            Trantype = trantype;
            Saleprice = saleprice;
            Baseprice = baseprice;
            RoyaltyOnBasePrice = royaltyOnBasePrice;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoycalId { get; set; }
        public int InvoiceId { get; set; }
        //public Invoice Invoice { get; set; }
        public int BenId { get; set; }
        //public Beneficiary Beneficiary { get; set; }
        public DateTime RoycalTrandate { get; set; }
        public int ProdId { get; set; }
        public int Trantype { get; set; }
        public double Saleprice { get; set; }
        public double Baseprice { get; set; }
        public double RoyaltyOnBasePrice { get; set; }
    }

}
