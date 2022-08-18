using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class FishItemLicenseAllocationViewModel: IFishItemLicenseAllocationViewModel
    {
        public FishItemLicenseAllocationViewModel()
        {
            FishItemLicenseAllocationDTO = new FishItemLicenseAllocation();
        }
        public FishItemLicenseAllocation FishItemLicenseAllocationDTO { get; set; }

        public int ID
        {
            get
            {
                return (FishItemLicenseAllocationDTO != null && FishItemLicenseAllocationDTO.ID > 0) ? FishItemLicenseAllocationDTO.ID : new int();
            }
            set
            {
                FishItemLicenseAllocationDTO.ID = value;
            }
        }

        public int LocationID
        {
            get
            {
                return (FishItemLicenseAllocationDTO != null && FishItemLicenseAllocationDTO.LocationID > 0) ? FishItemLicenseAllocationDTO.LocationID : new int();
            }
            set
            {
                FishItemLicenseAllocationDTO.LocationID = value;
            }
        }

        public int LicenseTypeID
        {
            get
            {
                return (FishItemLicenseAllocationDTO != null && FishItemLicenseAllocationDTO.LicenseTypeID > 0) ? FishItemLicenseAllocationDTO.LicenseTypeID : new int();
            }
            set
            {
                FishItemLicenseAllocationDTO.LicenseTypeID = value;
            }
        }
        public int FishFishermenMasterID
        {
            get
            {
                return (FishItemLicenseAllocationDTO != null && FishItemLicenseAllocationDTO.FishFishermenMasterID > 0) ? FishItemLicenseAllocationDTO.FishFishermenMasterID : new int();
            }
            set
            {
                FishItemLicenseAllocationDTO.FishFishermenMasterID = value;
            }
        }

        public string FromDate
        {
            get
            {
                return (FishItemLicenseAllocationDTO != null && FishItemLicenseAllocationDTO.FromDate != "") ? FishItemLicenseAllocationDTO.FromDate : string.Empty;
            }
            set
            {
                FishItemLicenseAllocationDTO.FromDate = value;
            }
        }

        public string UptoDate
        {
            get
            {
                return (FishItemLicenseAllocationDTO != null && FishItemLicenseAllocationDTO.UptoDate != "") ? FishItemLicenseAllocationDTO.UptoDate : string.Empty;
            }
            set
            {
                FishItemLicenseAllocationDTO.UptoDate = value;
            }
        }

        public bool IsLastRecord
        {
            get
            {
                return (FishItemLicenseAllocationDTO != null && FishItemLicenseAllocationDTO.IsLastRecord == false) ? FishItemLicenseAllocationDTO.IsLastRecord : new bool();
            }
            set
            {
                FishItemLicenseAllocationDTO.IsLastRecord = value;
            }
        }

        public string PaymentMode
        {
            get
            {
                return (FishItemLicenseAllocationDTO != null && FishItemLicenseAllocationDTO.PaymentMode != "") ? FishItemLicenseAllocationDTO.PaymentMode : string.Empty;
            }
            set
            {
                FishItemLicenseAllocationDTO.PaymentMode = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return FishItemLicenseAllocationDTO.IsDeleted != null ? FishItemLicenseAllocationDTO.IsDeleted : false;
            }
            set
            {
                FishItemLicenseAllocationDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (FishItemLicenseAllocationDTO.CreatedBy != null && FishItemLicenseAllocationDTO.CreatedBy > 0) ? FishItemLicenseAllocationDTO.CreatedBy : new int();
            }
            set
            {
                FishItemLicenseAllocationDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (FishItemLicenseAllocationDTO.CreatedDate != null) ? FishItemLicenseAllocationDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                FishItemLicenseAllocationDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public Nullable<int> ModifiedBy
        {
            get
            {
                return FishItemLicenseAllocationDTO.ModifiedBy != null ? FishItemLicenseAllocationDTO.ModifiedBy : new int();
            }
            set
            {
                FishItemLicenseAllocationDTO.ModifiedBy = value;
            }
        }

        public Nullable<DateTime> ModifiedDate
        {
            get
            {
                return (FishItemLicenseAllocationDTO.ModifiedDate != null && FishItemLicenseAllocationDTO.ModifiedDate.HasValue) ? FishItemLicenseAllocationDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                FishItemLicenseAllocationDTO.ModifiedDate = value;
            }
        }
        [Display(Name = "Delete By")]
        public Nullable<int> DeletedBy
        {
            get
            {
                return (FishItemLicenseAllocationDTO != null && FishItemLicenseAllocationDTO.DeletedBy > 0) ? FishItemLicenseAllocationDTO.DeletedBy : new int();
            }
            set
            {
                FishItemLicenseAllocationDTO.DeletedBy = value;
            }
        }

        [Display(Name = "Delete Date")]
        public Nullable<DateTime> DeletedDate
        {
            get
            {
                return (FishItemLicenseAllocationDTO.DeletedDate != null && FishItemLicenseAllocationDTO.DeletedDate.HasValue) ? FishItemLicenseAllocationDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                FishItemLicenseAllocationDTO.DeletedDate = value;
            }
        }

        public string LocationName
        {
            get
            {
                return (FishItemLicenseAllocationDTO.LocationName != null && FishItemLicenseAllocationDTO.LocationName != "") ? FishItemLicenseAllocationDTO.LocationName : string.Empty;
            }
            set
            {
                FishItemLicenseAllocationDTO.LocationName = value;
            }
        }  
      
        public decimal Amount
        {
            get
            {
                return (FishItemLicenseAllocationDTO.Amount != null && FishItemLicenseAllocationDTO.Amount > 0) ? FishItemLicenseAllocationDTO.Amount : new decimal();
            }
            set
            {
                FishItemLicenseAllocationDTO.Amount = value;
            }
        }
    }
}
