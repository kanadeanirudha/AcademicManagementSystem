using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class SalePromotionGetOfflineViewModel : ISalePromotionGetOfflineViewModel
    {
        public SalePromotionGetOfflineViewModel()
        {
            SalePromotionGetOfflineDTO = new SalePromotionGetOffline();
        }

        public SalePromotionGetOffline SalePromotionGetOfflineDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (SalePromotionGetOfflineDTO != null && SalePromotionGetOfflineDTO.ID > 0) ? SalePromotionGetOfflineDTO.ID : new int();
            }
            set
            {
                SalePromotionGetOfflineDTO.ID = value;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return SalePromotionGetOfflineDTO.ErrorMessage;
            }
            set
            {
                SalePromotionGetOfflineDTO.ErrorMessage = value;
            }
        }

        public int SalePromotionActivityMasterID
        {
            get
            {
                return (SalePromotionGetOfflineDTO != null) ? SalePromotionGetOfflineDTO.SalePromotionActivityMasterID : new int();
            }
            set
            {
                SalePromotionGetOfflineDTO.SalePromotionActivityMasterID = value;
            }
        }
        public int GeneralUnitsID
        {
            get
            {
                return (SalePromotionGetOfflineDTO != null) ? SalePromotionGetOfflineDTO.GeneralUnitsID : new int();
            }
            set
            {
                SalePromotionGetOfflineDTO.GeneralUnitsID = value;
            }
        }
        public string Name
        {
            get
            {
                return (SalePromotionGetOfflineDTO != null) ? SalePromotionGetOfflineDTO.Name : string.Empty;
            }
            set
            {
                SalePromotionGetOfflineDTO.Name = value;
            }
        }

        public string LastSyncDate
        {
            get
            {
                return (SalePromotionGetOfflineDTO != null) ? SalePromotionGetOfflineDTO.LastSyncDate : string.Empty;
            }
            set
            {
                SalePromotionGetOfflineDTO.LastSyncDate = value;
            }
        }
        public string FromDate
        {
            get
            {
                return (SalePromotionGetOfflineDTO != null) ? SalePromotionGetOfflineDTO.FromDate : string.Empty;
            }
            set
            {
                SalePromotionGetOfflineDTO.FromDate = value;
            }
        }
        public string PlanTypeCode
        {
            get
            {
                return (SalePromotionGetOfflineDTO != null) ? SalePromotionGetOfflineDTO.PlanTypeCode : string.Empty;
            }
            set
            {
                SalePromotionGetOfflineDTO.PlanTypeCode = value;
            }
        }

        //Fields from SalePromotionActivityDetails

        public int SalePromotionActivityDetailsID
        {
            get
            {
                return (SalePromotionGetOfflineDTO != null) ? SalePromotionGetOfflineDTO.SalePromotionActivityDetailsID : new int();
            }
            set
            {
                SalePromotionGetOfflineDTO.SalePromotionActivityDetailsID = value;
            }
        }
        public int SalePromotionPlanDetailsId
        {
            get
            {
                return (SalePromotionGetOfflineDTO != null) ? SalePromotionGetOfflineDTO.SalePromotionPlanDetailsId : new int();
            }
            set
            {
                SalePromotionGetOfflineDTO.SalePromotionPlanDetailsId = value;
            }
        }
        //Fields from SalePromotionPlan
        public int SalePromotionPlanID
        {
            get
            {
                return (SalePromotionGetOfflineDTO != null) ? SalePromotionGetOfflineDTO.SalePromotionPlanID : new int();
            }
            set
            {
                SalePromotionGetOfflineDTO.SalePromotionPlanID = value;
            }
        }
        public string PlanTypeName
        {
            get
            {
                return (SalePromotionGetOfflineDTO != null) ? SalePromotionGetOfflineDTO.PlanTypeName : string.Empty;
            }
            set
            {
                SalePromotionGetOfflineDTO.PlanTypeName = value;
            }
        }

        //Fields from SalePromotionPlanDetails
        public int SalePromotionPlanDetailsID
        {
            get
            {
                return (SalePromotionGetOfflineDTO != null) ? SalePromotionGetOfflineDTO.SalePromotionPlanDetailsID : new int();
            }
            set
            {
                SalePromotionGetOfflineDTO.SalePromotionPlanDetailsID = value;
            }
        }
        public Int16 HowManyQtyToBuy
        {
            get
            {
                return (SalePromotionGetOfflineDTO != null) ? SalePromotionGetOfflineDTO.HowManyQtyToBuy : new Int16();
            }
            set
            {
                SalePromotionGetOfflineDTO.HowManyQtyToBuy = value;
            }
        }
        public int GiftItemQty
        {
            get
            {
                return (SalePromotionGetOfflineDTO != null) ? SalePromotionGetOfflineDTO.GiftItemQty : new int();
            }
            set
            {
                SalePromotionGetOfflineDTO.GiftItemQty = value;
            }
        }
        public bool IsSampling
        {
            get
            {
                return (SalePromotionGetOfflineDTO != null) ? SalePromotionGetOfflineDTO.IsSampling : false;
            }
            set
            {
                SalePromotionGetOfflineDTO.IsSampling = value;
            }
        }


        public bool IsPercentage
        {
            get
            {
                return (SalePromotionGetOfflineDTO != null) ? SalePromotionGetOfflineDTO.IsPercentage : false;
            }
            set
            {
                SalePromotionGetOfflineDTO.IsPercentage = value;
            }
        }
        public bool IsItemWiseDiscountExclude
        {
            get
            {
                return (SalePromotionGetOfflineDTO != null) ? SalePromotionGetOfflineDTO.IsItemWiseDiscountExclude : false;
            }
            set
            {
                SalePromotionGetOfflineDTO.IsItemWiseDiscountExclude = value;
            }
        }
        public decimal BillAmountRangeFrom
        {
            get
            {
                return (SalePromotionGetOfflineDTO != null) ? SalePromotionGetOfflineDTO.BillAmountRangeFrom : new decimal();
            }
            set
            {
                SalePromotionGetOfflineDTO.BillAmountRangeFrom = value;
            }
        }
        public decimal BillAmountRangeUpto
        {
            get
            {
                return (SalePromotionGetOfflineDTO != null) ? SalePromotionGetOfflineDTO.BillAmountRangeUpto : new decimal();
            }
            set
            {
                SalePromotionGetOfflineDTO.BillAmountRangeUpto = value;
            }
        }
        public decimal BillDiscountAmount
        {
            get
            {
                return (SalePromotionGetOfflineDTO != null) ? SalePromotionGetOfflineDTO.BillDiscountAmount : new decimal();
            }
            set
            {
                SalePromotionGetOfflineDTO.BillDiscountAmount = value;
            }
        }
        public decimal DiscountInPercent
        {
            get
            {
                return (SalePromotionGetOfflineDTO != null) ? SalePromotionGetOfflineDTO.DiscountInPercent : new decimal();
            }
            set
            {
                SalePromotionGetOfflineDTO.DiscountInPercent = value;
            }
        }
    }
}
