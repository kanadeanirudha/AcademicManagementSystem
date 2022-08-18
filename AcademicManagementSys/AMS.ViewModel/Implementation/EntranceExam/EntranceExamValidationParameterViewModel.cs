using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class EntranceExamValidationParameterViewModel : IEntranceExamValidationParameterViewModel
    {

        public EntranceExamValidationParameterViewModel()
        {
            EntranceExamValidationParameterDTO = new EntranceExamValidationParameter();
            ListOrganisationCentrewiseSession = new List<OrganisationCentrewiseSession>();
        }

        public EntranceExamValidationParameter EntranceExamValidationParameterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (EntranceExamValidationParameterDTO != null && EntranceExamValidationParameterDTO.ID > 0) ? EntranceExamValidationParameterDTO.ID : new int();
            }
            set
            {
                EntranceExamValidationParameterDTO.ID = value;
            }
        }
        public int FeeCriteriaValueCombinationMasterID
        {
            get
            {
                return (EntranceExamValidationParameterDTO != null && EntranceExamValidationParameterDTO.FeeCriteriaValueCombinationMasterID > 0) ? EntranceExamValidationParameterDTO.FeeCriteriaValueCombinationMasterID : new int();
            }
            set
            {
                EntranceExamValidationParameterDTO.FeeCriteriaValueCombinationMasterID = value;
            }
        }
        public int FeeCriteriaMasterID
        {
            get
            {
                return (EntranceExamValidationParameterDTO != null && EntranceExamValidationParameterDTO.FeeCriteriaMasterID > 0) ? EntranceExamValidationParameterDTO.FeeCriteriaMasterID : new int();
            }
            set
            {
                EntranceExamValidationParameterDTO.FeeCriteriaMasterID = value;
            }
        }


        [Required(ErrorMessage = "Fee Criteria Value Combination Description  should not be blank.")]
        [Display(Name = "Fee Criteria :")]
        public string FeeCriteriaValueCombinationDescription  
        {
            get
            {
                return (EntranceExamValidationParameterDTO != null) ? EntranceExamValidationParameterDTO.FeeCriteriaValueCombinationDescription : string.Empty;
            }
            set
            {
                EntranceExamValidationParameterDTO.FeeCriteriaValueCombinationDescription = value;
            }
        }

        [Required(ErrorMessage = "Pre Qualification Cut Off should not be blank.")]
        [Display(Name = "Pre Qualification Cut Off(%) :")]
        public decimal PreQualificationCutOff
        {
            get
            {
                return (EntranceExamValidationParameterDTO != null && EntranceExamValidationParameterDTO.PreQualificationCutOff > 0) ? EntranceExamValidationParameterDTO.PreQualificationCutOff : new decimal();
            }
            set
            {
                EntranceExamValidationParameterDTO.PreQualificationCutOff = value;
            }
        }
        [Required(ErrorMessage = "Entrance Exam Fee Amount should not be blank.")]
        [Display(Name = "Entrance Exam Fee Amount:")]
        public decimal EntranceExamFeeAmount			
        {
            get
            {
                return (EntranceExamValidationParameterDTO != null && EntranceExamValidationParameterDTO.PreQualificationCutOff > 0) ? EntranceExamValidationParameterDTO.EntranceExamFeeAmount: new decimal();
            }
            set
            {
                EntranceExamValidationParameterDTO.EntranceExamFeeAmount= value;
            }
        }
        [Required(ErrorMessage = "Entrance Exam Cut Off should not be blank.")]
        [Display(Name = "Entrance Exam Cut Off(%) :")]
        public decimal EntranceExamCutOff
        {
            get
            {
                return (EntranceExamValidationParameterDTO != null && EntranceExamValidationParameterDTO.EntranceExamCutOff > 0) ? EntranceExamValidationParameterDTO.EntranceExamCutOff: new decimal();
            }
            set
            {
                EntranceExamValidationParameterDTO.EntranceExamCutOff= value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EntranceExamValidationParameterDTO != null) ? EntranceExamValidationParameterDTO.IsDeleted : false;
            }
            set
            {
                EntranceExamValidationParameterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EntranceExamValidationParameterDTO != null && EntranceExamValidationParameterDTO.CreatedBy > 0) ? EntranceExamValidationParameterDTO.CreatedBy : new int();
            }
            set
            {
                EntranceExamValidationParameterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EntranceExamValidationParameterDTO != null) ? EntranceExamValidationParameterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EntranceExamValidationParameterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (EntranceExamValidationParameterDTO != null) ? EntranceExamValidationParameterDTO.ModifiedBy : new int();
            }
            set
            {
                EntranceExamValidationParameterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (EntranceExamValidationParameterDTO != null) ? EntranceExamValidationParameterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EntranceExamValidationParameterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (EntranceExamValidationParameterDTO != null) ? EntranceExamValidationParameterDTO.DeletedBy : new int();
            }
            set
            {
                EntranceExamValidationParameterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (EntranceExamValidationParameterDTO != null) ? EntranceExamValidationParameterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EntranceExamValidationParameterDTO.DeletedDate = value;
            }
        }
        [Display(Name = "Centre Code :")]
        public string CentreCode
        {
            get
            {
                return (EntranceExamValidationParameterDTO != null) ? EntranceExamValidationParameterDTO.CentreCode : string.Empty;
            }
            set
            {
                EntranceExamValidationParameterDTO.CentreCode = value;
            }
        }

        [Display(Name = "Centre Name :")]
        public string CentreName
        {
            get
            {
                return (EntranceExamValidationParameterDTO != null) ? EntranceExamValidationParameterDTO.CentreName : string.Empty;
            }
            set
            {
                EntranceExamValidationParameterDTO.CentreName = value;
            }
        }

        public string SessionName { get; set; }
        public int SessionID
        {
            get
            {
                return (EntranceExamValidationParameterDTO != null && EntranceExamValidationParameterDTO.SessionID > 0) ? EntranceExamValidationParameterDTO.SessionID : new int();
            }
            set
            {
                EntranceExamValidationParameterDTO.SessionID = value;
            }
        }
        public List<OrganisationCentrewiseSession> ListOrganisationCentrewiseSession
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> SessionListMasterItems
        {
            get
            {
                return new SelectList(ListOrganisationCentrewiseSession, "ID", "SessionName");
            }
        }

        public string errorMessage { get; set; }
    }
}

