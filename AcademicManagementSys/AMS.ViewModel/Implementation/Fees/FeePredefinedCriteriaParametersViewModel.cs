using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class FeePredefinedCriteriaParametersViewModel : IFeePredefinedCriteriaParametersViewModel
    {

        public FeePredefinedCriteriaParametersViewModel()
        {
            FeePredefinedCriteriaParametersDTO = new FeePredefinedCriteriaParameters();
        }

        public FeePredefinedCriteriaParameters FeePredefinedCriteriaParametersDTO
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> TableEntityNameListItems { get { return new SelectList(TableEntityNameList, "TableName", "TableName"); } }
        public List<FeePredefinedCriteriaParameters> TableEntityNameList
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (FeePredefinedCriteriaParametersDTO != null && FeePredefinedCriteriaParametersDTO.ID > 0) ? FeePredefinedCriteriaParametersDTO.ID : new int();
            }
            set
            {
                FeePredefinedCriteriaParametersDTO.ID = value;
            }
        }

        [Required(ErrorMessage = "Fee Criteria Parameters Description should not be blank.")]
        [Display(Name = "Fee Criteria Parameters Description")]
        public string FeeCriteriaParametersDescription
        {
            get
            {
                return (FeePredefinedCriteriaParametersDTO != null) ? FeePredefinedCriteriaParametersDTO.FeeCriteriaParametersDescription : string.Empty;
            }
            set
            {
                FeePredefinedCriteriaParametersDTO.FeeCriteriaParametersDescription = value;
            }
        }

        [Required(ErrorMessage = "Fee Criteria Parameters Code should not be blank.")]
        [Display(Name = "Fee Criteria Parameters Code")]
        public string FeeCriteriaParametersCode
        {
            get
            {
                return (FeePredefinedCriteriaParametersDTO != null) ? FeePredefinedCriteriaParametersDTO.FeeCriteriaParametersCode : string.Empty;
            }
            set
            {
                FeePredefinedCriteriaParametersDTO.FeeCriteriaParametersCode = value;
            }
        }
        [Required(ErrorMessage = "Table Entity Name should not be blank.")]
        [Display(Name = "Table Entity Name")]
        public string TableEntityName
        {
            get
            {
                return (FeePredefinedCriteriaParametersDTO != null) ? FeePredefinedCriteriaParametersDTO.TableEntityName : string.Empty;
            }
            set
            {
                FeePredefinedCriteriaParametersDTO.TableEntityName = value;
            }
        }
        [Required(ErrorMessage = "Primary Key Field Name should not be blank.")]
        [Display(Name = "Primary Key Field Name")]
        public string PrimaryKeyFieldName
        {
            get
            {
                return (FeePredefinedCriteriaParametersDTO != null) ? FeePredefinedCriteriaParametersDTO.PrimaryKeyFieldName : string.Empty;
            }
            set
            {
                FeePredefinedCriteriaParametersDTO.PrimaryKeyFieldName = value;
            }
        }

        [Required(ErrorMessage = "Display Key Field Name should not be blank.")]
        [Display(Name = "Display Key Field Name")]
        public string DisplayKeyFieldName
        {
            get
            {
                return (FeePredefinedCriteriaParametersDTO != null) ? FeePredefinedCriteriaParametersDTO.DisplayKeyFieldName : string.Empty;
            }
            set
            {
                FeePredefinedCriteriaParametersDTO.DisplayKeyFieldName = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (FeePredefinedCriteriaParametersDTO != null) ? FeePredefinedCriteriaParametersDTO.IsDeleted : false;
            }
            set
            {
                FeePredefinedCriteriaParametersDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (FeePredefinedCriteriaParametersDTO != null && FeePredefinedCriteriaParametersDTO.CreatedBy > 0) ? FeePredefinedCriteriaParametersDTO.CreatedBy : new int();
            }
            set
            {
                FeePredefinedCriteriaParametersDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (FeePredefinedCriteriaParametersDTO != null) ? FeePredefinedCriteriaParametersDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                FeePredefinedCriteriaParametersDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (FeePredefinedCriteriaParametersDTO != null) ? FeePredefinedCriteriaParametersDTO.ModifiedBy : new int();
            }
            set
            {
                FeePredefinedCriteriaParametersDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (FeePredefinedCriteriaParametersDTO != null) ? FeePredefinedCriteriaParametersDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                FeePredefinedCriteriaParametersDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (FeePredefinedCriteriaParametersDTO != null) ? FeePredefinedCriteriaParametersDTO.DeletedBy : new int();
            }
            set
            {
                FeePredefinedCriteriaParametersDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (FeePredefinedCriteriaParametersDTO != null) ? FeePredefinedCriteriaParametersDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                FeePredefinedCriteriaParametersDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
    }
}

