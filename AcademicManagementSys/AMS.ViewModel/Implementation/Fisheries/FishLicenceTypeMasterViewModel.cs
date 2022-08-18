using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class FishLicenceTypeMasterViewModel : IFishLicenceTypeMasterViewModel
    {
        public FishLicenceTypeMasterViewModel()
        {
            FishLicenceTypeMasterDTO = new FishLicenseType();
        }

        public FishLicenseType FishLicenceTypeMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (FishLicenceTypeMasterDTO != null && FishLicenceTypeMasterDTO.ID > 0) ? FishLicenceTypeMasterDTO.ID : new int();
            }
            set
            {
                FishLicenceTypeMasterDTO.ID = value;
            }
        }

        [Display(Name="License Type")]
        [Required(ErrorMessage = "License type should not be blank.")]
        public string LicenseType
        {
            get {
                return FishLicenceTypeMasterDTO != null ? FishLicenceTypeMasterDTO.LicenseType : string.Empty;
            }
            set
            {
                FishLicenceTypeMasterDTO.LicenseType = value;
            }
        }

        [Display(Name = "IsActive")]
        public bool IsActive
        {
            get
            {
                return FishLicenceTypeMasterDTO.IsActive != null ? FishLicenceTypeMasterDTO.IsActive : false;
            }
            set
            {
                FishLicenceTypeMasterDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return FishLicenceTypeMasterDTO.IsDeleted != null ? FishLicenceTypeMasterDTO.IsDeleted : false;
            }
            set
            {
                FishLicenceTypeMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (FishLicenceTypeMasterDTO.CreatedBy != null && FishLicenceTypeMasterDTO.CreatedBy > 0) ? FishLicenceTypeMasterDTO.CreatedBy : new int();
            }
            set
            {
                FishLicenceTypeMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (FishLicenceTypeMasterDTO.CreatedDate != null) ? FishLicenceTypeMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                FishLicenceTypeMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name="Modified By")]
        public Nullable<int> ModifiedBy
        {
            get
            {
                return FishLicenceTypeMasterDTO.ModifiedBy != null ? FishLicenceTypeMasterDTO.ModifiedBy : new int();
            }
            set
            {
                FishLicenceTypeMasterDTO.ModifiedBy = value;
            }
        }

        public Nullable<DateTime> ModifiedDate
        {
            get
            {
                return (FishLicenceTypeMasterDTO.ModifiedDate != null && FishLicenceTypeMasterDTO.ModifiedDate.HasValue) ? FishLicenceTypeMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                FishLicenceTypeMasterDTO.ModifiedDate = value;
            }
        }
        [Display(Name="Delete By")]
        public Nullable<int> DeletedBy
        {
            get
            {
                return (FishLicenceTypeMasterDTO != null && FishLicenceTypeMasterDTO.DeletedBy > 0) ? FishLicenceTypeMasterDTO.DeletedBy : new int();
            }
            set
            {
                FishLicenceTypeMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name="Delete Date")]
        public Nullable<DateTime> DeletedDate
        {
            get
            {
                return (FishLicenceTypeMasterDTO.DeletedDate != null && FishLicenceTypeMasterDTO.DeletedDate.HasValue) ? FishLicenceTypeMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                FishLicenceTypeMasterDTO.DeletedDate = value;
            }
        }
    }
}
