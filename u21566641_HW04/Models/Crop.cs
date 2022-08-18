﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21566641_HW04.Models
{
    public abstract class Crop
    {
        private int mCropID;
        private string mCropName;
        private string mCropCategory;
        private int mQuantityOnHand;
        private string mImageUrl;
        private int mUserID;
        private int mCostPrice;
        private double mMarkup = 0.15;

        public Crop() { }

        public Crop(int _CropID, string _CropName, string _CropCategory, int _QuantityOnHand,
            string _ImageURL, int _UserID, int _CostPrice, double _Markup) 
        {
            mCropID = _CropID;
            mCropName = _CropName;
            mCropCategory = _CropCategory;
            mQuantityOnHand = _QuantityOnHand;
            mImageUrl = _ImageURL;
            mUserID = _UserID;
            mCostPrice = _CostPrice;
            mMarkup = _Markup;
        }
        public int CropID { get; set; }
        public string CropName { get; set; }
        public string CropCategory { get; set; }
        public int? QuantityOnHand { get; set; } 
        public string ImageURL { get; set; }
        public int? UserID { get; set; }
        public double? CostPrice { get; set; }
        public abstract double GetMarkup();
    }
}