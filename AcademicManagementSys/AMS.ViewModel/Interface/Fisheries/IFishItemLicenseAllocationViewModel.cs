using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IFishItemLicenseAllocationViewModel
    {
        FishItemLicenseAllocation FishItemLicenseAllocationDTO { get; set; }

        int ID { get; set; }
        int LocationID { get; set; }
        int LicenseTypeID { get; set; }
        int FishFishermenMasterID { get; set; }
        string FromDate { get; set; }
        string UptoDate { get; set; }
        bool IsLastRecord { get; set; }
        
        bool IsDeleted { get; set; }
        int CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        int? ModifiedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
        int? DeletedBy { get; set; }
        DateTime? DeletedDate { get; set; }
        string PaymentMode { get; set; }

        string LocationName { get; set; }
        decimal Amount { get; set; }
    }
}
