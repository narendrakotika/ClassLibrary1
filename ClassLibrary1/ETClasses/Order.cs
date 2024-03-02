using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.ETClasses
{
    public class Order
    {
        public class Orders
        {
            [Key]
            public int OrderId { get; set; }
            [Required(ErrorMessage = "Medicine is required")]

            public int MedicineId { get; set; }

            public DateTime OrderDate { get; set; }

            [Required(ErrorMessage = "Amount is required")]

            public int Amount { get; set; }

            public double OrderCost { get; set; }
            public bool IsFirstOrderDiscountApplied { get; set; }
            public bool IsRegularCustomerDiscountApplied { get; set; }
            [ForeignKey("MedicineId")]
            public virtual Medicine Medicine { get; set; }
        }
    }
}
