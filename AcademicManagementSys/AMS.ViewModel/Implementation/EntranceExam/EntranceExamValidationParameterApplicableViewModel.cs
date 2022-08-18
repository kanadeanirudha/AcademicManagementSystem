using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class EntranceExamValidationParameterApplicableViewModel : IEntranceExamValidationParameterApplicableViewModel
    {

        public EntranceExamValidationParameterApplicableViewModel()
        {
            EntranceExamValidationParameterApplicableDTO = new EntranceExamValidationParameterApplicable();
            ListOrganisationCentrewiseSession = new List<OrganisationCentrewiseSession>();
        }

        public EntranceExamValidationParameterApplicable EntranceExamValidationParameterApplicableDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (EntranceExamValidationParameterApplicableDTO != null && EntranceExamValidationParameterApplicableDTO.ID > 0) ? EntranceExamValidationParameterApplicableDTO.ID : new int();
            }
            set
            {
                EntranceExamValidationParameterApplicableDTO.ID = value;
            }
        }
        public int EntranceExamValidationParameterID
        {
            get;
            set;
        }

        public bool IsLastRecord
        {
            get;
            set;
        }
        public string FromDate
        {
            get;
            set;
        }
        public string UpToDate
        {
            get;
            set;
        }


        [Required(ErrorMessage = "Fee Criteria Value Combination Description  should not be blank.")]
        [Display(Name = "Fee Criteria :")]
        public string FeeCriteriaValueCombinationDescription  
        {
            get
            {
                return (EntranceExamValidationParameterApplicableDTO != null) ? EntranceExamValidationParameterApplicableDTO.FeeCriteriaValueCombinationDescription : string.Empty;
            }
            set
            {
                EntranceExamValidationParameterApplicableDTO.FeeCriteriaValueCombinationDescription = value;
            }
        }

        [Required(ErrorMessage = "Pre Qualification Cut Off should not be blank.")]
        [Display(Name = "Pre Qualification Cut Off(%) :")]
        public decimal PreQualificationCutOff
        {
            get
            {
                return (EntranceExamValidationParameterApplicableDTO != null && EntranceExamValidationParameterApplicableDTO.PreQualificationCutOff > 0) ? EntranceExamValidationParameterApplicableDTO.PreQualificationCutOff : new decimal();
            }
            set
            {
                EntranceExamValidationParameterApplicableDTO.PreQualificationCutOff = value;
            }
        }
        [Required(ErrorMessage = "Entrance Exam Fee Amount should not be blank.")]
        [Display(Name = "Entrance Exam Fee Amount:")]
        public decimal EntranceExamFeeAmount			
        {
            get
            {
                return (EntranceExamValidationParameterApplicableDTO != null && EntranceExamValidationParameterApplicableDTO.PreQualificationCutOff > 0) ? EntranceExamValidationParameterApplicableDTO.EntranceExamFeeAmount: new decimal();
            }
            set
            {
                EntranceExamValidationParameterApplicableDTO.EntranceExamFeeAmount= value;
            }
        }
        [Required(ErrorMessage = "Entrance Exam Cut Off should not be blank.")]
        [Display(Name = "Entrance Exam Cut Off(%) :")]
        public decimal EntranceExamCutOff
        {
            get
            {
                return (EntranceExamValidationParameterApplicableDTO != null && EntranceExamValidationParameterApplicableDTO.EntranceExamCutOff > 0) ? EntranceExamValidationParameterApplicableDTO.EntranceExamCutOff: new decimal();
            }
            set
            {
                EntranceExamValidationParameterApplicableDTO.EntranceExamCutOff= value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EntranceExamValidationParameterApplicableDTO != null) ? EntranceExamValidationParameterApplicableDTO.IsDeleted : false;
            }
            set
            {
                EntranceExamValidationParameterApplicableDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EntranceExamValidationParameterApplicableDTO != null && EntranceExamValidationParameterApplicableDTO.CreatedBy > 0) ? EntranceExamValidationParameterApplicableDTO.CreatedBy : new int();
            }
            set
            {
                EntranceExamValidationParameterApplicableDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EntranceExamValidationParameterApplicableDTO != null) ? EntranceExamValidationParameterApplicableDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EntranceExamValidationParameterApplicableDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (EntranceExamValidationParameterApplicableDTO != null) ? EntranceExamValidationParameterApplicableDTO.ModifiedBy : new int();
            }
            set
            {
                EntranceExamValidationParameterApplicableDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (EntranceExamValidationParameterApplicableDTO != null) ? EntranceExamValidationParameterApplicableDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EntranceExamValidationParameterApplicableDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (EntranceExamValidationParameterApplicableDTO != null) ? EntranceExamValidationParameterApplicableDTO.DeletedBy : new int();
            }
            set
            {
                EntranceExamValidationParameterApplicableDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (EntranceExamValidationParameterApplicableDTO != null) ? EntranceExamValidationParameterApplicableDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EntranceExamValidationParameterApplicableDTO.DeletedDate = value;
            }
        }
        [Display(Name = "Centre Code :")]
        public string CentreCode
        {
            get
            {
                return (EntranceExamValidationParameterApplicableDTO != null) ? EntranceExamValidationParameterApplicableDTO.CentreCode : string.Empty;
            }
            set
            {
                EntranceExamValidationParameterApplicableDTO.CentreCode = value;
            }
        }

        [Display(Name = "Centre Name :")]
        public string CentreName
        {
            get
            {
                return (EntranceExamValidationParameterApplicableDTO != null) ? EntranceExamValidationParameterApplicableDTO.CentreName : string.Empty;
            }
            set
            {
                EntranceExamValidationParameterApplicableDTO.CentreName = value;
            }
        }

        public string SessionName { get; set; }
        public int SessionID
        {
            get
            {
                return (EntranceExamValidationParameterApplicableDTO != null && EntranceExamValidationParameterApplicableDTO.SessionID > 0) ? EntranceExamValidationParameterApplicableDTO.SessionID : new int();
            }
            set
            {
                EntranceExamValidationParameterApplicableDTO.SessionID = value;
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

