using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IInventoryEstimationMasterAndDetailsViewModel
    {
        InventoryEstimationMasterAndDetails InventoryEstimationMasterAndDetailsDTO { get; set; }
        //--------------------------------Properties of EstimationMaster Table-----------------------------------
         int ID
        {
            get;
            set;
        }
         string TransactionDate
        {
            get;
            set;
        }
         string CustomerName
        {
            get;
            set;
        }
         string CustomerAddress
        {
            get;
            set;
        }
         string CustomerMobileNumber
        {
            get;
            set;
        }
         decimal EstimationAmount
        {
            get;
            set;
        }
         Boolean EstimationStatus
        {
            get;
            set;
        }
         Int16 BalanceSheetID
        {
            get;
            set;
        }
         Boolean IsPendingForBill
        {
            get;
            set;
        }
         string BillNumber
        {
            get;
            set;
        }
         bool IsActive
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
         int? ModifiedBy
        {
            get;
            set;
        }
         DateTime? ModifiedDate
        {
            get;
            set;
        }
         int? DeletedBy
        {
            get;
            set;
        }
         DateTime? DeletedDate
        {
            get;
            set;
        }
       //----------------------------Properties of EstimationDetails Table-----------------------------------
         int EstimationDetailID
        {
            get;
            set;
        }
         int ItemID
        {
            get;
            set;
        }
         string ItemName { get; set; }
         decimal Quantity
        {
            get;
            set;
        }
         decimal Rate
        {
            get;
            set;
        }
          int LocationID { get; set; }
         string errorMessage { get; set; }
         string SelectedBalanceSheet { get; set; }
         string XMLstring { get; set; }
         string EstimateLocationWiseXMLstring { get; set; }
         decimal AvailableStock { get; set; }
         int UnitID { get; set; }
         string UnitCode { get; set; }
         decimal Total { get; set; }
        decimal totalDiscountString { get; set; }
        decimal TotalTaxForItem { get; set; }
        decimal DiscountAmountForItem { get; set; }

         List<InventoryEstimationMasterAndDetails> InventoryEstimationMasterAndDetailsList { get; set; }
         List<InventoryLocationMaster> LocationList { get; set; }
    }
}
