using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IFishLicenceTypeMasterViewModel
    {
        FishLicenseType FishLicenceTypeMasterDTO
        {
            get;
            set;

        }
        int ID 
        { 
            get; 
            set; 
        }
        string LicenseType
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
        Nullable<int> ModifiedBy
        {
            get;
            set;
        }
        Nullable<DateTime> ModifiedDate
        {
            get;
            set;
        }
        Nullable<int> DeletedBy
        {
            get;
            set;
        }
        Nullable<DateTime> DeletedDate
        {
            get;
            set;
        }
    }
}
