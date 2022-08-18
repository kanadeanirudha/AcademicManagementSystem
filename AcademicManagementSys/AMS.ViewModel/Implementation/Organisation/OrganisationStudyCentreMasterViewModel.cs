using System;
using AMS.Common;
using AMS.DTO;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AMS.ViewModel
{

    public class OrganisationStudyCentreMasterBaseViewModel : IOrganisationStudyCentreMasterBaseViewModel
    {
        public OrganisationStudyCentreMasterBaseViewModel()
        {
            ListOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();

            ListGeneralCityMaster = new List<GeneralCityMaster>();

            ListOrganisationMaster = new List<OrganisationMaster>();

            ListOrganisationUniversityMaster = new List<OrganisationUniversityMaster>();
        }

        public List<OrganisationStudyCentreMaster> ListOrganisationStudyCentreMaster
        {
            get;
            set;
        }

        public List<GeneralCityMaster> ListGeneralCityMaster
        {
            get;
            set;
        }

        public List<OrganisationMaster> ListOrganisationMaster
        {
            get;
            set;
        }

        public List<OrganisationUniversityMaster> ListOrganisationUniversityMaster
        {
            get;
            set;
        }

        public string SelectedCityID
        {
            get;
            set;
        }

        public string SelectedOrganisationID
        {
            get;
            set;
        }

        public string SelectedUniversityID
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListGeneralCityMasterItems
        {
            get
            {
                return new SelectList(ListGeneralCityMaster, "ID", "Description");
            }
        }

        public IEnumerable<SelectListItem> ListOrganisationMasterItems
        {
            get
            {
                return new SelectList(ListOrganisationMaster, "ID", "OrgName");
            }
        }
    }

    public class OrganisationStudyCentreMasterViewModel : IOrganisationStudyCentreMasterViewModel
    {
        public OrganisationStudyCentreMasterViewModel()
        {
            OrganisationStudyCentreMasterDTO = new OrganisationStudyCentreMaster();
            OrganisationUniversityMasterDTO = new OrganisationUniversityMaster();
        }
        public OrganisationStudyCentreMaster OrganisationStudyCentreMasterDTO { get; set; }

        public OrganisationUniversityMaster OrganisationUniversityMasterDTO { get; set; }

        public int ID
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null && OrganisationStudyCentreMasterDTO.ID > 0) ? OrganisationStudyCentreMasterDTO.ID : new int();
            }
            set
            {
                OrganisationStudyCentreMasterDTO.ID = value;
            }
        }

        //[Required(ErrorMessage = "Centre Code should not be blank")]
       // [Display(Name = "Centre Code :")]
        [Display(Name = "DisplayName_CentreCode", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreCodeRequired")]
        public string CentreCode
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.CentreCode = value;
            }
        }
        [Display(Name = "DisplayName_CentreName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreNameRequired")]
        //[Required(ErrorMessage = "Centre Name should not be blank")]
      //  [Display(Name = "Centre Name :")]
        public string CentreName
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.CentreName : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.CentreName = value;
            }
        }
        //[Required(ErrorMessage = "Office Type must be selected")]
        //[Display(Name = "Office Type :")]
        [Display(Name = "DisplayName_OfficeType", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_OfficeTypeRequired")]

        public string HoCoRoScFlag
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.HoCoRoScFlag : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.HoCoRoScFlag = value;
            }
        }

        [Display(Name = "HoID")]
        public Nullable<int> HoID
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null && OrganisationStudyCentreMasterDTO.HoID > 0) ? OrganisationStudyCentreMasterDTO.HoID : new int();
            }
            set
            {
                OrganisationStudyCentreMasterDTO.HoID = value;
            }
        }


        [Display(Name = "CoID")]
        public Nullable<int> CoID
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null && OrganisationStudyCentreMasterDTO.CoID > 0) ? OrganisationStudyCentreMasterDTO.CoID : new int();
            }
            set
            {
                OrganisationStudyCentreMasterDTO.CoID = value;
            }
        }
        //[Required(ErrorMessage = "Office Belong must be selected")]
        //[Display(Name = "Office Belong To :")]
        [Display(Name = "DisplayName_OfficeBelongTo", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_OfficeBelongRequired")]
        public Nullable<int> RoID
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.RoID : new int();
            }
            set
            {
                OrganisationStudyCentreMasterDTO.RoID = value;
            }
        }


        //[Required(ErrorMessage = "Specialization should not be blank")]
        //[Display(Name = "Centre Specialization :")]
        [Display(Name = "DisplayName_CentreSpecialization", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreSpecializationRequired")]
        public string CentreSpecialization
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.CentreSpecialization : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.CentreSpecialization = value;
            }
        }
        //[Required(ErrorMessage = "Address should not be blank")]
        //[Display(Name = "Address :")]
        [Display(Name = "DisplayName_Address", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_Address1Required")]
        public string CentreAddress
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.CentreAddress : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.CentreAddress = value;
            }
        }

        [Display(Name = "DisplayName_PlotNo", ResourceType = typeof(AMS.Common.Resources))]
       // [Display(Name = "Plot No :")]
        public string PlotNo
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.PlotNo : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.PlotNo = value;
            }
        }
        [Display(Name = "DisplayName_StreetName", ResourceType = typeof(AMS.Common.Resources))]
        //[Display(Name = "Street Name :")]
        public string StreetName
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.StreetName : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.StreetName = value;
            }
        }

        [Display(Name = "DisplayName_CityID", ResourceType = typeof(AMS.Common.Resources))]
       // [Display(Name = "City :")]
        public Nullable<int> CityID
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null && OrganisationStudyCentreMasterDTO.CityID > 0) ? OrganisationStudyCentreMasterDTO.CityID : new int();
            }
            set
            {
                OrganisationStudyCentreMasterDTO.CityID = value;
            }
        }
        //[Required(ErrorMessage = "Pincode should not be blank")]
        //[Display(Name = "Pincode :")]
        [Display(Name = "DisplayName_Pincode", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PincodeRequired")]
        public string Pincode
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.Pincode : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.Pincode = value;
            }
        }
        //[Required(ErrorMessage = "Email ID should not be blank.")]
        [DataType(DataType.EmailAddress)]
        //[Display(Name = "E-MailID :")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})$", ErrorMessage = "Please enter a valid email id.")]
        [Display(Name = "DisplayName_EmailId", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmailIDRequired")]
        public string EmailID
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.EmailID : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.EmailID = value;
            }
        }

        //[Required(ErrorMessage = "Url should not be blank")]
        //[Display(Name = "Url :")]
        [Display(Name = "DisplayName_UrlOnly", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_UrlOnlyRequired")]
        public string Url
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.Url : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.Url = value;
            }
        }
         [Display(Name = "DisplayName_MobileNumber", ResourceType = typeof(AMS.Common.Resources))]
       // [Display(Name = "Mobile No. :")]
        public string CellPhone
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.CellPhone : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.CellPhone = value;
            }
        }

        //[Display(Name = "Fax Number :")]
        [Display(Name = "DisplayName_FaxNumber", ResourceType = typeof(AMS.Common.Resources))]
        public string FaxNumber
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.FaxNumber : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.FaxNumber = value;
            }
        }
        //[Required(ErrorMessage = "Please enter a valid phone number.")]
        //[Display(Name = "Office Phone Number :")]
        [Display(Name = "DisplayName_PhoneNumberOffice", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PhoneNumberOfficeRequired")]
        public string PhoneNumberOffice
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.PhoneNumberOffice : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.PhoneNumberOffice = value;
            }
        }

        //[Required(ErrorMessage = "Establishment Date should not be blank")]
        //[Display(Name = "Establishment Date :")]
        [Display(Name = "DisplayName_CentreEstablishmentDatetime", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreEstablishmentDatetimeRequired")]
        public string CentreEstablishmentDatetime
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.CentreEstablishmentDatetime : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.CentreEstablishmentDatetime = value;
            }
        }


       // [Display(Name = "OrganisationID")]
        [Display(Name = "DisplayName_OrganisationID", ResourceType = typeof(AMS.Common.Resources))]
        public Nullable<int> OrganisationID
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null && OrganisationStudyCentreMasterDTO.OrganisationID > 0) ? OrganisationStudyCentreMasterDTO.OrganisationID : new int();
            }
            set
            {
                OrganisationStudyCentreMasterDTO.OrganisationID = value;
            }
        }
        //[Required(ErrorMessage = "University must be selected")]
        //[Display(Name = "University Name :")]

        [Display(Name = "DisplayName_UniversityName", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SelectedUniversityID")]
        public Nullable<int> UniversityID
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null && OrganisationStudyCentreMasterDTO.UniversityID > 0) ? OrganisationStudyCentreMasterDTO.UniversityID : new int();
            }
            set
            {
                OrganisationStudyCentreMasterDTO.UniversityID = value;
            }
        }

     //   [Display(Name = "Centre Login Number :")]
        [Display(Name = "DisplayName_CentreLoginNumber", ResourceType = typeof(AMS.Common.Resources))]
        public Nullable<int> CentreLoginNumber
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null && OrganisationStudyCentreMasterDTO.CentreLoginNumber > 0) ? OrganisationStudyCentreMasterDTO.CentreLoginNumber : new int();
            }
            set
            {
                OrganisationStudyCentreMasterDTO.CentreLoginNumber = value;
            }
        }

        //[Required(ErrorMessage = "Institute Code should not be blank")]
        //[Display(Name = "Institute Code :")]
        [Display(Name = "DisplayName_InstituteCode", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_InstituteCodeRequired")]
        public string InstituteCode
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.InstituteCode : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.InstituteCode = value;
            }
        }

        //[Required(ErrorMessage = "TimeZone should not be blank")]
        //[Display(Name = "TimeZone :")]
        [Display(Name = "DisplayName_TimeZone", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_TimezoneRequired")]
        public string TimeZone
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.TimeZone : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.TimeZone = value;
            }
        }
        //[Required(ErrorMessage = "Latitude should not be blank")]
        //[Display(Name = " Latitude :")]
        [Display(Name = "DisplayName_Latitude", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LatitudeRequired")]
        
        public decimal Latitude
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null && OrganisationStudyCentreMasterDTO.Latitude > 0) ? OrganisationStudyCentreMasterDTO.Latitude : new decimal();
            }
            set
            {
                OrganisationStudyCentreMasterDTO.Latitude = value;
            }
        }
        //[Required(ErrorMessage = "Longitude should not be blank")]
        //[Display(Name = " Longitude  :")]
        [Display(Name = "DisplayName_Longitude", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LongitudeRequired")]
        public decimal Longitude 
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null && OrganisationStudyCentreMasterDTO.Longitude > 0) ? OrganisationStudyCentreMasterDTO.Longitude : new decimal();
            }
            set
            {
                OrganisationStudyCentreMasterDTO.Longitude = value;
            }
        }
        //[Required(ErrorMessage = "Campus Area should not be blank")]
        //[Display(Name = " Campus Area :")]
        [Display(Name = "DisplayName_CampusArea", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CampusAreaRequired")]
        public decimal CampusArea 
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null && OrganisationStudyCentreMasterDTO.CampusArea > 0) ? OrganisationStudyCentreMasterDTO.CampusArea : new decimal();
            }
            set
            {
                OrganisationStudyCentreMasterDTO.CampusArea = value;
            }
        }
       // [Display(Name = "User Type :")]
        [Display(Name = "DisplayName_UserType", ResourceType = typeof(AMS.Common.Resources))]
        public string UserType
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.UserType : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.UserType = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.IsDeleted : false;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public Nullable<int> CreatedBy
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null && OrganisationStudyCentreMasterDTO.CreatedBy > 0) ? OrganisationStudyCentreMasterDTO.CreatedBy : new int();
            }
            set
            {
                OrganisationStudyCentreMasterDTO.CreatedBy = value;
            }
        }


        [Display(Name = "CreatedDate")]
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.CreatedDate = value;
            }
        }


        [Display(Name = "ModifiedBy")]
        public Nullable<int> ModifiedBy
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null && OrganisationStudyCentreMasterDTO.ModifiedBy > 0) ? OrganisationStudyCentreMasterDTO.ModifiedBy : new int();
            }
            set
            {
                OrganisationStudyCentreMasterDTO.ModifiedBy = value;
            }
        }


        [Display(Name = "ModifiedDate")]
        public Nullable<DateTime> ModifiedDate
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.ModifiedDate = value;
            }
        }


        [Display(Name = "DeletedBy")]
        public Nullable<int> DeletedBy
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null && OrganisationStudyCentreMasterDTO.DeletedBy > 0) ? OrganisationStudyCentreMasterDTO.DeletedBy : new int();
            }
            set
            {
                OrganisationStudyCentreMasterDTO.DeletedBy = value;
            }
        }


        [Display(Name = "DeletedDate")]
        public Nullable<DateTime> DeletedDate
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.DeletedDate = value;
            }
        }
        public string IDs
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.IDs : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.IDs = value;
            }
        }
        //[Required(ErrorMessage = "City must be selected")]
        //[Display(Name = "City :")]
        [Display(Name = "DisplayName_CityID", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CityIDRequired")]
        public string SelectedCityID
        {
            get;
            set;
        }
        //[Required(ErrorMessage = "Organisation must be selected")]
        //[Display(Name = "Organisation Name :")]
        [Display(Name = "DisplayName_PreviousOrganisationName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_OrganisationRequired")]
        public string SelectedOrganisationID
        {
            get;
            set;
        }

        public string SelectedUniversityID
        {
            get;
            set;
        }
        public List<OrganisationUniversityMaster> OrganisationUniversityMasterList
        {
            get;
            set;
        }
        //public IEnumerable<SelectListItem> OrganisationUniversityMasterListItems
        //{
        //    get
        //    {
        //        return new SelectList(OrganisationUniversityMasterList, "ID", "Description");
        //    }
        //}


    }
}
