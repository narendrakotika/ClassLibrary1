using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.ETClasses
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        //[ForeignKey("Orders")]
        //public int OrderId { get; set; }

        public int MedicineId { get; set; }
        public int Quantity { get; set; }

        public string Mtype { get; set; }
        [ForeignKey("MedicineId")]
        public virtual Medicine Medicine { get; set; }
    }
}
