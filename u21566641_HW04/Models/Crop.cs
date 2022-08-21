using System;
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
        private int? mQuantityOnHand;
        private string mImageUrl;
        private int? mUserID;
        private double? mCostPrice;
        private double mMarkup = 0.15;
        private int mQuantity = 0;
        private double mTotalCost = 0;

        public Crop() { }

        public Crop(int _CropID, string _CropName, string _CropCategory, int _QuantityOnHand,
            string _ImageURL, int _UserID, int _CostPrice, double _Markup, int _Quantity) 
        {
            mCropID = _CropID;
            mCropName = _CropName;
            mCropCategory = _CropCategory;
            mQuantityOnHand = _QuantityOnHand;
            mImageUrl = _ImageURL;
            mUserID = _UserID;
            mCostPrice = _CostPrice;
            mMarkup = _Markup;
            mQuantity = _Quantity;
        }
        public int CropID 
        { get { return mCropID; }
          set { mCropID = value; }
        }
        public string CropName
        {
            get { return mCropName; }
            set { mCropName = value; }
        }
        public string CropCategory
        {
            get { return mCropCategory; }
            set { mCropCategory = value; }
        }
        public int? QuantityOnHand
        {
            get { return mQuantityOnHand; }
            set { mQuantityOnHand = value; }
        }
        public string ImageURL
        {
            get { return mImageUrl; }
            set { mImageUrl = value; }
        }
        public int? UserID
        {
            get { return mUserID; }
            set { mUserID = value; }
        }
        public double? CostPrice
        {
            get { return mCostPrice; }
            set { mCostPrice = value; }
        }
        public int Quantity
        {
            get { return mQuantity; }
            set { mQuantity = value; }
        }
        public abstract double GetMarkup();
        public virtual double GetTotalCost()//Gets total cost of number of specific item in cart
        {
            mTotalCost = Quantity * (Convert.ToDouble(CostPrice) +(Convert.ToDouble(CostPrice) * GetMarkup()));
            return mTotalCost;
        }

       
        
    }
}