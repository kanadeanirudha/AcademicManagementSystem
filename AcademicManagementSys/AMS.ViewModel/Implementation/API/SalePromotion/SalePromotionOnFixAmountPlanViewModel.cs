using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class SalePromotionOnFixAmountPlanViewModel : ISalePromotionOnFixAmountPlanViewModel
    {
        public SalePromotionOnFixAmountPlanViewModel()
        {
            SalePromotionOnFixAmountPlanDTO = new SalePromotionOnFixAmountPlan();
        }

        public SalePromotionOnFixAmountPlan SalePromotionOnFixAmountPlanDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (SalePromotionOnFixAmountPlanDTO != null && SalePromotionOnFixAmountPlanDTO.ID > 0) ? SalePromotionOnFixAmountPlanDTO.ID : new int();
            }
            set
            {
                SalePromotionOnFixAmountPlanDTO.ID = value;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return SalePromotionOnFixAmountPlanDTO.ErrorMessage;
            }
            set
            {
                SalePromotionOnFixAmountPlanDTO.ErrorMessage = value;
            }
        }

        public int SalePromotionActivityMasterID
        {
            get
            {
                return (SalePromotionOnFixAmountPlanDTO != null) ? SalePromotionOnFixAmountPlanDTO.SalePromotionActivityMasterID : new int();
            }
            set
            {
                SalePromotionOnFixAmountPlanDTO.SalePromotionActivityMasterID = value;
            }
        }
        public int GeneralUnitsID
        {
            get
            {
                return (SalePromotionOnFixAmountPlanDTO != null) ? SalePromotionOnFixAmountPlanDTO.GeneralUnitsID : new int();
            }
            set
            {
                SalePromotionOnFixAmountPlanDTO.GeneralUnitsID = value;
            }
        }
        public string Name
        {
            get
            {
                return (SalePromotionOnFixAmountPlanDTO != null) ? SalePromotionOnFixAmountPlanDTO.Name : string.Empty;
            }
            set
            {
                SalePromotionOnFixAmountPlanDTO.Name = value;
            }
        }
        public string SubActivityName
        {
            get
            {
                return (SalePromotionOnFixAmountPlanDTO != null) ? SalePromotionOnFixAmountPlanDTO.SubActivityName : string.Empty;
            }
            set
            {
                SalePromotionOnFixAmountPlanDTO.SubActivityName = value;
            }
        }
        public string FromDate
        {
            get
            {
                return (SalePromotionOnFixAmountPlanDTO != null) ? SalePromotionOnFixAmountPlanDTO.FromDate : string.Empty;
            }
            set
            {
                SalePromotionOnFixAmountPlanDTO.FromDate = value;
            }
        }
        public string PlanTypeCode
        {
            get
            {
                return (SalePromotionOnFixAmountPlanDTO != null) ? SalePromotionOnFixAmountPlanDTO.PlanTypeCode : string.Empty;
            }
            set
            {
                SalePromotionOnFixAmountPlanDTO.PlanTypeCode = value;
            }
        }
        
        //Fields from SalePromotionActivityDetails

        public int SalePromotionActivityDetailsID
        {
            get
            {
                return (SalePromotionOnFixAmountPlanDTO != null) ? SalePromotionOnFixAmountPlanDTO.SalePromotionActivityDetailsID : new int();
            }
            set
            {
                SalePromotionOnFixAmountPlanDTO.SalePromotionActivityDetailsID = value;
            }
        }
        public int SalePromotionPlanDetailsId
        {
            get
            {
                return (SalePromotionOnFixAmountPlanDTO != null) ? SalePromotionOnFixAmountPlanDTO.SalePromotionPlanDetailsId : new int();
            }
            set
            {
                SalePromotionOnFixAmountPlanDTO.SalePromotionPlanDetailsId = value;
            }
        }
        //Fields from SalePromotionPlan
        public int SalePromotionPlanID
        {
            get
            {
                return (SalePromotionOnFixAmountPlanDTO != null) ? SalePromotionOnFixAmountPlanDTO.SalePromotionPlanID : new int();
            }
            set
            {
                SalePromotionOnFixAmountPlanDTO.SalePromotionPlanID = value;
            }
        }
        public string PlanTypeName
        {
            get
            {
                return (SalePromotionOnFixAmountPlanDTO != null) ? SalePromotionOnFixAmountPlanDTO.PlanTypeName : string.Empty;
            }
            set
            {
                SalePromotionOnFixAmountPlanDTO.PlanTypeName = value;
            }
        }

        //Fields from SalePromotionPlanDetails
        public int SalePromotionPlanDetailsID
        {
            get
            {
                return (SalePromotionOnFixAmountPlanDTO != null) ? SalePromotionOnFixAmountPlanDTO.SalePromotionPlanDetailsID : new int();
            }
            set
            {
                SalePromotionOnFixAmountPlanDTO.SalePromotionPlanDetailsID = value;
            }
        }
        public Int16 HowManyQtyToBuy
        {
            get
            {
                return (SalePromotionOnFixAmountPlanDTO != null) ? SalePromotionOnFixAmountPlanDTO.HowManyQtyToBuy : new Int16();
            }
            set
            {
                SalePromotionOnFixAmountPlanDTO.HowManyQtyToBuy = value;
            }
        }
        public int GiftItemQty
        {
            get
            {
                return (SalePromotionOnFixAmountPlanDTO != null) ? SalePromotionOnFixAmountPlanDTO.GiftItemQty : new int();
            }
            set
            {
                SalePromotionOnFixAmountPlanDTO.GiftItemQty = value;
            }
        }
        public bool IsSampling
        {
            get
            {
                return (SalePromotionOnFixAmountPlanDTO != null) ? SalePromotionOnFixAmountPlanDTO.IsSampling : false;
            }
            set
            {
                SalePromotionOnFixAmountPlanDTO.IsSampling = value;
            }
        }


        public bool IsPercentage
        {
            get
            {
                return (SalePromotionOnFixAmountPlanDTO != null) ? SalePromotionOnFixAmountPlanDTO.IsPercentage : false;
            }
            set
            {
                SalePromotionOnFixAmountPlanDTO.IsPercentage = value;
            }
        }
        public bool IsItemWiseDiscountExclude
        {
            get
            {
                return (SalePromotionOnFixAmountPlanDTO != null) ? SalePromotionOnFixAmountPlanDTO.IsItemWiseDiscountExclude : false;
            }
            set
            {
                SalePromotionOnFixAmountPlanDTO.IsItemWiseDiscountExclude = value;
            }
        }
        public decimal BillAmountRangeFrom
        {
            get
            {
                return (SalePromotionOnFixAmountPlanDTO != null) ? SalePromotionOnFixAmountPlanDTO.BillAmountRangeFrom : new decimal();
            }
            set
            {
                SalePromotionOnFixAmountPlanDTO.BillAmountRangeFrom = value;
            }
        }
        public decimal BillAmountRangeUpto
        {
            get
            {
                return (SalePromotionOnFixAmountPlanDTO != null) ? SalePromotionOnFixAmountPlanDTO.BillAmountRangeUpto : new decimal();
            }
            set
            {
                SalePromotionOnFixAmountPlanDTO.BillAmountRangeUpto = value;
            }
        }
        public decimal BillDiscountAmount
        {
            get
            {
                return (SalePromotionOnFixAmountPlanDTO != null) ? SalePromotionOnFixAmountPlanDTO.BillDiscountAmount : new decimal();
            }
            set
            {
                SalePromotionOnFixAmountPlanDTO.BillDiscountAmount = value;
            }
        }
        public decimal DiscountInPercent
        {
            get
            {
                return (SalePromotionOnFixAmountPlanDTO != null) ? SalePromotionOnFixAmountPlanDTO.DiscountInPercent : new decimal();
            }
            set
            {
                SalePromotionOnFixAmountPlanDTO.DiscountInPercent = value;
            }
        }
    }
}
