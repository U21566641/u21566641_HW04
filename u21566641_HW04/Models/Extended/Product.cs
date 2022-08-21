using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace u21566641_HW04.Models
{
    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {
    }

    public class ProductMetaData
    {
        [Display(Name = "Crop Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the crop's name")]
        public int ProductName { get; set; }

        [Display(Name = "Crop Category")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select the crop's category")]
        public String ProductCategory { get; set; }

        [Display(Name = "Number of kgs")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the number of kgs which you would like to sell")]
        public int QuantityOnHand { get; set; }

        public String ImageURL { get; set; }

        [Display(Name = "Price per kg")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your desired selling price per kg")]
        public double CostPrice { get; set; }


    }

}