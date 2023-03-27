using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePMC.DataAnnotation.OnetoOneMapping.Models
{
    [Table("RegularCustomer")]
    public class RegularCustomer : Customer
    {
        #region Properties
        //Scalar Properties
        [Column("AdvCredits", TypeName = "MONEY")]
        public decimal AdvCredits { get; set; }

        [Column("Perks", TypeName = "VARCHAR")]
        [StringLength(30, ErrorMessage = "Shouldn't exceed morethan 30 chars")]
        public string Perks { get; set; }
        #endregion
    }
}
