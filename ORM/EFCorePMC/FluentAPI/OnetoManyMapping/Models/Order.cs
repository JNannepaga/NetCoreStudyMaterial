using System;

namespace EFCorePMC.FluentAPI.OnetoManyMapping.Models
{
    public class Order
    {
        //Scalar Properties
        public int OrderId { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal DeliveryCharge { get; set; }
        public decimal ItemCost
        {
            get
            {
                return 200;
            }
        }
        public decimal TotalAmount
        {
            get
            {
                return this.DeliveryCharge + this.ItemCost + this.TaxAmount;
            }
        }

        public int CustomerRefId { get; set; }

        //Navigation Properties
        public virtual Customer Customer { get; set; }

    }
}
