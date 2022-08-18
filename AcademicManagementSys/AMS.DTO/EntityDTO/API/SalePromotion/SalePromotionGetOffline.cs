using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class SalePromotionGetOffline : BaseDTO
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
        public string LastSyncDate
        {
            get;
            set;
        }
        public int GeneralUnitsID
        {
            get;
            set;
        }
        public byte PromotionalActivityFilter
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

        public string SubActivityName { get; set; }
        public bool StatusFlag { get; set; }
        public bool Flag { get; set; }
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
        //PromotionActivityDiscounteItemList

        public int PromotionActivityDiscounteItemListID { get; set; }
        public int ItemNumber { get; set; }
        public string UOM { get; set; }
        public Int16 InventoryVariationMasterID { get; set; }
        public bool IsActive { get; set; }
        //Common Fields

        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public int DeletedBy
        {
            get;
            set;
        }
        public DateTime DeletedDate
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public bool IsCoupanOrGiftVoucherApplicable
        {
            get;
            set;
        }
        public bool ExternalFlag
        {
            get;
            set;
        }
        public bool IsCommon
        {
            get;
            set;
        }
        public byte ProductConcessionFreeType
        {
            get;
            set;
        }
    }
}
