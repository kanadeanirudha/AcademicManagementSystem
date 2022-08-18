using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class FeeCriteriaCombinationParameterValueViewModel : IFeeCriteriaCombinationParameterValueViewModel
    {

        public FeeCriteriaCombinationParameterValueViewModel()
        {
            FeeCriteriaCombinationParameterValueDTO = new FeeCriteriaCombinationParameterValue();
            ListGetFeeCriteria = new List<FeeCriteriaMasterAndDetails>();
        }
        public List<FeeCriteriaMasterAndDetails> ListGetFeeCriteria
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListGetFeeCriteriaItems
        {
            get
            {
                return new SelectList(ListGetFeeCriteria, "ID", "FeeCriteriaDescription");
            }
        }
      
        public FeeCriteriaCombinationParameterValue FeeCriteriaCombinationParameterValueDTO
        {
            get;
            set;
        }
        public int FeeCriteriaValueCombinationMasterID
        {
            get
            {
                return (FeeCriteriaCombinationParameterValueDTO != null && FeeCriteriaCombinationParameterValueDTO.FeeCriteriaValueCombinationMasterID > 0) ? FeeCriteriaCombinationParameterValueDTO.FeeCriteriaValueCombinationMasterID : new int();
            }
            set
            {
                FeeCriteriaCombinationParameterValueDTO.FeeCriteriaValueCombinationMasterID = value;
            }
        }
        public string SelectedFeeCriteriaMasterID
        {
            get;
            set;
        }
        //FeeCriteriaParameters
        public int FeeCriteriaMasterID
        {
            get
            {
                return (FeeCriteriaCombinationParameterValueDTO != null && FeeCriteriaCombinationParameterValueDTO.FeeCriteriaMasterID > 0) ? FeeCriteriaCombinationParameterValueDTO.FeeCriteriaMasterID : new int();
            }
            set
            {
                FeeCriteriaCombinationParameterValueDTO.FeeCriteriaMasterID = value;
            }
        }

        public string FeeCriteriaValueCombinationDescription
        {
            get
            {
                return (FeeCriteriaCombinationParameterValueDTO != null) ? FeeCriteriaCombinationParameterValueDTO.FeeCriteriaValueCombinationDescription : string.Empty;
            }
            set
            {
                FeeCriteriaCombinationParameterValueDTO.FeeCriteriaValueCombinationDescription = value;
            }
        }

        public string FeeCriteriaParameterValueCombinationIDs
        {
            get
            {
                return (FeeCriteriaCombinationParameterValueDTO != null) ? FeeCriteriaCombinationParameterValueDTO.FeeCriteriaParameterValueCombinationIDs : string.Empty;
            }
            set
            {
                FeeCriteriaCombinationParameterValueDTO.FeeCriteriaParameterValueCombinationIDs = value;
            }
        }

        public bool ValueCombinationStatus
        {
            get
            {
                return (FeeCriteriaCombinationParameterValueDTO != null) ? FeeCriteriaCombinationParameterValueDTO.ValueCombinationStatus : false;
            }
            set
            {
                FeeCriteriaCombinationParameterValueDTO.ValueCombinationStatus = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (FeeCriteriaCombinationParameterValueDTO != null) ? FeeCriteriaCombinationParameterValueDTO.IsDeleted : false;
            }
            set
            {
                FeeCriteriaCombinationParameterValueDTO.IsDeleted = value;
            }
        }
        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (FeeCriteriaCombinationParameterValueDTO != null && FeeCriteriaCombinationParameterValueDTO.CreatedBy > 0) ? FeeCriteriaCombinationParameterValueDTO.CreatedBy : new int();
            }
            set
            {
                FeeCriteriaCombinationParameterValueDTO.CreatedBy = value;
            }
        }
      
        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (FeeCriteriaCombinationParameterValueDTO != null) ? FeeCriteriaCombinationParameterValueDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                FeeCriteriaCombinationParameterValueDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (FeeCriteriaCombinationParameterValueDTO != null && FeeCriteriaCombinationParameterValueDTO.ModifiedBy.HasValue) ? FeeCriteriaCombinationParameterValueDTO.ModifiedBy : new int();
            }
            set
            {
                FeeCriteriaCombinationParameterValueDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (FeeCriteriaCombinationParameterValueDTO != null && FeeCriteriaCombinationParameterValueDTO.ModifiedDate.HasValue) ? FeeCriteriaCombinationParameterValueDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                FeeCriteriaCombinationParameterValueDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (FeeCriteriaCombinationParameterValueDTO != null && FeeCriteriaCombinationParameterValueDTO.DeletedBy.HasValue) ? FeeCriteriaCombinationParameterValueDTO.DeletedBy : new int();
            }
            set
            {
                FeeCriteriaCombinationParameterValueDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (FeeCriteriaCombinationParameterValueDTO != null && FeeCriteriaCombinationParameterValueDTO.DeletedDate.HasValue) ? FeeCriteriaCombinationParameterValueDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                FeeCriteriaCombinationParameterValueDTO.DeletedDate = value;
            }
        }

        //FeeCriteriaParametersValues

        public int FeeCriteriaParameterValuesID
        {
            get
            {
                return (FeeCriteriaCombinationParameterValueDTO != null && FeeCriteriaCombinationParameterValueDTO.FeeCriteriaParameterValuesID > 0) ? FeeCriteriaCombinationParameterValueDTO.FeeCriteriaParameterValuesID : new int();
            }
            set
            {
                FeeCriteriaCombinationParameterValueDTO.FeeCriteriaParameterValuesID = value;
            }
        }

     
        public string errorMessage { get; set; }
    }
}

