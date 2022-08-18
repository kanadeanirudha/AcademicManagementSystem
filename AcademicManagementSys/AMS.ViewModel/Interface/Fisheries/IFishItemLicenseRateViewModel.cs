using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IFishItemLicenseRateViewModel
    {
        FishItemLicenseRate FishItemLicenseRateDTO { get; set; }

        int ID { get; set; }
        int ItemID { get; set; }
        int LicenseTypeID { get; set; }
        string CentreCode { get; set; }
        
        decimal Rate { get; set; }
        bool IsDeleted { get; set; }
        int CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        Nullable<int> ModifiedBy { get; set; }
        Nullable<DateTime> ModifiedDate { get; set; }
        Nullable<int> DeletedBy { get; set; }
        Nullable<DateTime> DeletedDate { get; set; }
    }
}
