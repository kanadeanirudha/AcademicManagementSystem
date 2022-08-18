using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class HMOPDHealthCentreViewModel : IHMOPDHealthCentreViewModel
    {

        public HMOPDHealthCentreViewModel()
        {
            HMOPDHealthCentreDTO = new HMOPDHealthCentre();
        
            ListOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            ListOrganisationDepartmentMaster = new List<OrganisationDepartmentMaster>();
            //ListEmpDesignationMaster = new List<EmpDesignationMaster>();
            //RoleList = new List<HMOPDHealthCentre>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();


        }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }

        public List<OrganisationStudyCentreMaster> ListOrganisationStudyCentreMaster
        {
            get;
            set;
        }
        public List<OrganisationDepartmentMaster> ListOrganisationDepartmentMaster
        {
            get;
            set;
        }
        //public List<EmpDesignationMaster> ListEmpDesignationMaster
        //{
        //    get;
        //    set;
        //}

        // public List<HMOPDHealthCentre> RoleList
        //{
        //    get;
        //    set;
        //}
       
        public HMOPDHealthCentre HMOPDHealthCentreDTO
        {
            get;
            set;
        }

        public Int16  ID
        {
            get
            {
                return (HMOPDHealthCentreDTO != null) ? HMOPDHealthCentreDTO.ID : new Int16();
            }
            set
            {
                HMOPDHealthCentreDTO.ID = value;
            }
        }
       
    public string EntityLevel
        {
            get;
            set;
        }

        [Required(ErrorMessage = "OPD Name should not be blank.")]
        [Display(Name = "OPD Name")]
        public string OPDName
        {
            get
            {
                return (HMOPDHealthCentreDTO != null) ? HMOPDHealthCentreDTO.OPDName : string.Empty;
            }
            set
            {
                HMOPDHealthCentreDTO.OPDName = value;
            }
        }
        [Display(Name = "Admin Role Master ID")]
        public int AdminRoleMasterID
        {
            get
            {
                return (HMOPDHealthCentreDTO != null && HMOPDHealthCentreDTO.AdminRoleMasterID > 0) ? HMOPDHealthCentreDTO.AdminRoleMasterID : new int();
            }
            set
            {
                HMOPDHealthCentreDTO.AdminRoleMasterID = value;
            }
        }
       
        public string CentreCode
        {
            get
            {
                return (HMOPDHealthCentreDTO != null) ? HMOPDHealthCentreDTO.CentreCode : string.Empty;
            }
            set
            {
                HMOPDHealthCentreDTO.CentreCode = value;
            }
        }

        [Display(Name = "DisplayName_CentreName", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreNameRequired")]
        public string CentreName
        {
            get
            {
                return (HMOPDHealthCentreDTO != null) ? HMOPDHealthCentreDTO.CentreName : string.Empty;
            }
            set
            {
                HMOPDHealthCentreDTO.CentreName = value;
            }
        }
     

        public string SelectedIDs
        {
            get
            {
                return (HMOPDHealthCentreDTO != null) ? HMOPDHealthCentreDTO.SelectedIDs : string.Empty;
            }
            set
            {
                HMOPDHealthCentreDTO.SelectedIDs = value;
            }
        }

        public Int32 DepartmentID
        {
            get;
            set;
        }

        public string SelectedCentreCode
        {
            get;
            set;
        }

        public string SelectedDepartmentID
        {
            get;
            set;
        }
        public string SelectedCentreName
        {
            get;
            set;
        }

        public string SelectedDepartmentName
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListOrganisationStudyCentreMasterItems
        {
            get
            {
                return new SelectList(ListOrganisationStudyCentreMaster, "CentreCode", "CentreName");
            }
        }

        public IEnumerable<SelectListItem> ListOrganisationDepartmentMasterItems
        {
            get
            {

                return new SelectList(ListOrganisationDepartmentMaster, "DeptID", "DepartmentName");
            }

        }
        //public IEnumerable<SelectListItem> ListEmpDesignationMasterItems
        //{
        //    get
        //    {

        //        return new SelectList(ListEmpDesignationMaster, "DesignationID", "Description");
        //    }

        //}

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (HMOPDHealthCentreDTO != null) ? HMOPDHealthCentreDTO.IsDeleted : false;
            }
            set
            {
                HMOPDHealthCentreDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (HMOPDHealthCentreDTO != null && HMOPDHealthCentreDTO.CreatedBy > 0) ? HMOPDHealthCentreDTO.CreatedBy : new int();
            }
            set
            {
                HMOPDHealthCentreDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (HMOPDHealthCentreDTO != null) ? HMOPDHealthCentreDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                HMOPDHealthCentreDTO.CreatedDate = value;
            }
        }


        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (HMOPDHealthCentreDTO != null) ? HMOPDHealthCentreDTO.ModifiedBy : new int();
            }
            set
            {
                HMOPDHealthCentreDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (HMOPDHealthCentreDTO != null) ? HMOPDHealthCentreDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                HMOPDHealthCentreDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (HMOPDHealthCentreDTO != null) ? HMOPDHealthCentreDTO.DeletedBy : new int();
            }
            set
            {
                HMOPDHealthCentreDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (HMOPDHealthCentreDTO != null) ? HMOPDHealthCentreDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                HMOPDHealthCentreDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
    }
}

