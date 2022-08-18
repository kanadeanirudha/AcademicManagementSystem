using AMS.DTO;
using System;
namespace AMS.ViewModel
{
    public interface IGeneralCounterPOSApllicableViewModel
    {
        GeneralCounterPOSApllicable GeneralCounterPOSApllicableDTO { get; set; }
        Int32 ID { get; set; }
        Int16 GeneralUnitsID { get; set; }
        Int16 GeneralCounterMasterID { get; set; }
        Int16 GeneralPOSMasterID { get; set; }
        Int16 GeneralWeavingMachineMasterID { get; set; }
        string DateFrom { get; set; }
        string DateUpto { get; set; }
        bool IsCurrent { get; set; }
        Int32 CreatedBy { get; set; }
        string CreatedDate { get; set; }
        Int32 ModifiedBy { get; set; }
        string ModifiedDate { get; set; }
        Int32 DeletedBy { get; set; }
        string DeletedDate { get; set; }
        bool IsDeleted { get; set; }
    }
}
