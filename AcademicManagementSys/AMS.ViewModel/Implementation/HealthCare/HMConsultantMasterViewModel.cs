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
    public class  HMConsultantMasterViewModel : IHMConsultantMasterViewModel
    {

        public HMConsultantMasterViewModel()
        {
            HMConsultantMasterDTO = new HMConsultantMaster();
        
            ListOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            ListOrganisationDepartmentMaster = new List<OrganisationDepartmentMaster>();
            //ListEmpDesignationMaster = new List<EmpDesignationMaster>();
            //RoleList = new List<HMConsultantMaster>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
           


        }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
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
       
       
        public HMConsultantMaster HMConsultantMasterDTO
        {
            get;
            set;
        }

        public Int32 ID
        {
            get
            {
                return (HMConsultantMasterDTO != null) ? HMConsultantMasterDTO.ID : new Int16();
            }
            set
            {
                HMConsultantMasterDTO.ID = value;
            }
        }
        public Int16 ConsultantTypeMasterID
        {
            get
            {
                return (HMConsultantMasterDTO != null) ? HMConsultantMasterDTO.ConsultantTypeMasterID : new Int16();
            }
            set
            {
                HMConsultantMasterDTO.ConsultantTypeMasterID= value;
            }
        }
       
    public string EntityLevel
        {
            get;
            set;
        }
    public Int32 EmployeeID
    {
        get { return (HMConsultantMasterDTO != null && HMConsultantMasterDTO.EmployeeID > 0) ? HMConsultantMasterDTO.EmployeeID : new Int32(); }
        set { HMConsultantMasterDTO.EmployeeID = value; }
    }
    [Display(Name = "Employee Name")]
    public String EmployeeName
    {
        get { return (HMConsultantMasterDTO != null && HMConsultantMasterDTO.EmployeeName != null) ? HMConsultantMasterDTO.EmployeeName : String.Empty; }
        set { HMConsultantMasterDTO.EmployeeName = value; }
    }
     [Display(Name = "DisplayName_CentreCode", ResourceType = typeof(AMS.Common.Resources))]
    [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreCodeRequired")]
    public string CentreCode
    {
        get
        {
            return (HMConsultantMasterDTO != null) ? HMConsultantMasterDTO.CentreCode : string.Empty;
        }
        set
        {
            HMConsultantMasterDTO.CentreCode = value;
        }
    }
    // [Display(Name = "DisplayName_CentreCode", ResourceType = typeof(AMS.Common.Resources))]
    // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreCodeRequired")]
     public string Name
     {
         get
         {
             return (HMConsultantMasterDTO != null) ? HMConsultantMasterDTO.Name : string.Empty;
         }
         set
         {
             HMConsultantMasterDTO.Name = value;
         }
     }
    [Display(Name = "DisplayName_CentreName", ResourceType = typeof(AMS.Common.Resources))]
    //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreNameRequired")]
    public string CentreName
    {
        get
        {
            return (HMConsultantMasterDTO != null) ? HMConsultantMasterDTO.CentreName : string.Empty;
        }
        set
        {
            HMConsultantMasterDTO.CentreName = value;
        }
    }
        [Display(Name = "Admin Role Master ID")]
        public int AdminRoleMasterID
        {
            get
            {
                return (HMConsultantMasterDTO != null && HMConsultantMasterDTO.AdminRoleMasterID > 0) ? HMConsultantMasterDTO.AdminRoleMasterID : new int();
            }
            set
            {
                HMConsultantMasterDTO.AdminRoleMasterID = value;
            }
        }


       
      
        public String DepartmentName
        {
            get;
            set;
        }
        public string SelectedCentreCode
        {
            get;
            set;
        }
        public string ConsultantType
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
        //public IEnumerable<SelectListItem> ListOrganisationStudyCentreMasterItems
        //{
        //    get
        //    {
        //        return new SelectList(ListOrganisationStudyCentreMaster, "CentreCode", "CentreName");
        //    }
        //}
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }
        public IEnumerable<SelectListItem> ListOrganisationDepartmentMasterItems
        {
            get
            {

                return new SelectList(ListOrganisationDepartmentMaster, "DepID", "DepartmentName");
            }

        }
        //public IEnumerable<SelectListItem> OrganisationDepartmentMasterList
        //{
        //    get
        //    {

        //        return new SelectList(ListOrganisationDepartmentMaster, "DepartmentID", "DepartmentName");
        //    }

        //}
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
                return (HMConsultantMasterDTO != null) ? HMConsultantMasterDTO.IsDeleted : false;
            }
            set
            {
                HMConsultantMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (HMConsultantMasterDTO != null && HMConsultantMasterDTO.CreatedBy > 0) ? HMConsultantMasterDTO.CreatedBy : new int();
            }
            set
            {
                HMConsultantMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (HMConsultantMasterDTO != null) ? HMConsultantMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                HMConsultantMasterDTO.CreatedDate = value;
            }
        }


        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (HMConsultantMasterDTO != null) ? HMConsultantMasterDTO.ModifiedBy : new int();
            }
            set
            {
                HMConsultantMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (HMConsultantMasterDTO != null) ? HMConsultantMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                HMConsultantMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (HMConsultantMasterDTO != null) ? HMConsultantMasterDTO.DeletedBy : new int();
            }
            set
            {
                HMConsultantMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (HMConsultantMasterDTO != null) ? HMConsultantMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                HMConsultantMasterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
    }
}

