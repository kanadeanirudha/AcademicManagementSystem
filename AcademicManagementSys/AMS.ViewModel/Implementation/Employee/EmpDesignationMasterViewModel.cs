using AMS.Common;
using AMS.DTO;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace AMS.ViewModel
{
    public class EmpDesignationMasterViewModel : IEmpDesignationMasterViewModel
    {
        public EmpDesignationMasterViewModel()
        {
            EmpDesignationMasterDTO = new EmpDesignationMaster();
            //EmpdesigTypeMasterList = new List<EmpDesignationMaster>();
        }

        public EmpDesignationMaster EmpDesignationMasterDTO
        {
            get;
            set;
        }
        // public List<EmpDesignationMaster> EmpdesigTypeMasterList { get; set; }

        //public IEnumerable<SelectListItem> EmpdesigtypeListItems 
        //{
        //    get
        //    {
        //        return new SelectList(EmpdesigTypeMasterList, "CurrencyCode", "CurrencyName");
        //    }
        //}



        //-------------------------------------------------------------------------------------------------------
        public int ID
        {
            get
            {
                return (EmpDesignationMasterDTO != null && EmpDesignationMasterDTO.ID > 0) ? EmpDesignationMasterDTO.ID : new int();
            }
            set
            {
                EmpDesignationMasterDTO.ID = value;
            }
        }
        //[Required(ErrorMessage = "Description should not be blank.")]
        //[Display(Name = "Description :")]
        [Display(Name = "DisplayName_Description", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DescriptionRequired")]
        public string Description
        {
            get
            {
                return (EmpDesignationMasterDTO != null) ? EmpDesignationMasterDTO.Description : string.Empty;
            }
            set
            {
                EmpDesignationMasterDTO.Description = value;
            }
        }

        //[Required(ErrorMessage = "Designation Level should not be blank.")]
        //[Display(Name = "Designation Level :")]
        [Display(Name = "DisplayName_DesignationLevel", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DesignationLevelRequired")]
        public int DesignationLevel
        {
            get
            {
                return (EmpDesignationMasterDTO != null && EmpDesignationMasterDTO.DesignationLevel > 0) ? EmpDesignationMasterDTO.DesignationLevel : new int();
            }
            set
            {
                EmpDesignationMasterDTO.DesignationLevel = value;
            }
        }

        //[Required(ErrorMessage = "Grade should not be blank.")]
        //[Display(Name = "Grade :")]
        [Display(Name = "DisplayName_Grade", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_GradeRequired")]
        public int Grade
        {
            get
            {
                return (EmpDesignationMasterDTO != null && EmpDesignationMasterDTO.Grade > 0) ? EmpDesignationMasterDTO.Grade : new int();
            }
            set
            {
                EmpDesignationMasterDTO.Grade = value;
            }
        }
        //[Required(ErrorMessage = "Short Code should not be blank.")]
        //[Display(Name = "Short Code :")]
        [Display(Name = "DisplayName_ShortCode", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ShortCodeRequired")]
        public string ShortCode
        {
            get
            {
                return (EmpDesignationMasterDTO != null) ? EmpDesignationMasterDTO.ShortCode : string.Empty;
            }
            set
            {
                EmpDesignationMasterDTO.ShortCode = value;
            }
        }

        //[Required(ErrorMessage = "College ID should not be blank.")]
        //[Display(Name = "College ID : ")]
        [Display(Name = "DisplayName_CollegeID", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CollegeIDRequired")]
        public int CollegeID
        {
            get
            {
                return (EmpDesignationMasterDTO != null && EmpDesignationMasterDTO.CollegeID > 0) ? EmpDesignationMasterDTO.CollegeID : new int();
            }
            set
            {
                EmpDesignationMasterDTO.CollegeID = value;
            }
        }

        //[Required(ErrorMessage = "EmpDesignation Type should not be blank.")]
        //[Display(Name = "Designation Type :")]
        [Display(Name = "DisplayName_EmpDesigType", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmpDesigTypeRequired")]
        public string EmpDesigType
        {
            get
            {
                return (EmpDesignationMasterDTO != null) ? EmpDesignationMasterDTO.EmpDesigType : string.Empty;
            }
            set
            {
                EmpDesignationMasterDTO.EmpDesigType = value;
            }
        }
        //[Required(ErrorMessage = "Related With should not be blank.")]
        //[Display(Name = "Related With :")]
        [Display(Name = "DisplayName_RelatedWith", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_RelatedWithRequired")]
        public string RelatedWith
        {
            get
            {
                return (EmpDesignationMasterDTO != null) ? EmpDesignationMasterDTO.RelatedWith : string.Empty;
            }
            set
            {
                EmpDesignationMasterDTO.RelatedWith = value;
            }
        }


        //[Display(Name = "Is Active :")]
        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (EmpDesignationMasterDTO != null) ? EmpDesignationMasterDTO.IsActive : false;
            }
            set
            {
                EmpDesignationMasterDTO.IsActive = value;
            }
        }
        //[Display(Name = "IsDeleted")]
        [Display(Name = "DisplayName_IsDeleted", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsDeleted
        {
            get
            {
                return (EmpDesignationMasterDTO != null) ? EmpDesignationMasterDTO.IsDeleted : false;
            }
            set
            {
                EmpDesignationMasterDTO.IsDeleted = value;
            }
        }

        //[Display(Name = "CreatedBy")]
        [Display(Name = "DisplayName_CreatedBy", ResourceType = typeof(AMS.Common.Resources))]
        public int CreatedBy
        {
            get
            {
                return (EmpDesignationMasterDTO != null && EmpDesignationMasterDTO.CreatedBy > 0) ? EmpDesignationMasterDTO.CreatedBy : new int();
            }
            set
            {
                EmpDesignationMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmpDesignationMasterDTO != null) ? EmpDesignationMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmpDesignationMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (EmpDesignationMasterDTO != null) ? EmpDesignationMasterDTO.ModifiedBy : new int();
            }
            set
            {
                EmpDesignationMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (EmpDesignationMasterDTO != null) ? EmpDesignationMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmpDesignationMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (EmpDesignationMasterDTO != null) ? EmpDesignationMasterDTO.DeletedBy : new int();
            }
            set
            {
                EmpDesignationMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (EmpDesignationMasterDTO != null) ? EmpDesignationMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmpDesignationMasterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
    }
}

