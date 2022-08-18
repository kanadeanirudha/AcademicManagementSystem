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
    public class HMConsultantTypeMasterViewModel : IHMConsultantTypeMasterViewModel
    {

        public HMConsultantTypeMasterViewModel()
        {
            HMConsultantTypeMasterDTO = new HMConsultantTypeMaster();
        
            ListOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            ListOrganisationDepartmentMaster = new List<OrganisationDepartmentMaster>();
            //ListEmpDesignationMaster = new List<EmpDesignationMaster>();
            //RoleList = new List<HMConsultantTypeMaster>();
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
       
       
        public HMConsultantTypeMaster HMConsultantTypeMasterDTO
        {
            get;
            set;
        }

        public Int16  ID
        {
            get
            {
                return (HMConsultantTypeMasterDTO != null) ? HMConsultantTypeMasterDTO.ID : new Int16();
            }
            set
            {
                HMConsultantTypeMasterDTO.ID = value;
            }
        }
       
    public string EntityLevel
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Name should not be blank.")]
        [Display(Name = "Name")]
        public string Name
        {
            get
            {
                return (HMConsultantTypeMasterDTO != null) ? HMConsultantTypeMasterDTO.Name : string.Empty;
            }
            set
            {
                HMConsultantTypeMasterDTO.Name = value;
            }
        }
        [Display(Name = "Admin Role Master ID")]
        public int AdminRoleMasterID
        {
            get
            {
                return (HMConsultantTypeMasterDTO != null && HMConsultantTypeMasterDTO.AdminRoleMasterID > 0) ? HMConsultantTypeMasterDTO.AdminRoleMasterID : new int();
            }
            set
            {
                HMConsultantTypeMasterDTO.AdminRoleMasterID = value;
            }
        }
       
     
        public Int32 DepartmentID
        {
            get;
            set;
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
                return (HMConsultantTypeMasterDTO != null) ? HMConsultantTypeMasterDTO.IsDeleted : false;
            }
            set
            {
                HMConsultantTypeMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (HMConsultantTypeMasterDTO != null && HMConsultantTypeMasterDTO.CreatedBy > 0) ? HMConsultantTypeMasterDTO.CreatedBy : new int();
            }
            set
            {
                HMConsultantTypeMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (HMConsultantTypeMasterDTO != null) ? HMConsultantTypeMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                HMConsultantTypeMasterDTO.CreatedDate = value;
            }
        }


        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (HMConsultantTypeMasterDTO != null) ? HMConsultantTypeMasterDTO.ModifiedBy : new int();
            }
            set
            {
                HMConsultantTypeMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (HMConsultantTypeMasterDTO != null) ? HMConsultantTypeMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                HMConsultantTypeMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (HMConsultantTypeMasterDTO != null) ? HMConsultantTypeMasterDTO.DeletedBy : new int();
            }
            set
            {
                HMConsultantTypeMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (HMConsultantTypeMasterDTO != null) ? HMConsultantTypeMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                HMConsultantTypeMasterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
    }
}

