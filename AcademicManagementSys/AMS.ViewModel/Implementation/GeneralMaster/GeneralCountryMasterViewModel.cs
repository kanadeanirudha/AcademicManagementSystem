using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
     public class GeneralCountryMasterViewModel : IGeneralCountryMasterViewModel
    {

        public GeneralCountryMasterViewModel()
        {
            GeneralCountryMasterDTO = new GeneralCountryMaster();
        }

        public GeneralCountryMaster GeneralCountryMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (GeneralCountryMasterDTO != null && GeneralCountryMasterDTO.ID > 0) ? GeneralCountryMasterDTO.ID : new int();
            }
            set
            {
                GeneralCountryMasterDTO.ID = value;
            }
        }

        [Display(Name = "DisplayName_SeqNo", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SeqNoRequired")]
        public Nullable<int> SeqNo
        {
            get
            {
                return (GeneralCountryMasterDTO != null && GeneralCountryMasterDTO.SeqNo > 0) ? GeneralCountryMasterDTO.SeqNo : new int();
            }
            set
            {
                GeneralCountryMasterDTO.SeqNo = value;
            }
        }
        [Display(Name = "DisplayName_CountryName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CountryNameRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string CountryName
        {
            get
            {
                return (GeneralCountryMasterDTO != null) ? GeneralCountryMasterDTO.CountryName : string.Empty;
            }
            set
            {
                GeneralCountryMasterDTO.CountryName = value;
            }
        }

        [Display(Name = "DisplayName_CountryCode", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_ContryCodeRequired")]
        //[Required(ErrorMessage = "Country code should not be blank.")]
        //[Display(Name = "Contry Code")]
        public string ContryCode
        {
            get
            {
                return (GeneralCountryMasterDTO != null) ? GeneralCountryMasterDTO.ContryCode : string.Empty;
            }
            set
            {
                GeneralCountryMasterDTO.ContryCode = value;
            }
        }

        [Display(Name = "DefaultFlag", ResourceType = typeof(Resources))]
        public bool DefaultFlag
        {
            get
            {
                return (GeneralCountryMasterDTO != null) ? GeneralCountryMasterDTO.DefaultFlag : false;
            }
            set
            {
                GeneralCountryMasterDTO.DefaultFlag = value;
            }
        }
        public bool IsUserDefined
        {
            get
            {
                return (GeneralCountryMasterDTO != null) ? GeneralCountryMasterDTO.IsUserDefined : false;
            }
            set
            {
                GeneralCountryMasterDTO.IsUserDefined = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (GeneralCountryMasterDTO != null) ? GeneralCountryMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralCountryMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public Nullable<int> CreatedBy
        {
            get
            {
                return (GeneralCountryMasterDTO != null && GeneralCountryMasterDTO.CreatedBy > 0) ? GeneralCountryMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralCountryMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (GeneralCountryMasterDTO != null) ? GeneralCountryMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralCountryMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralCountryMasterDTO != null && GeneralCountryMasterDTO.ModifiedBy.HasValue) ? GeneralCountryMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralCountryMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralCountryMasterDTO != null && GeneralCountryMasterDTO.ModifiedDate.HasValue) ? GeneralCountryMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralCountryMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralCountryMasterDTO != null && GeneralCountryMasterDTO.DeletedBy.HasValue) ? GeneralCountryMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralCountryMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralCountryMasterDTO != null && GeneralCountryMasterDTO.DeletedDate.HasValue) ? GeneralCountryMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralCountryMasterDTO.DeletedDate = value;
            }
        }

        public string SelectedCountryID
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}

