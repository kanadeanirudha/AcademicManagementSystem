using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class SalePromotionOnFixAmountPlan : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        //Fields From SalePromotionActivityMaster
        public int SalePromotionActivityMasterID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string FromDate
        {
            get;
            set;
        }
        public string UptoDate
        {
            get;
            set;
        }
        public string PlanTypeCode
        {
            get;
            set;
        }
        public int GeneralUnitsID
        {
            get;
            set;
        }

        //Fields from SalePromotionActivityDetails
        public int SalePromotionActivityDetailsID
        {
            get;
            set;
        }
        public int SalePromotionPlanDetailsId
        {
            get;
            set;
        }

        //Fields from SalePromotionPlan
        public int SalePromotionPlanID
        {
            get;
            set;
        }
        public string PlanTypeName
        {
            get;
            set;
        }

        //Fields from SalePromotionPlanDetails
        public int SalePromotionPlanDetailsID
        {
            get;
            set;
        }
        public Int16 HowManyQtyToBuy
        {
            get;
            set;
        }
        public int GiftItemQty
        {
            get;
            set;
        }
        public bool IsSampling
        {
            get;
            set;
        }
        public decimal BillAmountRangeFrom
        {
            get;
            set;
        }
        public decimal BillAmountRangeUpto
        {
            get;
            set;
        }
        public decimal BillDiscountAmount
        {
            get;
            set;
        }
        public decimal DiscountInPercent
        {
            get;
            set;
        }
        public bool IsPercentage
        {
            get;
            set;
        }
        public bool IsItemWiseDiscountExclude
        {
            get;
            set;
        }
        public string SubActivityName
        {
            get;
            set;
        }
    }
}
