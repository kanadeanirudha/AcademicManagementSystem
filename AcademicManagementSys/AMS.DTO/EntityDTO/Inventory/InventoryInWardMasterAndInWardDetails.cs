using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class InventoryInWardMasterAndInWardDetails : BaseDTO
    {
        //---------------------------------------InventoryWardMaster-----------------------------
        public int InventoryInWardMasterID { get; set; }
        public DateTime InWordDate { get; set; }
        public string InWordNumber { get; set; }
        public string InwordType { get; set; }
        public int IssueOrPurchaseID { get; set; }
        public string XMLstring { get; set; }

        //-------------------------------InvInwardDetails------------------------------------------
        public int InventoryInWardDetailsID { get; set; }
        public decimal Quantity { get; set; }
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int UnitID { get; set; }
        public string UnitCode { get; set; }
        public decimal InwardQuantity { get; set; }
        public decimal DamagedQuantity { get; set; }
        public decimal StolenQuantity { get; set; } 
        public string Remark { get; set; }
        public int IssueFromLocationID {get;set;}
        public int IssueToLocationID{get;set;}
        public string IssueFromLocationName {get;set;}
        public string IssueToLocationName { get;set;}
        public int StartRow { get; set; }


        //-------------------------Common Property----------------------------------------------------------------
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<DateTime> DeletedDate { get; set; }
        public string errorMessage { get; set; }
        public int TotalrowCount { get; set; }
        public int RowCount { get; set; }

          #region ------------TaskNotification Properties---------------
        public int TaskNotificationMasterID
        {
            get;
            set;
        }
        public string TaskCode
        {
            get;
            set;
        }
        public int TaskNotificationDetailsID
        {
            get;
            set;
        }
        public int GeneralTaskReportingDetailsID
        {
            get;
            set;
        }
        public int PersonID
        {
            get;
            set;
        }
        public int StageSequenceNumber
        {
            get;
            set;
        }
        public bool IsLastRecord
        {
            get;
            set;
        }


        // paramerters for InvSystemSettingMaster
        public int BalanceSheetID
        {
            get;
            set;
        }
        public int LocationID
        {
            get;
            set;
        }

        public string FieldName
        {
            get;
            set;
        }
        public int FieldValue
        {
            get;
            set;
        }
        public string CentreCode { get; set; }
        public bool IsOnlineOfflineFlag
        {
            get;
            set;
        }
        public int AccountSessionID
        {
            get;
            set;
        }
        #endregion
	

    }
}
