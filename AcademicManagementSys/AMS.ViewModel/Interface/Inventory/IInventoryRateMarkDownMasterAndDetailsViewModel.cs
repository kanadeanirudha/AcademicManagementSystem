
using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    
         public interface IInventoryRateMarkDownMasterAndDetailsViewModel
    {
             InventoryRateMarkDownMasterAndDetails InventoryRateMarkDownMasterAndDetailsDTO
        {
            get;
            set;
        }

        Int64 ID
        { 
            get;
            set;
        }

         string ItemName { get; set; }
         string  TransactionDate
        {
            get;
            set;
        }

        decimal RateMarkDownAmount
        {
            get;
            set;
        }

        Int16 BalanceSheetID
        {
            get;
            set;
        }

        Int64 RateMarkDownDetailID
        {
            get;
            set;
        }

        Int64 RateMarkDownMasterID
        {
            get;
            set;

        }
       int ItemID 
        {
            get;
            set;

        }
       decimal RateDecreaseByPercentage
        {
            get;
            set;
        }

         bool IsDeleted
        {
            get;
            set;
        }
         int CreatedBy
        {
            get;
            set;
        }
         DateTime CreatedDate
        {
            get;
            set;
        }
         int ModifiedBy
        {
            get;
            set;
        }
        DateTime ModifiedDate
        {
            get;
            set;
        }
        int DeletedBy
        {
            get;
            set;
        }
         DateTime DeletedDate
        {
            get;
            set;
        }
        string errorMessage { get; set; }
    }
}
