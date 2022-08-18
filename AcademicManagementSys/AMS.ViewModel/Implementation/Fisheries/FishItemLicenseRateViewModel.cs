using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class FishItemLicenseRateViewModel : IFishItemLicenseRateViewModel
    {
        public FishItemLicenseRateViewModel()
        {
            FishItemLicenseRateDTO = new FishItemLicenseRate();

            //Filters
            ListApplicableCentre = new List<AdminRoleApplicableDetails>(); 
            ListGetFishLicenseType = new List<FishLicenseType>();
        }
        public FishItemLicenseRate FishItemLicenseRateDTO { get; set; }

        //Filters get-set
        public List<AdminRoleApplicableDetails> ListApplicableCentre { get; set; }
        public List<FishLicenseType> ListGetFishLicenseType { get; set; }

        public IEnumerable<SelectListItem> ListGetApplicableCentreItems
        {
            get
            {
                return new SelectList(ListApplicableCentre, "CentreCode", "CentreName");
            }
        }

        public IEnumerable<SelectListItem> ListGetFishLicenseTypeItems
        {
            get
            {
                return new SelectList(ListGetFishLicenseType, "ID", "LicenseType");
            }
        }

        //-----------------------------------Table Property-------------------------------//
        public int ID
        {
            get
            {
                return (FishItemLicenseRateDTO != null && FishItemLicenseRateDTO.ID > 0) ? FishItemLicenseRateDTO.ID : new int();
            }
            set
            {
                FishItemLicenseRateDTO.ID = value;
            }
        }

        public int ItemID
        {
            get
            {
                return (FishItemLicenseRateDTO != null && FishItemLicenseRateDTO.ItemID > 0) ? FishItemLicenseRateDTO.ItemID : new int();
            }
            set
            {
                FishItemLicenseRateDTO.ItemID = value;
            }
        }

        public int LicenseTypeID
        {
            get
            {
                return (FishItemLicenseRateDTO != null && FishItemLicenseRateDTO.LicenseTypeID > 0) ? FishItemLicenseRateDTO.LicenseTypeID : new int();
            }
            set
            {
                FishItemLicenseRateDTO.LicenseTypeID = value;
            }
        }

        public string CentreCode
        {
            get
            {
                return (FishItemLicenseRateDTO != null && FishItemLicenseRateDTO.CentreCode != "") ? FishItemLicenseRateDTO.CentreCode : string.Empty;
            }
            set
            {
                FishItemLicenseRateDTO.CentreCode = value;
            }
        }

        
        [Required(ErrorMessage = "Rate should not blank.")]
        public decimal Rate
        {
            get
            {
                return (FishItemLicenseRateDTO != null && FishItemLicenseRateDTO.Rate > 0) ? FishItemLicenseRateDTO.Rate : new decimal();
            } 
            set
            {
                FishItemLicenseRateDTO.Rate = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return FishItemLicenseRateDTO.IsDeleted != null ? FishItemLicenseRateDTO.IsDeleted : false;
            }
            set
            {
                FishItemLicenseRateDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (FishItemLicenseRateDTO.CreatedBy != null && FishItemLicenseRateDTO.CreatedBy > 0) ? FishItemLicenseRateDTO.CreatedBy : new int();
            }
            set
            {
                FishItemLicenseRateDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (FishItemLicenseRateDTO.CreatedDate != null) ? FishItemLicenseRateDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                FishItemLicenseRateDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public Nullable<int> ModifiedBy
        {
            get
            {
                return FishItemLicenseRateDTO.ModifiedBy != null ? FishItemLicenseRateDTO.ModifiedBy : new int();
            }
            set
            {
                FishItemLicenseRateDTO.ModifiedBy = value;
            }
        }

        public Nullable<DateTime> ModifiedDate
        {
            get
            {
                return (FishItemLicenseRateDTO.ModifiedDate != null && FishItemLicenseRateDTO.ModifiedDate.HasValue) ? FishItemLicenseRateDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                FishItemLicenseRateDTO.ModifiedDate = value;
            }
        }
        [Display(Name = "Delete By")]
        public Nullable<int> DeletedBy
        {
            get
            {
                return (FishItemLicenseRateDTO != null && FishItemLicenseRateDTO.DeletedBy > 0) ? FishItemLicenseRateDTO.DeletedBy : new int();
            }
            set
            {
                FishItemLicenseRateDTO.DeletedBy = value;
            }
        }

        [Display(Name = "Delete Date")]
        public Nullable<DateTime> DeletedDate
        {
            get
            {
                return (FishItemLicenseRateDTO.DeletedDate != null && FishItemLicenseRateDTO.DeletedDate.HasValue) ? FishItemLicenseRateDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                FishItemLicenseRateDTO.DeletedDate = value;
            }
        }












        //---------------------------Extra Property -----------------------------------//
        public string ItemName
        {
            get
            {
                return (FishItemLicenseRateDTO != null && FishItemLicenseRateDTO.ItemName != "") ? FishItemLicenseRateDTO.ItemName : string.Empty;
            }
            set
            {
                FishItemLicenseRateDTO.ItemName = value;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return (FishItemLicenseRateDTO != null && FishItemLicenseRateDTO.ErrorMessage != "") ? FishItemLicenseRateDTO.ErrorMessage : string.Empty;
            }
            set
            {
                FishItemLicenseRateDTO.ErrorMessage = value;
            }
        }
    }
}
