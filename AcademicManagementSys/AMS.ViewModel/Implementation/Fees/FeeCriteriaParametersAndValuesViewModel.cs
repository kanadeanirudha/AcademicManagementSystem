using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class FeeCriteriaParametersAndValuesViewModel : IFeeCriteriaParametersAndValuesViewModel
    {

        public FeeCriteriaParametersAndValuesViewModel()
        {
            FeeCriteriaParametersAndValuesDTO = new FeeCriteriaParametersAndValues();
            PredefinedCriteriaParametersList = new List<FeePredefinedCriteriaParameters>();
            PredefinedCriteriaParametersValueList = new List<FeeCriteriaParametersAndValues>();
        }

        public FeeCriteriaParametersAndValues FeeCriteriaParametersAndValuesDTO { get; set; }
        public List<FeePredefinedCriteriaParameters> PredefinedCriteriaParametersList { get; set; }
        public List<FeeCriteriaParametersAndValues> PredefinedCriteriaParametersValueList { get; set; }

        public IEnumerable<SelectListItem> GetPredefinedCriteriaParametersListItems
        {
            get
            {
                return new SelectList(PredefinedCriteriaParametersList, "FeeCriteriaParametersCode", "FeeCriteriaParametersDescription");
            }
        }

        //// for Critaria values
        //public IEnumerable<SelectListItem> GetPredefinedCriteriaParametersValueListItems
        //{
        //    get
        //    {
        //        return new SelectList(PredefinedCriteriaParametersValueList, "FeeCriteriaParametersValuesID", "FeeCriteriaParameterValue");
        //    }
        //}

        //FeeCriteriaParameters
        public int FeeCriteriaParametersID
        {
            get
            {
                return (FeeCriteriaParametersAndValuesDTO != null && FeeCriteriaParametersAndValuesDTO.FeeCriteriaParametersID > 0) ? FeeCriteriaParametersAndValuesDTO.FeeCriteriaParametersID : new int();
            }
            set
            {
                FeeCriteriaParametersAndValuesDTO.FeeCriteriaParametersID = value;
            }
        }
        //[Display(Name = "DisplayName_SeqNo", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SeqNoRequired")]
        [Display(Name = "Parameter Description")]
        [Required(ErrorMessage = "Parameter Description should not be blank.")]
        public string FeeCriteriaParametersDescription
        {
            get
            {
                return (FeeCriteriaParametersAndValuesDTO != null) ? FeeCriteriaParametersAndValuesDTO.FeeCriteriaParametersDescription : string.Empty;
            }
            set
            {
                FeeCriteriaParametersAndValuesDTO.FeeCriteriaParametersDescription = value;
            }
        }
        // [Display(Name = "DisplayName_SeqNo", ResourceType = typeof(AMS.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SeqNoRequired")]
        [Display(Name = "Parameter Code")]
        [Required(ErrorMessage = "Parameter Code should not be blank")]
        public string FeeCriteriaParametersCode
        {
            get
            {
                return (FeeCriteriaParametersAndValuesDTO != null) ? FeeCriteriaParametersAndValuesDTO.FeeCriteriaParametersCode : string.Empty;
            }
            set
            {
                FeeCriteriaParametersAndValuesDTO.FeeCriteriaParametersCode = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return (FeeCriteriaParametersAndValuesDTO != null) ? FeeCriteriaParametersAndValuesDTO.IsActive : false;
            }
            set
            {
                FeeCriteriaParametersAndValuesDTO.IsActive = value;
            }
        }
        public string CentreCode
        {
            get;
            set;
        }
        [Display(Name = "Related With")]
        public string RelatedWith
        {
            get;
            set;
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (FeeCriteriaParametersAndValuesDTO != null) ? FeeCriteriaParametersAndValuesDTO.IsDeleted : false;
            }
            set
            {
                FeeCriteriaParametersAndValuesDTO.IsDeleted = value;
            }
        }
        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (FeeCriteriaParametersAndValuesDTO != null && FeeCriteriaParametersAndValuesDTO.CreatedBy > 0) ? FeeCriteriaParametersAndValuesDTO.CreatedBy : new int();
            }
            set
            {
                FeeCriteriaParametersAndValuesDTO.CreatedBy = value;
            }
        }
        public int AccBalanceSheetID
        {
            get
            {
                return (FeeCriteriaParametersAndValuesDTO != null) ? FeeCriteriaParametersAndValuesDTO.AccBalanceSheetID : new int();
            }
            set
            {
                FeeCriteriaParametersAndValuesDTO.AccBalanceSheetID = value;
            }
        }
        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (FeeCriteriaParametersAndValuesDTO != null) ? FeeCriteriaParametersAndValuesDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                FeeCriteriaParametersAndValuesDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (FeeCriteriaParametersAndValuesDTO != null && FeeCriteriaParametersAndValuesDTO.ModifiedBy.HasValue) ? FeeCriteriaParametersAndValuesDTO.ModifiedBy : new int();
            }
            set
            {
                FeeCriteriaParametersAndValuesDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (FeeCriteriaParametersAndValuesDTO != null && FeeCriteriaParametersAndValuesDTO.ModifiedDate.HasValue) ? FeeCriteriaParametersAndValuesDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                FeeCriteriaParametersAndValuesDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (FeeCriteriaParametersAndValuesDTO != null && FeeCriteriaParametersAndValuesDTO.DeletedBy.HasValue) ? FeeCriteriaParametersAndValuesDTO.DeletedBy : new int();
            }
            set
            {
                FeeCriteriaParametersAndValuesDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (FeeCriteriaParametersAndValuesDTO != null && FeeCriteriaParametersAndValuesDTO.DeletedDate.HasValue) ? FeeCriteriaParametersAndValuesDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                FeeCriteriaParametersAndValuesDTO.DeletedDate = value;
            }
        }

        //FeeCriteriaParametersValues

        public int FeeCriteriaParametersValuesID
        {
            get
            {
                return (FeeCriteriaParametersAndValuesDTO != null && FeeCriteriaParametersAndValuesDTO.FeeCriteriaParametersValuesID > 0) ? FeeCriteriaParametersAndValuesDTO.FeeCriteriaParametersValuesID : new int();
            }
            set
            {
                FeeCriteriaParametersAndValuesDTO.FeeCriteriaParametersValuesID = value;
            }
        }

        [Display(Name = "Parameter Value")]
        [Required(ErrorMessage = "Parameter Value should not be blank")]
        public string FeeCriteriaParameterValue
        {
            get
            {
                return (FeeCriteriaParametersAndValuesDTO != null) ? FeeCriteriaParametersAndValuesDTO.FeeCriteriaParameterValue : string.Empty;
            }
            set
            {
                FeeCriteriaParametersAndValuesDTO.FeeCriteriaParameterValue = value;
            }
        }
        public string errorMessage { get; set; }
    }
}

