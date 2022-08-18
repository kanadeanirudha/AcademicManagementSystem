using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class InventoryDashboardReport : BaseDTO
    {
        /// <summary>
        /// Properties for InventoryDashboardReport table
        /// </summary>
        public int ID
        {
            get;
            set;
        }
        public string DataFor
        {
            get;
            set;
        }
        public int PurchaseRequirementMasterID
        {
            get;
            set;
        }
        public string PurchaseRequirementNumber
        {
            get;
            set;
        }
        public string PurchaseRequisitionNumber
        {
            get;
            set;
        }
        public string PurchaseRequisitionBehaviour
        {
            get;
            set;
        }
        public string TransDate
        {
            get;
            set;
        }
        public Int16 PurchaseRequisitionType
        {
            get;
            set;
        }
        public Int16 PurchaseRequisitionBy
        {
            get;
            set;
        }
        public string Currency
        {
            get;
            set;
        }

        public int VendorID
        {
            get;
            set;
        }
        public string Vendor
        {
            get;
            set;
        }
        public string Convertion
        {
            get;
            set;
        }
        public bool IsOpenForPO
        {
            get;
            set;
        }
        public Int16 PRStatus
        {
            get;
            set;
        }
        public string Days
        {
            get;
            set;
        }
        public string ReportList
        {
            get;
            set;
        }
         public string BillRelevantTo
        {
            get;
            set;
        }
         public string TotalInvoiceAmountList
         {
             get;
             set;
         }
         public string Months
         {
             get;
             set;
         }
         public string  SourceKey
         {
             get;
             set;
         }
         public int TotalCount
         {
             get;
             set;
         }
         public decimal SaleAmount
         {
             get;
             set;
         }
         public decimal PromotionAmount
         {
             get;
             set;
         }
        public bool IsDeleted
        {
            get;
            set;
        }
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
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }

        /// <summary>
      
        
    }
}

