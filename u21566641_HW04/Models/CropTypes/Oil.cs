using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21566641_HW04.Models
{
    public class Oil : Crop
    {
        public Oil() {}
        public Oil(int _CropID, string _CropName, string _CropCategory, int _QuantityOnHand,
           string _ImageURL, int _UserID, int _CostPrice, double _Markup) : base(_CropID,
               _CropName, _CropCategory, _QuantityOnHand, _ImageURL, _UserID, _CostPrice, _Markup)
        {
        }

        public override double GetMarkup()
        {
            double markup;
            markup = 0.24;
            return markup;
        }
    }
}