using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class InventoryInWardMasterAndInWardDetailsViewModel : IInventoryInWardMasterAndInWardDetailsViewModel
    {
        public InventoryInWardMasterAndInWardDetailsViewModel()
        {
            InventoryInWardMasterAndInWardDetailsDTO = new InventoryInWardMasterAndInWardDetails();
            InWardMasterList = new List<InventoryInWardMasterAndInWardDetails>();
            systemseeting = new List<InventoryInWardMasterAndInWardDetails>();
             
           
        }
        public InventoryInWardMasterAndInWardDetails InventoryInWardMasterAndInWardDetailsDTO { get; set; }
        public List<InventoryInWardMasterAndInWardDetails> InWardMasterList { get; set; }
        public List<InventoryInWardMasterAndInWardDetails> systemseeting { get; set; } 
       

        //-----------------------------------InventoryInWardMasterAndInWardDetails Table Property-------------------------------//
        public int InventoryInWardMasterID
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null && InventoryInWardMasterAndInWardDetailsDTO.InventoryInWardMasterID > 0) ? InventoryInWardMasterAndInWardDetailsDTO.InventoryInWardMasterID : new int();
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.InventoryInWardMasterID = value;
            }
        }

        public DateTime InWordDate
        {
            get
            {
                return InventoryInWardMasterAndInWardDetailsDTO != null  ? InventoryInWardMasterAndInWardDetailsDTO.InWordDate : DateTime.Now;
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.InWordDate = value;
            }
        }

        public string InWordNumber
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null && InventoryInWardMasterAndInWardDetailsDTO.InWordNumber != "") ? InventoryInWardMasterAndInWardDetailsDTO.InWordNumber : string.Empty;
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.InWordNumber = value;
            }
        }

        public string InwordType
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null && InventoryInWardMasterAndInWardDetailsDTO.InwordType != "") ? InventoryInWardMasterAndInWardDetailsDTO.InwordType : string.Empty;
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.InwordType = value;
            }
        }

        public int IssueOrPurchaseID
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null && InventoryInWardMasterAndInWardDetailsDTO.IssueOrPurchaseID > 0) ? InventoryInWardMasterAndInWardDetailsDTO.IssueOrPurchaseID : new int();
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.IssueOrPurchaseID = value;
            }
        }

        public int InventoryInWardDetailsID
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null && InventoryInWardMasterAndInWardDetailsDTO.InventoryInWardDetailsID > 0) ? InventoryInWardMasterAndInWardDetailsDTO.InventoryInWardDetailsID : new int();
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.InventoryInWardDetailsID = value;
            }
        }

        public decimal Quantity
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null && InventoryInWardMasterAndInWardDetailsDTO.Quantity > 0) ? InventoryInWardMasterAndInWardDetailsDTO.Quantity : new decimal();
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.Quantity = value;
            }
        }

        public int ItemID
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null && InventoryInWardMasterAndInWardDetailsDTO.ItemID > 0) ? InventoryInWardMasterAndInWardDetailsDTO.ItemID : new int();
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.ItemID = value;
            }
        }
                

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return InventoryInWardMasterAndInWardDetailsDTO.IsDeleted != null ? InventoryInWardMasterAndInWardDetailsDTO.IsDeleted : false;
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO.CreatedBy != null && InventoryInWardMasterAndInWardDetailsDTO.CreatedBy > 0) ? InventoryInWardMasterAndInWardDetailsDTO.CreatedBy : new int();
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO.CreatedDate != null) ? InventoryInWardMasterAndInWardDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public Nullable<int> ModifiedBy
        {
            get
            {
                return InventoryInWardMasterAndInWardDetailsDTO.ModifiedBy != null ? InventoryInWardMasterAndInWardDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.ModifiedBy = value;
            }
        }

        public Nullable<DateTime> ModifiedDate
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO.ModifiedDate != null && InventoryInWardMasterAndInWardDetailsDTO.ModifiedDate.HasValue) ? InventoryInWardMasterAndInWardDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.ModifiedDate = value;
            }
        }
        [Display(Name = "Delete By")]
        public Nullable<int> DeletedBy
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null && InventoryInWardMasterAndInWardDetailsDTO.DeletedBy > 0) ? InventoryInWardMasterAndInWardDetailsDTO.DeletedBy : new int();
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "Delete Date")]
        public Nullable<DateTime> DeletedDate
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO.DeletedDate != null && InventoryInWardMasterAndInWardDetailsDTO.DeletedDate.HasValue) ? InventoryInWardMasterAndInWardDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.DeletedDate = value;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null && InventoryInWardMasterAndInWardDetailsDTO.ErrorMessage != "") ? InventoryInWardMasterAndInWardDetailsDTO.ErrorMessage : string.Empty;
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.ErrorMessage = value;
            }
        }

        public int IssueFromLocationID
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null && InventoryInWardMasterAndInWardDetailsDTO.IssueFromLocationID > 0) ? InventoryInWardMasterAndInWardDetailsDTO.IssueFromLocationID : new int();
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.IssueFromLocationID = value;
            }
        }
        public int IssueToLocationID
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null && InventoryInWardMasterAndInWardDetailsDTO.IssueToLocationID > 0) ? InventoryInWardMasterAndInWardDetailsDTO.IssueToLocationID : new int();
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.IssueToLocationID = value;
            }
        }
        public string IssueFromLocationName
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null) ? InventoryInWardMasterAndInWardDetailsDTO.IssueFromLocationName : string.Empty;
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.IssueFromLocationName = value;
            }
        }
        public string IssueToLocationName
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null) ? InventoryInWardMasterAndInWardDetailsDTO.IssueToLocationName : string.Empty;
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.IssueToLocationName = value;
            }
        }

        public int TotalrowCount
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null && InventoryInWardMasterAndInWardDetailsDTO.TotalrowCount > 0) ? InventoryInWardMasterAndInWardDetailsDTO.TotalrowCount : new int();
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.TotalrowCount = value;
            }
        }
        public int RowCount
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null && InventoryInWardMasterAndInWardDetailsDTO.RowCount > 0) ? InventoryInWardMasterAndInWardDetailsDTO.RowCount : new int();
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.RowCount = value;
            }
        }
        #region -------------- TaskNotification Properties---------------
        public int TaskNotificationMasterID
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null && InventoryInWardMasterAndInWardDetailsDTO.TaskNotificationMasterID > 0) ? InventoryInWardMasterAndInWardDetailsDTO.TaskNotificationMasterID : new int();
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.TaskNotificationMasterID = value;
            }
        }
        //[Display(Name = "DisplayName_LeaveCode", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveCodeRequired")]
        public string TaskCode
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null) ? InventoryInWardMasterAndInWardDetailsDTO.TaskCode : string.Empty;
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.TaskCode = value;
            }
        }

        public int TaskNotificationDetailsID
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null && InventoryInWardMasterAndInWardDetailsDTO.TaskNotificationDetailsID > 0) ? InventoryInWardMasterAndInWardDetailsDTO.TaskNotificationDetailsID : new int();
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.TaskNotificationDetailsID = value;
            }
        }
        public int GeneralTaskReportingDetailsID
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null && InventoryInWardMasterAndInWardDetailsDTO.GeneralTaskReportingDetailsID > 0) ? InventoryInWardMasterAndInWardDetailsDTO.GeneralTaskReportingDetailsID : new int();
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.GeneralTaskReportingDetailsID = value;
            }
        }

        public int PersonID
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null && InventoryInWardMasterAndInWardDetailsDTO.PersonID > 0) ? InventoryInWardMasterAndInWardDetailsDTO.PersonID : new int();
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.PersonID = value;
            }
        }

        public int StageSequenceNumber
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null && InventoryInWardMasterAndInWardDetailsDTO.StageSequenceNumber > 0) ? InventoryInWardMasterAndInWardDetailsDTO.StageSequenceNumber : new int();
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.StageSequenceNumber = value;
            }
        }

        public bool IsLastRecord
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null) ? InventoryInWardMasterAndInWardDetailsDTO.IsLastRecord : false;
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.IsLastRecord = value;
            }
        }
        public int UnitID
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null && InventoryInWardMasterAndInWardDetailsDTO.UnitID > 0) ? InventoryInWardMasterAndInWardDetailsDTO.UnitID : new int();
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.UnitID = value;
            }
        }
        [Display(Name = "DisplayName_UnitCode", ResourceType = typeof(Resources))]
        public string UnitCode
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null) ? InventoryInWardMasterAndInWardDetailsDTO.UnitCode : string.Empty;
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.UnitCode = value;
            }
        }
        public string Remark
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null) ? InventoryInWardMasterAndInWardDetailsDTO.Remark : string.Empty;
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.Remark = value;
            }
        }
        public string FieldName
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null && InventoryInWardMasterAndInWardDetailsDTO.FieldName != "") ? InventoryInWardMasterAndInWardDetailsDTO.FieldName : string.Empty;
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.FieldName = value;
            }
        }
        public int FieldValue
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null && InventoryInWardMasterAndInWardDetailsDTO.FieldValue > 0) ? InventoryInWardMasterAndInWardDetailsDTO.FieldValue : new int();
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.FieldValue = value;
            }
        }
        public int LocationID
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null && InventoryInWardMasterAndInWardDetailsDTO.LocationID > 0) ? InventoryInWardMasterAndInWardDetailsDTO.LocationID : new int();
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.LocationID = value;
            }
        }
        public int BalanceSheetID
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null && InventoryInWardMasterAndInWardDetailsDTO.BalanceSheetID > 0) ? InventoryInWardMasterAndInWardDetailsDTO.BalanceSheetID : new int();
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.BalanceSheetID = value;
            }
        }
        public string XMLstring
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null) ? InventoryInWardMasterAndInWardDetailsDTO.XMLstring : string.Empty;
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.XMLstring = value;
            }
        }
        public string CentreCode { get; set; }
        public bool IsOnlineOfflineFlag
        {
            get
            {
                return (InventoryInWardMasterAndInWardDetailsDTO != null) ? InventoryInWardMasterAndInWardDetailsDTO.IsOnlineOfflineFlag : false;
            }
            set
            {
                InventoryInWardMasterAndInWardDetailsDTO.IsOnlineOfflineFlag = value;
            }
        }
        public int AccountSessionID
        {
            get;
            set;
        }
        
        #endregion


    }
}
