using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class EmployeeContactDetailsViewModel
    {
        public EmployeeContactDetailsViewModel()
        {
            EmployeeContactDetailsDTO = new EmployeeContactDetails();
        }
        public EmployeeContactDetails EmployeeContactDetailsDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (EmployeeContactDetailsDTO != null && EmployeeContactDetailsDTO.ID > 0) ? EmployeeContactDetailsDTO.ID : new int();
            }
            set
            {
                EmployeeContactDetailsDTO.ID = value;
            }
        }

        public int ContactID
        {
            get
            {
                return (EmployeeContactDetailsDTO != null && EmployeeContactDetailsDTO.ContactID > 0) ? EmployeeContactDetailsDTO.ContactID : new int();
            }
            set
            {
                EmployeeContactDetailsDTO.ContactID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return (EmployeeContactDetailsDTO != null && EmployeeContactDetailsDTO.EmployeeID > 0) ? EmployeeContactDetailsDTO.EmployeeID : new int();
            }
            set
            {
                EmployeeContactDetailsDTO.EmployeeID = value;
            }
        }

        [Display(Name = "DisplayName_AddressType", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_AddressTypeRequired")]
        //[Required(ErrorMessage = "Address Type must be selected.")]
        //[Display(Name = "Country Name")]
        public string AddressType
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.AddressType : string.Empty;
            }
            set
            {
                EmployeeContactDetailsDTO.AddressType = value;
            }
        }
        [Display(Name = "DisplayName_EmployeeAddress1", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeAddress1Required")]
        //  [Required(ErrorMessage = "Employee Address1 should not be blank.")]
        //[Display(Name = "Country Name")]
        public string EmployeeAddress1
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.EmployeeAddress1 : string.Empty;
            }
            set
            {
                EmployeeContactDetailsDTO.EmployeeAddress1 = value;
            }
        }

        [Display(Name = "DisplayName_EmployeeAddress2", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeNameRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string EmployeeAddress2
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.EmployeeAddress2 : string.Empty;
            }
            set
            {
                EmployeeContactDetailsDTO.EmployeeAddress2 = value;
            }
        }

        [Display(Name = "DisplayName_PlotNumber", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeNameRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string PlotNumber
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.PlotNumber : string.Empty;
            }
            set
            {
                EmployeeContactDetailsDTO.PlotNumber = value;
            }
        }

        [Display(Name = "DisplayName_StreetName", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeNameRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string StreetName
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.StreetName : string.Empty;
            }
            set
            {
                EmployeeContactDetailsDTO.StreetName = value;
            }
        }

        [Display(Name = "DisplayName_CountryID", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_CountryIDRequired")]
        public int CountryID
        {
            get
            {
                return (EmployeeContactDetailsDTO != null && EmployeeContactDetailsDTO.CountryID > 0) ? EmployeeContactDetailsDTO.CountryID : new int();
            }
            set
            {
                EmployeeContactDetailsDTO.CountryID = value;
            }
        }

        [Display(Name = "DisplayName_RegionID", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_RegionIDRequired")]
        public int RegionID
        {
            get
            {
                return (EmployeeContactDetailsDTO != null && EmployeeContactDetailsDTO.RegionID > 0) ? EmployeeContactDetailsDTO.RegionID : new int();
            }
            set
            {
                EmployeeContactDetailsDTO.RegionID = value;
            }
        }

        [Display(Name = "DisplayName_CityID", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_CityIDRequired")]
        public int CityID
        {
            get
            {
                return (EmployeeContactDetailsDTO != null && EmployeeContactDetailsDTO.CityID > 0) ? EmployeeContactDetailsDTO.CityID : new int();
            }
            set
            {
                EmployeeContactDetailsDTO.CityID = value;
            }
        }

        [Display(Name = "DisplayName_LocationID", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessage = "Location must be selected.")]
        public int ContactLocationID
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.ContactLocationID : new int();
            }
            set
            {
                EmployeeContactDetailsDTO.ContactLocationID = value;
            }
        }

        [Display(Name = "DisplayName_Pincode", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PincodeRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string Pincode
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.Pincode : string.Empty;
            }
            set
            {
                EmployeeContactDetailsDTO.Pincode = value;
            }
        }

        [Display(Name = "DisplayName_TelephoneNumber", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PincodeRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string TelephoneNumber
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.TelephoneNumber : string.Empty;
            }
            set
            {
                EmployeeContactDetailsDTO.TelephoneNumber = value;
            }
        }

        [Display(Name = "DisplayName_MobileNumber", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PincodeRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string MobileNumber
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.MobileNumber : string.Empty;
            }
            set
            {
                EmployeeContactDetailsDTO.MobileNumber = value;
            }
        }

         [Display(Name = "DisplayName_CurrentAddressFlag", ResourceType = typeof(AMS.Common.Resources))]
        public bool CurrentAddressFlag
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.CurrentAddressFlag : false;
            }
            set
            {
                EmployeeContactDetailsDTO.CurrentAddressFlag = value;
            }
        }

        [Display(Name = "DisplayName_CountryName", ResourceType = typeof(AMS.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CountryNameRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string CountryName
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.CountryName : string.Empty;
            }
            set
            {
                EmployeeContactDetailsDTO.CountryName = value;
            }
        }

        [Display(Name = "DisplayName_RegionName", ResourceType = typeof(AMS.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CityNameRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "City Name")]
        public string RegionName
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.RegionName : string.Empty;
            }
            set
            {
                EmployeeContactDetailsDTO.RegionName = value;
            }
        }

        [Display(Name = "DisplayName_CityName", ResourceType = typeof(AMS.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CityNameRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "City Name")]
        public string CityName
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.CityName : string.Empty;
            }
            set
            {
                EmployeeContactDetailsDTO.CityName = value;
            }
        }

        [Display(Name = "DisplayName_Location", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LocationRequired")]
        //[Required(ErrorMessage = "Location must be selected.")]
        //[Display(Name = "City Name")]
        public string Location
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.Location : string.Empty;
            }
            set
            {
                EmployeeContactDetailsDTO.Location = value;
            }
        }


        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.IsDeleted : false;
            }
            set
            {
                EmployeeContactDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EmployeeContactDetailsDTO != null && EmployeeContactDetailsDTO.CreatedBy > 0) ? EmployeeContactDetailsDTO.CreatedBy : new int();
            }
            set
            {
                EmployeeContactDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeeContactDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (EmployeeContactDetailsDTO != null && EmployeeContactDetailsDTO.ModifiedBy.HasValue) ? EmployeeContactDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeeContactDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeeContactDetailsDTO != null && EmployeeContactDetailsDTO.ModifiedDate.HasValue) ? EmployeeContactDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeeContactDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (EmployeeContactDetailsDTO != null && EmployeeContactDetailsDTO.DeletedBy.HasValue) ? EmployeeContactDetailsDTO.DeletedBy : new int();
            }
            set
            {
                EmployeeContactDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeeContactDetailsDTO != null && EmployeeContactDetailsDTO.DeletedDate.HasValue) ? EmployeeContactDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeeContactDetailsDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }
    }
}
