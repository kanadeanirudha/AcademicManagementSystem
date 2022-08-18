using AMS.Common;
using AMS.DTO;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class InventoryDumpAndShrinkMasterAndDetailsViewModel : IInventoryDumpAndShrinkMasterAndDetailsViewModel
    {
        public InventoryDumpAndShrinkMasterAndDetailsViewModel()
        {
            InventoryDumpAndShrinkMasterAndDetailsDTO = new InventoryDumpAndShrinkMasterAndDetails();
            LocationList = new List<InventoryLocationMaster>();
            DumpAndShrinkDetailList = new List<InventoryDumpAndShrinkMasterAndDetails>();
        }
        public List<InventoryLocationMaster> LocationList { get; set; }
        public List<InventoryDumpAndShrinkMasterAndDetails> DumpAndShrinkDetailList { get; set; }
        public IEnumerable<SelectListItem> LocationListItems
        {
            get
            {
                return new SelectList(LocationList, "ID", "LocationName");
            }
        }
        public InventoryDumpAndShrinkMasterAndDetails InventoryDumpAndShrinkMasterAndDetailsDTO { get; set; }
        //---------------------------------------Properties of Dump & Shrink Master Table-----------------------------
        public int ID
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null && InventoryDumpAndShrinkMasterAndDetailsDTO.ID > 0) ? InventoryDumpAndShrinkMasterAndDetailsDTO.ID : new int();
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.ID = value;
            }
        }
        public string TransactionDate
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null) ? InventoryDumpAndShrinkMasterAndDetailsDTO.TransactionDate : string.Empty;
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.TransactionDate = value;
            }
        }
        //[Display(Name = "DisplayName_DumpAndShrinkAmount", ResourceType = typeof(Resources))]
        public decimal DumpAndShrinkAmount
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null && InventoryDumpAndShrinkMasterAndDetailsDTO.DumpAndShrinkAmount > 0) ? InventoryDumpAndShrinkMasterAndDetailsDTO.DumpAndShrinkAmount : new decimal();
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.DumpAndShrinkAmount = value;
            }
        }
        public int LocationID
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null && InventoryDumpAndShrinkMasterAndDetailsDTO.LocationID > 0) ? InventoryDumpAndShrinkMasterAndDetailsDTO.LocationID : new int();
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.LocationID = value;
            }
        }
        public int BalanceSheetID
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null && InventoryDumpAndShrinkMasterAndDetailsDTO.BalanceSheetID > 0) ? InventoryDumpAndShrinkMasterAndDetailsDTO.BalanceSheetID : new int();
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.BalanceSheetID = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null) ? InventoryDumpAndShrinkMasterAndDetailsDTO.IsActive : false;
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.IsActive = value;
            }
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null && InventoryDumpAndShrinkMasterAndDetailsDTO.CreatedBy > 0) ? InventoryDumpAndShrinkMasterAndDetailsDTO.CreatedBy : new short();
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null) ? InventoryDumpAndShrinkMasterAndDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.CreatedDate = value;
            }
        }
        public int? ModifiedBy
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null && InventoryDumpAndShrinkMasterAndDetailsDTO.ModifiedBy > 0) ? InventoryDumpAndShrinkMasterAndDetailsDTO.ModifiedBy : new short();
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.ModifiedBy = value;
            }
        }
        public DateTime? ModifiedDate
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null) ? InventoryDumpAndShrinkMasterAndDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.ModifiedDate = value;
            }
        }
        public int? DeletedBy
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null && InventoryDumpAndShrinkMasterAndDetailsDTO.DeletedBy > 0) ? InventoryDumpAndShrinkMasterAndDetailsDTO.DeletedBy : new short();
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.DeletedBy = value;
            }
        }
        public DateTime? DeletedDate
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null) ? InventoryDumpAndShrinkMasterAndDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.DeletedDate = value;
            }
        }
        //--------------------------------------Properties of Dump & Shrink Details Table------------------------------
        public int DumpAndShrinkDetailID
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null && InventoryDumpAndShrinkMasterAndDetailsDTO.DumpAndShrinkDetailID > 0) ? InventoryDumpAndShrinkMasterAndDetailsDTO.DumpAndShrinkDetailID : new int();
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.DumpAndShrinkDetailID = value;
            }
        }
        public int ItemID
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null && InventoryDumpAndShrinkMasterAndDetailsDTO.ItemID > 0) ? InventoryDumpAndShrinkMasterAndDetailsDTO.ItemID : new int();
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.ItemID = value;
            }
        }
        [Display(Name = "DisplayName_ItemName", ResourceType = typeof(Resources))]
        public string ItemName
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null) ? InventoryDumpAndShrinkMasterAndDetailsDTO.ItemName : string.Empty;
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.ItemName = value;
            }
        }
        [Display(Name = "Waste Qty.")]
        public decimal DumpQuantity
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null && InventoryDumpAndShrinkMasterAndDetailsDTO.DumpQuantity > 0) ? InventoryDumpAndShrinkMasterAndDetailsDTO.DumpQuantity : new decimal();
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.DumpQuantity = value;
            }
        }
        [Display(Name = "Shrink Qty.")]
        public decimal ShrinkQuantity
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null && InventoryDumpAndShrinkMasterAndDetailsDTO.ShrinkQuantity > 0) ? InventoryDumpAndShrinkMasterAndDetailsDTO.ShrinkQuantity : new decimal();
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.ShrinkQuantity = value;
            }
        }
        [Display(Name = "Current Qty.")]
        public decimal CurrentQuantity
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null && InventoryDumpAndShrinkMasterAndDetailsDTO.CurrentQuantity > 0) ? InventoryDumpAndShrinkMasterAndDetailsDTO.CurrentQuantity : new decimal();
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.CurrentQuantity = value;
            }
        }
        [Display(Name = "Actual Qty.")]
        public decimal ActualWeight
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null && InventoryDumpAndShrinkMasterAndDetailsDTO.ActualWeight > 0) ? InventoryDumpAndShrinkMasterAndDetailsDTO.ActualWeight : new decimal();
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.ActualWeight = value;
            }
        }
        [Display(Name = "DisplayName_Rate", ResourceType = typeof(Resources))]
        public decimal Rate
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null && InventoryDumpAndShrinkMasterAndDetailsDTO.Rate > 0) ? InventoryDumpAndShrinkMasterAndDetailsDTO.Rate : new decimal();
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.Rate = value;
            }
        }
        public int UnitID
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null && InventoryDumpAndShrinkMasterAndDetailsDTO.UnitID > 0) ? InventoryDumpAndShrinkMasterAndDetailsDTO.UnitID : new int();
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.UnitID = value;
            }
        }
        [Display(Name = "DisplayName_UnitCode", ResourceType = typeof(Resources))]
        public string UnitCode
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null) ? InventoryDumpAndShrinkMasterAndDetailsDTO.UnitCode : string.Empty;
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.UnitCode = value;
            }
        }
        public string Remark
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null) ? InventoryDumpAndShrinkMasterAndDetailsDTO.Remark : string.Empty;
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.Remark = value;
            }
        }
        public string Location
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null) ? InventoryDumpAndShrinkMasterAndDetailsDTO.Location : string.Empty;
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.Location = value;
            }
        }
        public string errorMessage
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null) ? InventoryDumpAndShrinkMasterAndDetailsDTO.errorMessage : string.Empty;
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.errorMessage = value;
            }
        }
        public string XMLstring
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null) ? InventoryDumpAndShrinkMasterAndDetailsDTO.XMLstring : string.Empty;
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.XMLstring = value;
            }
        }
        public bool ApprovedStatus
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null) ? InventoryDumpAndShrinkMasterAndDetailsDTO.ApprovedStatus : false;
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.ApprovedStatus = value;
            }
        }
        #region -------------- TaskNotification Properties---------------
        public int TaskNotificationMasterID
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null && InventoryDumpAndShrinkMasterAndDetailsDTO.TaskNotificationMasterID > 0) ? InventoryDumpAndShrinkMasterAndDetailsDTO.TaskNotificationMasterID : new int();
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.TaskNotificationMasterID = value;
            }
        }
        //[Display(Name = "DisplayName_LeaveCode", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveCodeRequired")]
        public string TaskCode
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null) ? InventoryDumpAndShrinkMasterAndDetailsDTO.TaskCode : string.Empty;
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.TaskCode = value;
            }
        }

        public int TaskNotificationDetailsID
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null && InventoryDumpAndShrinkMasterAndDetailsDTO.TaskNotificationDetailsID > 0) ? InventoryDumpAndShrinkMasterAndDetailsDTO.TaskNotificationDetailsID : new int();
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.TaskNotificationDetailsID = value;
            }
        }
        public int GeneralTaskReportingDetailsID
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null && InventoryDumpAndShrinkMasterAndDetailsDTO.GeneralTaskReportingDetailsID > 0) ? InventoryDumpAndShrinkMasterAndDetailsDTO.GeneralTaskReportingDetailsID : new int();
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.GeneralTaskReportingDetailsID = value;
            }
        }

        public int PersonID
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null && InventoryDumpAndShrinkMasterAndDetailsDTO.PersonID > 0) ? InventoryDumpAndShrinkMasterAndDetailsDTO.PersonID : new int();
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.PersonID = value;
            }
        }

        public int StageSequenceNumber
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null && InventoryDumpAndShrinkMasterAndDetailsDTO.StageSequenceNumber > 0) ? InventoryDumpAndShrinkMasterAndDetailsDTO.StageSequenceNumber : new int();
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.StageSequenceNumber = value;
            }
        }

        public bool IsLastRecord
        {
            get
            {
                return (InventoryDumpAndShrinkMasterAndDetailsDTO != null) ? InventoryDumpAndShrinkMasterAndDetailsDTO.IsLastRecord : false;
            }
            set
            {
                InventoryDumpAndShrinkMasterAndDetailsDTO.IsLastRecord = value;
            }
        }

        #endregion
    }
}
