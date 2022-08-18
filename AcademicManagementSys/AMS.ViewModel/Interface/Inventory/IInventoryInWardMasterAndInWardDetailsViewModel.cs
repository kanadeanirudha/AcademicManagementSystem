using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IInventoryInWardMasterAndInWardDetailsViewModel
    {
        InventoryInWardMasterAndInWardDetails InventoryInWardMasterAndInWardDetailsDTO { get; set; }

        //---------------------------------------InventoryWardMaster-----------------------------
        int InventoryInWardMasterID { get; set; }
        DateTime InWordDate { get; set; }
        string InWordNumber { get; set; }
        string InwordType { get; set; }
        int IssueOrPurchaseID { get; set; }


        //-------------------------------InvInwardDetails------------------------------------------
        int InventoryInWardDetailsID { get; set; }
        decimal Quantity { get; set; }
        int ItemID { get; set; }
        int UnitID { get; set; }
        string UnitCode { get; set; }

        //-------------------------Common Property----------------------------------------------------------------
        bool IsDeleted { get; set; }
        int CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        Nullable<int> ModifiedBy { get; set; }
        Nullable<DateTime> ModifiedDate { get; set; }
        Nullable<int> DeletedBy { get; set; }
        Nullable<DateTime> DeletedDate { get; set; }
        string ErrorMessage { get; set; }

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

        List<InventoryInWardMasterAndInWardDetails> InWardMasterList { get; set; }
        List<InventoryInWardMasterAndInWardDetails> systemseeting { get; set; }
        string FieldName { get; set; }
        int FieldValue { get; set; }
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
        string XMLstring { get; set; }
        string CentreCode { get; set; }
        bool IsOnlineOfflineFlag { get; set; }
        int IssueToLocationID { get; set; }
         int AccountSessionID
        {
            get;
            set;
        }
          int TotalrowCount { get; set; }
         int RowCount { get; set; }
    }
}
