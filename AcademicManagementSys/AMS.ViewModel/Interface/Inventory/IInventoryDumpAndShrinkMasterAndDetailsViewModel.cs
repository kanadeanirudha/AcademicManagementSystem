using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IInventoryDumpAndShrinkMasterAndDetailsViewModel
    {
        InventoryDumpAndShrinkMasterAndDetails InventoryDumpAndShrinkMasterAndDetailsDTO { get; set; }
        //------------------------------------Properties of Dump & Shrink Master Table------------------------------------
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
         int BalanceSheetID
        {
            get;
            set;
        }
         int LocationID
        {
            get;
            set;
        }
         decimal DumpAndShrinkAmount
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

         //------------------------------------Properties of Dump & Shrink Details Table------------------------------------
         int DumpAndShrinkDetailID
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
         decimal DumpQuantity
         {
             get;
             set;
         }
         decimal ShrinkQuantity
         {
             get;
             set;
         }
         decimal CurrentQuantity { get; set; }
         decimal ActualWeight { get; set; }
         decimal Rate
         {
             get;
             set;
         }
         bool ApprovedStatus
         {
             get;
             set;
         }
         string Remark
         {
             get;
             set;
         }
         int UnitID { get; set; }
         string UnitCode { get; set; }
         // string BalancesheetName { get; set; }
          string Location { get; set; }
         string errorMessage { get; set; }
         List<InventoryLocationMaster> LocationList { get; set; }
         List<InventoryDumpAndShrinkMasterAndDetails> DumpAndShrinkDetailList { get; set; }

         #region -------------- TaskNotification Properties---------------
         int TaskNotificationMasterID
         {
             get;
             set;
         }
         string TaskCode
         {
             get;
             set;
         }
         int TaskNotificationDetailsID
         {
             get;
             set;
         }
         int GeneralTaskReportingDetailsID
         {
             get;
             set;
         }
         int PersonID
         {
             get;
             set;
         }
         int StageSequenceNumber
         {
             get;
             set;
         }
         bool IsLastRecord
         {
             get;
             set;
         }
         #endregion
    }
}
