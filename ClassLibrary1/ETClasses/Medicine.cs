using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.ETClasses
{
    
        public class Medicine
        {
            public int MedicineId { get; set; }
            public string MName { get; set; }
            public string MType { get; set; }
            public double Price { get; set; }

            public int stock { get; set; }
        }
    }


