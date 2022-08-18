using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace AMS.ViewModel
{
    public class OrganisationMasterBaseViewModel : IOrganisationMasterBaseViewModel
    {
        public OrganisationMasterBaseViewModel()
        {
            ListOrganisationMaster = new List<OrganisationMaster>();

            ListGeneralLocationMaster = new List<GeneralLocationMaster>();

        }

        public List<OrganisationMaster> ListOrganisationMaster
        {
            get;
            set;
        }

        public List<GeneralLocationMaster> ListGeneralLocationMaster
        {
            get;
            set;
        }

        public string SelectedLocationID
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListGeneralLocationMasterItems
        {
            get
            {
                return new SelectList(ListGeneralLocationMaster, "ID", "LocationAddress");
            }
        }

    }


    public class OrganisationMasterViewModel : IOrganisationMasterViewModel
    {

        public OrganisationMasterViewModel()
        {
            OrganisationMasterDTO = new OrganisationMaster();
        }

        public OrganisationMaster OrganisationMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (OrganisationMasterDTO != null && OrganisationMasterDTO.ID > 0) ? OrganisationMasterDTO.ID : new int();
            }
            set
            {
                OrganisationMasterDTO.ID = value;
            }
        }

        public int LocationID
        {
            get
            {
                return (OrganisationMasterDTO != null && OrganisationMasterDTO.LocationID > 0) ? OrganisationMasterDTO.LocationID : new int();
            }
            set
            {
                OrganisationMasterDTO.LocationID = value;
            }
        }

        [Display(Name = "DisplayName_OrgName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_OrgNameRequired")]
        public string OrgName
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.OrgName : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.OrgName = value;
            }
        }

        [Display(Name = "DisplayName_EstablishmentCode", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EstablishmentCodeRequired")]
        public string EstablishmentCode
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.EstablishmentCode : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.EstablishmentCode = value;
            }
        }

        [Display(Name = "DisplayName_FoundationDatetime", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_FoundationDatetimeRequired")]
        public string FoundationDatetime
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.FoundationDatetime : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.FoundationDatetime = value;
            }
        }

        [Display(Name = "DisplayName_FounderMember", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_FounderMemberRequired")]
        public string FounderMember
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.FounderMember : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.FounderMember = value;
            }
        }
        [Display(Name = "DisplayName_Address1", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_Address1Required")]
        public string Address1
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.Address1 : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.Address1 = value;
            }
        }

       [Display(Name = "DisplayName_Address2", ResourceType = typeof(AMS.Common.Resources))]
        public string Address2
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.Address2 : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.Address2 = value;
            }
        }

        [Display(Name = "DisplayName_PlotNumber", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PlotNumberRequired")]
        public string PlotNumber
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.PlotNumber : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.PlotNumber = value;
            }
        }

        [Display(Name = "DisplayName_StreetNumber", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_StreetNumberRequired")]
        public string StreetNumber
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.StreetNumber : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.StreetNumber = value;
            }
        }

        [Display(Name = "DisplayName_Pincode", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PincodeRequired")]
         public string Pincode
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.Pincode : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.Pincode = value;
            }
        }


        [Display(Name = "DisplayName_FaxNumber", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_FaxNumberRequired")]
        public string FaxNumber
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.FaxNumber : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.FaxNumber = value;
            }
        }



        [Display(Name = "DisplayName_MobileNumber", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MobileNumberRequired")]
        public string MobileNumber
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.MobileNumber : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.MobileNumber = value;
            }
        }


        [Display(Name = "DisplayName_EmailId", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmailIDRequired")]
        public string EmailID
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.EmailID : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.EmailID = value;
            }
        }


        [Display(Name = "DisplayName_Url", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_UrlRequired")]
        public string Url
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.Url : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.Url = value;
            }
        }


         [Display(Name = "DisplayName_OfficeComment", ResourceType = typeof(AMS.Common.Resources))]
        public string OfficeComment
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.OfficeComment : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.OfficeComment = value;
            }
        }


         [Display(Name = "DisplayName_MissionStatement", ResourceType = typeof(AMS.Common.Resources))]
        public string MissionStatement
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.MissionStatement : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.MissionStatement = value;
            }
        }


        [Display(Name = "DisplayName_OfficePhone1", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_OfficePhone1Required")]
        public string OfficePhone1
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.OfficePhone1 : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.OfficePhone1 = value;
            }
        }


      [Display(Name = "DisplayName_OfficePhone2", ResourceType = typeof(AMS.Common.Resources))]
        public string OfficePhone2
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.OfficePhone2 : string.Empty;
            }
            set
            {
                OrganisationMasterDTO.OfficePhone2 = value;
            }
        }

        public int TotalRecordsFound
        {
            get
            {
                return (OrganisationMasterDTO != null && OrganisationMasterDTO.LocationID > 0) ? OrganisationMasterDTO.TotalRecordsFound : new int();
            }
            set
            {
                OrganisationMasterDTO.TotalRecordsFound = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.IsDeleted : false;
            }
            set
            {
                OrganisationMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OrganisationMasterDTO != null && OrganisationMasterDTO.CreatedBy > 0) ? OrganisationMasterDTO.CreatedBy : new int();
            }
            set
            {
                OrganisationMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OrganisationMasterDTO != null) ? OrganisationMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrganisationMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (OrganisationMasterDTO != null && OrganisationMasterDTO.ModifiedBy > 0) ? OrganisationMasterDTO.ModifiedBy : new int();
            }
            set
            {
                OrganisationMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (OrganisationMasterDTO != null && OrganisationMasterDTO.ModifiedDate.HasValue) ? OrganisationMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrganisationMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (OrganisationMasterDTO != null && OrganisationMasterDTO.DeletedBy.HasValue) ? OrganisationMasterDTO.DeletedBy : new int();
            }
            set
            {
                OrganisationMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (OrganisationMasterDTO != null && OrganisationMasterDTO.DeletedDate.HasValue) ? OrganisationMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrganisationMasterDTO.DeletedDate = value;
            }
        }

        [Display(Name = "DisplayName_SelectedLocationID", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SelectedLocationIDRequired")]
        public string SelectedLocationID
        {
            get;
            set;
        }
    }
}
