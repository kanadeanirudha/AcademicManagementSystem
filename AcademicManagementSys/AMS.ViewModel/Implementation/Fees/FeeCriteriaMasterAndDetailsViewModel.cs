using AMS.Common;
using AMS.DTO;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class FeeCriteriaMasterAndDetailsViewModel : IFeeCriteriaMasterAndDetailsViewModel
    {
        public FeeCriteriaMasterAndDetailsViewModel() {
            FeeCriteriaMasterAndDetailsDTO = new FeeCriteriaMasterAndDetails();
            FeeTypeList = new List<FeeTypeAndSubType>();
        }
        public List<FeeTypeAndSubType> FeeTypeList { get; set; }
        public List<FeeCriteriaParametersAndValues> FeeCriteriaParametersAndValuesList { get; set; }
        public IEnumerable<SelectListItem> FeeTypeListItems
        {
            get
            {
                return new SelectList(FeeTypeList, "ID", "FeeTypeDesc");
            }
        }
        public FeeCriteriaMasterAndDetails FeeCriteriaMasterAndDetailsDTO { get; set; }

        //-----------------------------Fee Criteria Master-----------------------------
        public int ID
        {
            get
            {
                return (FeeCriteriaMasterAndDetailsDTO != null && FeeCriteriaMasterAndDetailsDTO.ID > 0) ? FeeCriteriaMasterAndDetailsDTO.ID : new int();
            }
            set
            {
                FeeCriteriaMasterAndDetailsDTO.ID = value;
            }
        }
        [Display(Name = "DisplayName_FeeCriteriaDescription", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_FeeCriteriaDescriptionRequired")]
        public string FeeCriteriaDescription
        {
            get
            {
                return (FeeCriteriaMasterAndDetailsDTO != null) ? FeeCriteriaMasterAndDetailsDTO.FeeCriteriaDescription : string.Empty;
            }
            set
            {
                FeeCriteriaMasterAndDetailsDTO.FeeCriteriaDescription = value;
            }
        }
        [Display(Name = "DisplayName_FeeCriteriaCode", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_FeeCriteriaCodeRequired")]
        public string FeeCriteriaCode
        {
            get
            {
                return (FeeCriteriaMasterAndDetailsDTO != null) ? FeeCriteriaMasterAndDetailsDTO.FeeCriteriaCode : string.Empty;
            }
            set
            {
                FeeCriteriaMasterAndDetailsDTO.FeeCriteriaCode = value;
            }
        }
        [Display(Name = "DisplayName_FeeTypeID", ResourceType = typeof(Resources))]
        public short FeeTypeID
        {
            get
            {
                return (FeeCriteriaMasterAndDetailsDTO != null && FeeCriteriaMasterAndDetailsDTO.FeeTypeID > 0) ? FeeCriteriaMasterAndDetailsDTO.FeeTypeID : new short();
            }
            set
            {
                FeeCriteriaMasterAndDetailsDTO.FeeTypeID = value;
            }
        }
        public short AccBalanceSheetID
        {
            get
            {
                return (FeeCriteriaMasterAndDetailsDTO != null && FeeCriteriaMasterAndDetailsDTO.AccBalanceSheetID > 0) ? FeeCriteriaMasterAndDetailsDTO.AccBalanceSheetID : new short();
            }
            set
            {
                FeeCriteriaMasterAndDetailsDTO.AccBalanceSheetID = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (FeeCriteriaMasterAndDetailsDTO != null) ? FeeCriteriaMasterAndDetailsDTO.IsActive : false;
            }
            set
            {
                FeeCriteriaMasterAndDetailsDTO.IsActive = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (FeeCriteriaMasterAndDetailsDTO != null) ? FeeCriteriaMasterAndDetailsDTO.CentreCode : string.Empty;
            }
            set
            {
                FeeCriteriaMasterAndDetailsDTO.CentreCode = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (FeeCriteriaMasterAndDetailsDTO != null && FeeCriteriaMasterAndDetailsDTO.CreatedBy > 0) ? FeeCriteriaMasterAndDetailsDTO.CreatedBy : new short();
            }
            set
            {
                FeeCriteriaMasterAndDetailsDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (FeeCriteriaMasterAndDetailsDTO != null) ? FeeCriteriaMasterAndDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                FeeCriteriaMasterAndDetailsDTO.CreatedDate = value;
            }
        }
        public int ModifiedBy
        {
            get
            {
                return (FeeCriteriaMasterAndDetailsDTO != null && FeeCriteriaMasterAndDetailsDTO.ModifiedBy > 0) ? FeeCriteriaMasterAndDetailsDTO.ModifiedBy : new short();
            }
            set
            {
                FeeCriteriaMasterAndDetailsDTO.ModifiedBy = value;
            }
        }
        public DateTime ModifiedDate
        {
            get
            {
                return (FeeCriteriaMasterAndDetailsDTO != null) ? FeeCriteriaMasterAndDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                FeeCriteriaMasterAndDetailsDTO.ModifiedDate = value;
            }
        }
        public int DeletedBy
        {
            get
            {
                return (FeeCriteriaMasterAndDetailsDTO != null && FeeCriteriaMasterAndDetailsDTO.DeletedBy > 0) ? FeeCriteriaMasterAndDetailsDTO.DeletedBy : new short();
            }
            set
            {
                FeeCriteriaMasterAndDetailsDTO.DeletedBy = value;
            }
        }
        public DateTime DeletedDate
        {
            get
            {
                return (FeeCriteriaMasterAndDetailsDTO != null) ? FeeCriteriaMasterAndDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                FeeCriteriaMasterAndDetailsDTO.DeletedDate = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (FeeCriteriaMasterAndDetailsDTO != null) ? FeeCriteriaMasterAndDetailsDTO.IsDeleted : false;
            }
            set
            {
                FeeCriteriaMasterAndDetailsDTO.IsDeleted = value;
            }
        }

        //----------------------------Fee Criteria Details -------------------------------

        public int FeeCriteriaDetailsID
        {
            get
            {
                return (FeeCriteriaMasterAndDetailsDTO != null && FeeCriteriaMasterAndDetailsDTO.FeeCriteriaDetailsID > 0) ? FeeCriteriaMasterAndDetailsDTO.FeeCriteriaDetailsID : new int();
            }
            set
            {
                FeeCriteriaMasterAndDetailsDTO.FeeCriteriaDetailsID = value;
            }
        }
        [Display(Name = "DisplayName_FeeCriteriaParametersName", ResourceType = typeof(Resources))]
        public string FeeCriteriaParametersName { get; set; }
        public int FeeCriteriaParametersID
        {
            get
            {
                return (FeeCriteriaMasterAndDetailsDTO != null && FeeCriteriaMasterAndDetailsDTO.FeeCriteriaParametersID > 0) ? FeeCriteriaMasterAndDetailsDTO.FeeCriteriaParametersID : new int();
            }
            set
            {
                FeeCriteriaMasterAndDetailsDTO.FeeCriteriaParametersID = value;
            }
        }
        public string FeeCriteriaParametersXML
        {
            get
            {
                return (FeeCriteriaMasterAndDetailsDTO != null) ? FeeCriteriaMasterAndDetailsDTO.FeeCriteriaParametersXML : string.Empty;
            }
            set
            {
                FeeCriteriaMasterAndDetailsDTO.FeeCriteriaParametersXML = value;
            }
        }

        public string errorMessage
        {
            get
            {
                return (FeeCriteriaMasterAndDetailsDTO != null) ? FeeCriteriaMasterAndDetailsDTO.errorMessage : string.Empty;
            }
            set
            {
                FeeCriteriaMasterAndDetailsDTO.errorMessage = value;
            }
        }
        public bool IsFeeCriteriaMasterTransaction
        {
            get
            {
                return (FeeCriteriaMasterAndDetailsDTO != null) ? FeeCriteriaMasterAndDetailsDTO.IsFeeCriteriaMasterTransaction : false;
            }
            set
            {
                FeeCriteriaMasterAndDetailsDTO.IsFeeCriteriaMasterTransaction = value;
            }
        }
        [Display(Name = "DisplayName_AccBalanceSheetName", ResourceType = typeof(Resources))]
        public string AccBalanceSheetName
        {
            get
            {
                return (FeeCriteriaMasterAndDetailsDTO != null) ? FeeCriteriaMasterAndDetailsDTO.AccBalanceSheetName : string.Empty;
            }
            set
            {
                FeeCriteriaMasterAndDetailsDTO.AccBalanceSheetName = value;
            }
        }
    }
}
