using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;
namespace AMS.ViewModel
{
    public class GeneralCounterPOSApllicableViewModel : IGeneralCounterPOSApllicableViewModel
    {
        public GeneralCounterPOSApllicableViewModel()
        {
            GeneralCounterPOSApllicableDTO = new GeneralCounterPOSApllicable();
        }
        public GeneralCounterPOSApllicable GeneralCounterPOSApllicableDTO { get; set; }
        public Int32 ID
        {
            get { return (GeneralCounterPOSApllicableDTO != null && GeneralCounterPOSApllicableDTO.ID > 0) ? GeneralCounterPOSApllicableDTO.ID : new Int32(); }
            set { GeneralCounterPOSApllicableDTO.ID = value; }
        }
        public Int16 GeneralUnitsID
        {
            get { return (GeneralCounterPOSApllicableDTO != null && GeneralCounterPOSApllicableDTO.GeneralUnitsID > 0) ? GeneralCounterPOSApllicableDTO.GeneralUnitsID : new Int16(); }
            set { GeneralCounterPOSApllicableDTO.GeneralUnitsID = value; }
        }
        public Int16 GeneralCounterMasterID
        {
            get { return (GeneralCounterPOSApllicableDTO != null && GeneralCounterPOSApllicableDTO.GeneralCounterMasterID > 0) ? GeneralCounterPOSApllicableDTO.GeneralCounterMasterID : new Int16(); }
            set { GeneralCounterPOSApllicableDTO.GeneralCounterMasterID = value; }
        }
        public Int16 GeneralPOSMasterID
        {
            get { return (GeneralCounterPOSApllicableDTO != null && GeneralCounterPOSApllicableDTO.GeneralPOSMasterID > 0) ? GeneralCounterPOSApllicableDTO.GeneralPOSMasterID : new Int16(); }
            set { GeneralCounterPOSApllicableDTO.GeneralPOSMasterID = value; }
        }
        public Int16 GeneralWeavingMachineMasterID
        {
            get { return (GeneralCounterPOSApllicableDTO != null && GeneralCounterPOSApllicableDTO.GeneralWeavingMachineMasterID > 0) ? GeneralCounterPOSApllicableDTO.GeneralWeavingMachineMasterID : new Int16(); }
            set { GeneralCounterPOSApllicableDTO.GeneralWeavingMachineMasterID = value; }
        }
        public String DateFrom
        {
            get { return (GeneralCounterPOSApllicableDTO != null && GeneralCounterPOSApllicableDTO.DateFrom != null) ? GeneralCounterPOSApllicableDTO.DateFrom : String.Empty; }
            set { GeneralCounterPOSApllicableDTO.DateFrom = value; }
        }
        public String DateUpto
        {
            get { return (GeneralCounterPOSApllicableDTO != null && GeneralCounterPOSApllicableDTO.DateUpto != null) ? GeneralCounterPOSApllicableDTO.DateUpto : String.Empty; }
            set { GeneralCounterPOSApllicableDTO.DateUpto = value; }
        }
        public bool IsCurrent
        {
            get { return (GeneralCounterPOSApllicableDTO != null) ? GeneralCounterPOSApllicableDTO.IsCurrent : false; }
            set { GeneralCounterPOSApllicableDTO.IsCurrent = value; }
        }
        public Int32 CreatedBy
        {
            get { return (GeneralCounterPOSApllicableDTO != null && GeneralCounterPOSApllicableDTO.CreatedBy > 0) ? GeneralCounterPOSApllicableDTO.CreatedBy : new Int32(); }
            set { GeneralCounterPOSApllicableDTO.CreatedBy = value; }
        }
        public String CreatedDate
        {
            get { return (GeneralCounterPOSApllicableDTO != null && GeneralCounterPOSApllicableDTO.CreatedDate != null) ? GeneralCounterPOSApllicableDTO.CreatedDate : String.Empty; }
            set { GeneralCounterPOSApllicableDTO.CreatedDate = value; }
        }
        public Int32 ModifiedBy
        {
            get { return (GeneralCounterPOSApllicableDTO != null && GeneralCounterPOSApllicableDTO.ModifiedBy > 0) ? GeneralCounterPOSApllicableDTO.ModifiedBy : new Int32(); }
            set { GeneralCounterPOSApllicableDTO.ModifiedBy = value; }
        }
        public String ModifiedDate
        {
            get { return (GeneralCounterPOSApllicableDTO != null && GeneralCounterPOSApllicableDTO.ModifiedDate != null) ? GeneralCounterPOSApllicableDTO.ModifiedDate : String.Empty; }
            set { GeneralCounterPOSApllicableDTO.ModifiedDate = value; }
        }
        public Int32 DeletedBy
        {
            get { return (GeneralCounterPOSApllicableDTO != null && GeneralCounterPOSApllicableDTO.DeletedBy > 0) ? GeneralCounterPOSApllicableDTO.DeletedBy : new Int32(); }
            set { GeneralCounterPOSApllicableDTO.DeletedBy = value; }
        }
        public String DeletedDate
        {
            get { return (GeneralCounterPOSApllicableDTO != null && GeneralCounterPOSApllicableDTO.DeletedDate != null) ? GeneralCounterPOSApllicableDTO.DeletedDate : String.Empty; }
            set { GeneralCounterPOSApllicableDTO.DeletedDate = value; }
        }
        public bool IsDeleted
        {
            get { return (GeneralCounterPOSApllicableDTO != null) ? GeneralCounterPOSApllicableDTO.IsDeleted : false; }
            set { GeneralCounterPOSApllicableDTO.IsDeleted = value; }
        }
        public String LastSyncDate
        {
            get { return (GeneralCounterPOSApllicableDTO != null && GeneralCounterPOSApllicableDTO.LastSyncDate != null) ? GeneralCounterPOSApllicableDTO.LastSyncDate : String.Empty; }
            set { GeneralCounterPOSApllicableDTO.LastSyncDate = value; }
        }
        
        public String DeviceCode
        {
            get { return (GeneralCounterPOSApllicableDTO != null && GeneralCounterPOSApllicableDTO.DeviceCode != null) ? GeneralCounterPOSApllicableDTO.DeviceCode : String.Empty; }
            set { GeneralCounterPOSApllicableDTO.DeviceCode = value; }
        }
        public String InventoryAllocatePosOperatorXML
        {
            get { return (GeneralCounterPOSApllicableDTO != null && GeneralCounterPOSApllicableDTO.InventoryAllocatePosOperatorXML != null) ? GeneralCounterPOSApllicableDTO.InventoryAllocatePosOperatorXML : String.Empty; }
            set { GeneralCounterPOSApllicableDTO.InventoryAllocatePosOperatorXML = value; }
        }
        public String InventoryCounterLogXML
        {
            get { return (GeneralCounterPOSApllicableDTO != null && GeneralCounterPOSApllicableDTO.InventoryCounterLogXML != null) ? GeneralCounterPOSApllicableDTO.InventoryCounterLogXML : String.Empty; }
            set { GeneralCounterPOSApllicableDTO.InventoryCounterLogXML = value; }
        }
    }
}
