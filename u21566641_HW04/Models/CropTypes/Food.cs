using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21566641_HW04.Models.CropTypes
{
    public class Food : Crop
    {
        public override double GetMarkup()
        {
            double markup;
            return markup = 0.20;
        }
    }
}