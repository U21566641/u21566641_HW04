using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21566641_HW04.Models
{
    public abstract class Crop
    {
        public int CropID { get; set; }
        public string CropName { get; set; }
        public string CropCategory { get; set; }
        public int QuantityOnHand { get; set; } 
        public string ImageURL { get; set; }
        public int SupplierID { get; set; }
    }
}