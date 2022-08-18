using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class GeneralCounterPOSApllicable : BaseDTO
    {
        public Int32 ID { get; set; }
        public Int16 GeneralUnitsID { get; set; }
        public Int16 GeneralCounterMasterID { get; set; }
        public Int16 GeneralPOSMasterID { get; set; }
        public Int16 GeneralWeavingMachineMasterID { get; set; }
        public string DateFrom { get; set; }
        public string DateUpto { get; set; }
        public bool IsCurrent { get; set; }
        public string InventoryAllocatePosOperatorXML { get; set; }
        public string InventoryCounterLogXML { get; set; }
        public Int32 CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public Int32 ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public Int32 DeletedBy { get; set; }
        public string DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool Flag { get; set; }
        public string LastSyncDate { get; set; }        
        public string DeviceCode { get; set; }
        public bool IsDataAvailable { get; set; }

    }
}
