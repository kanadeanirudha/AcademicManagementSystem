using AMS.Common;
using AMS.DTO;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class FeeStructureMasterAndDetailsViewModel : IFeeStructureMasterAndDetailsViewModel
    {
        public FeeStructureMasterAndDetailsViewModel()
        {
            FeeStructureMasterAndDetailsDTO = new FeeStructureMasterAndDetails();
            AccountMasterList = new List<AccountMaster>();
            FeeSubTypeList = new List<FeeTypeAndSubType>();
            ListGetFeeCriteria = new List<FeeCriteriaMasterAndDetails>();
            FeeStructureMasterAndDetailsList = new List<FeeStructureMasterAndDetails>();

        }
        public List<AccountMaster> AccountMasterList { get; set; }
        public List<FeeTypeAndSubType> FeeSubTypeList { get; set; }
        public IEnumerable<SelectListItem> AccountMasterListItems
        {
            get
            {
                return new SelectList(AccountMasterList, "ID", "AccountName");
            }
        }
        public IEnumerable<SelectListItem> FeeSubTypeListItems
        {
            get
            {
                return new SelectList(FeeSubTypeList, "FeeSubTypeID", "FeeSubTypeDesc");
            }
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
        public List<FeeStructureMasterAndDetails> FeeStructureMasterAndDetailsList
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> FeeStructureMasterAndDetailsListItems
        {
            get
            {
                return new SelectList(FeeStructureMasterAndDetailsList, "FeeStructureMasterID", "FeeSubTypeDesc");
            }
        }
        public FeeStructureMasterAndDetails FeeStructureMasterAndDetailsDTO { get; set; }
        //-------------------------------FeeStructureMaster ------------------------------------
        public int FeeStructureMasterID
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null && FeeStructureMasterAndDetailsDTO.FeeStructureMasterID > 0) ? FeeStructureMasterAndDetailsDTO.FeeStructureMasterID : new int();
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.FeeStructureMasterID = value;
            }
        }
        [Display(Name = "Total Fee Amount :")]
        public decimal TotalFeeAmount
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.TotalFeeAmount : new decimal();
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.TotalFeeAmount = value;
            }
        }
        public int FeeCriteriaValueCombinationMasterID
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.FeeCriteriaValueCombinationMasterID : new int();
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.FeeCriteriaValueCombinationMasterID = value;
            }
        }
        [Required(ErrorMessage="Please select no. of installment.")]
        [Display(Name = "Number of Installment :")]
        public Int16 NumberOfInstallment
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.NumberOfInstallment : new Int16();
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.NumberOfInstallment = value;
            }
        }
        public bool IsInstallmentApplicable
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.IsInstallmentApplicable : false;
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.IsInstallmentApplicable = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.IsActive : false;
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.IsActive = value;
            }
        }
        public bool IsRevised
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.IsRevised : false;
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.IsRevised = value;
            }
        }
        public int ParentID
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.ParentID : new int();
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.ParentID = value;
            }
        }
        public bool IsLastRecord
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.IsLastRecord : false;
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.IsLastRecord = value;
            }
        }

        //-------------------------------FeeStructureDetails---------------------------------
        public int FeeStructureDetailID
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.FeeStructureDetailID : new int();
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.FeeStructureDetailID = value;
            }
        }
        public Int16 FeeSubTypeID
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.FeeSubTypeID : new Int16();
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.FeeSubTypeID = value;
            }
        }
        [Display(Name = "Fee SubType")]
        public string FeeSubTypeName
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.FeeSubTypeName : string.Empty;
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.FeeSubTypeName = value;
            }
        }
        [Display(Name = "Fee Amount")]
        public decimal FeeSubTypeAmount
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.FeeSubTypeAmount : new decimal();
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.FeeSubTypeAmount = value;
            }
        }

        //-------------------------------FeeStructureInstallmentMaster---------------------------------
        public int FeeStructureInstallmentMasterID
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.FeeStructureMasterID : new int();
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.FeeStructureMasterID = value;
            }
        }
        public Int16 FeeInstallmentNumber
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.FeeInstallmentNumber : new Int16();
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.FeeInstallmentNumber = value;
            }
        }
        public decimal FeeInstallmentAmount
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.FeeInstallmentAmount : new decimal();
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.FeeInstallmentAmount = value;
            }
        }
        [Display(Name = "Is LateFee Applicable :")]
        public bool IsLateFeeApplicable
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.IsLateFeeApplicable : false;
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.IsLateFeeApplicable = value;
            }
        }
        [Display(Name = "LateFee :")]
        public int LateFeeID { get; set; }

        //-------------------------------FeeStructureDetailsInstallmentWise---------------------------------
        public int FeeStructureDetailsInstallmentWiseID
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.FeeStructureDetailsInstallmentWiseID : new int();
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.FeeStructureDetailsInstallmentWiseID = value;
            }
        }
        //-------------------------------Other---------------------------------

        public string errorMessage { get; set; }
        public string SelectedBalanceSheet { get; set; }
        public int SelectedBalanceSheetID { get; set; }
        public string SelectedFeeCriteriaMasterID
        {
            get;
            set;
        }
        [Display(Name = "Criteria Combination :")]
        public string FeeCriteriaCombinationName
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.FeeCriteriaCombinationName : string.Empty;
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.FeeCriteriaCombinationName = value;
            }
        }
        [Display(Name = "Payment Mode :")]
        public string PaymentMode
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.PaymentMode : string.Empty;
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.PaymentMode = value;
            }
        }
        public string XMLFeeStructureDetailsIDs
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.XMLFeeStructureDetailsIDs : string.Empty;
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.XMLFeeStructureDetailsIDs = value;
            }
        }
        public string XMLFeeStructureInstallmentMasterIDs
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.XMLFeeStructureInstallmentMasterIDs : string.Empty;
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.XMLFeeStructureInstallmentMasterIDs = value;
            }
        }
        public string XMLFeeStructureDetailsInstallmentWiseIDs
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.XMLFeeStructureDetailsInstallmentWiseIDs : string.Empty;
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.XMLFeeStructureDetailsInstallmentWiseIDs = value;
            }
        }

        //FeeCriteriaParameters
        public int FeeCriteriaMasterID
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null && FeeStructureMasterAndDetailsDTO.FeeCriteriaMasterID > 0) ? FeeStructureMasterAndDetailsDTO.FeeCriteriaMasterID : new int();
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.FeeCriteriaMasterID = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null && FeeStructureMasterAndDetailsDTO.CreatedBy > 0) ? FeeStructureMasterAndDetailsDTO.CreatedBy : new short();
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.CreatedDate = value;
            }
        }
        public int ModifiedBy
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null && FeeStructureMasterAndDetailsDTO.ModifiedBy > 0) ? FeeStructureMasterAndDetailsDTO.ModifiedBy : new short();
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.ModifiedBy = value;
            }
        }
        public DateTime ModifiedDate
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.ModifiedDate = value;
            }
        }
        public int DeletedBy
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null && FeeStructureMasterAndDetailsDTO.DeletedBy > 0) ? FeeStructureMasterAndDetailsDTO.DeletedBy : new short();
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.DeletedBy = value;
            }
        }
        public DateTime DeletedDate
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.DeletedDate = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.IsDeleted : false;
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.IsDeleted = value;
            }
        }

        public string FeeStructureApplicableFromDate
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.FeeStructureApplicableFromDate : string.Empty;
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.FeeStructureApplicableFromDate = value;
            }
        }
        public int FeeStructureSessionMasterID
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null && FeeStructureMasterAndDetailsDTO.FeeStructureSessionMasterID > 0) ? FeeStructureMasterAndDetailsDTO.FeeStructureSessionMasterID : new short();
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.FeeStructureSessionMasterID = value;
            }
        }
        public int FeeStructureSessionInstallmentDetailsID
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null && FeeStructureMasterAndDetailsDTO.FeeStructureSessionInstallmentDetailsID > 0) ? FeeStructureMasterAndDetailsDTO.FeeStructureSessionInstallmentDetailsID : new short();
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.FeeStructureSessionInstallmentDetailsID = value;
            }
        }
        public string InstallmentFromDate
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.InstallmentFromDate : string.Empty;
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.InstallmentFromDate = value;
            }
        }
        public string InstallmentToDate
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.InstallmentToDate : string.Empty;
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.InstallmentToDate = value;
            }
        }

        //----------------------------------------FeeAccountTypeMaster Table-------------------------------
        public int FeeAccountTypeMasterID
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null && FeeStructureMasterAndDetailsDTO.FeeAccountTypeMasterID > 0) ? FeeStructureMasterAndDetailsDTO.FeeAccountTypeMasterID : new int();
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.FeeAccountTypeMasterID = value;
            }
        }
        public string FeeAccountTypeDesc
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.FeeAccountTypeDesc : string.Empty;
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.FeeAccountTypeDesc = value;
            }
        }
        public Int16 FeeAccountTypeCode
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null && FeeStructureMasterAndDetailsDTO.FeeAccountTypeCode > 0) ? FeeStructureMasterAndDetailsDTO.FeeAccountTypeCode : new Int16();
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.FeeAccountTypeCode = value;
            }
        }

        //------------------------------FeeAccountSubTypeMaster Table---------------------------------------
        public int FeeAccountSubTypeMasterID
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null && FeeStructureMasterAndDetailsDTO.FeeAccountSubTypeMasterID > 0) ? FeeStructureMasterAndDetailsDTO.FeeAccountSubTypeMasterID : new int();
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.FeeAccountSubTypeMasterID = value;
            }
        }

        [Display(Name="Fee Receivable From Student :")]
        [Required(ErrorMessage = "Fee receivable sub type should not blank.")]
        public string FeeAccountSubTypeDesc
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.FeeAccountSubTypeDesc : string.Empty;
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.FeeAccountSubTypeDesc = value;
            }
        }
        public string FeeAccountSubTypeCode
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.FeeAccountSubTypeCode : string.Empty;
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.FeeAccountSubTypeCode = value;
            }
        }
        public int AccountID
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null && FeeStructureMasterAndDetailsDTO.AccountID > 0) ? FeeStructureMasterAndDetailsDTO.AccountID : new int();
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.AccountID = value;
            }
        }
        public bool CrDrStatus
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null && FeeStructureMasterAndDetailsDTO.CrDrStatus != false) ? FeeStructureMasterAndDetailsDTO.CrDrStatus : new bool();
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.CrDrStatus = value;
            }
        }

        public string AccountType
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.AccountType : string.Empty;
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.AccountType = value;
            }
        }

        public decimal TotalAmount
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.TotalAmount : new decimal();
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.TotalAmount = value;
            }
        }

        public int AccountIDForFeeAccountSubTypeMaster
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null && FeeStructureMasterAndDetailsDTO.AccountIDForFeeAccountSubTypeMaster > 0) ? FeeStructureMasterAndDetailsDTO.AccountIDForFeeAccountSubTypeMaster : new int();
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.AccountIDForFeeAccountSubTypeMaster = value;
            }
        }
        public string InstallmentAmount
        {
            get
            {
                return (FeeStructureMasterAndDetailsDTO != null) ? FeeStructureMasterAndDetailsDTO.InstallmentAmount : string.Empty;
            }
            set
            {
                FeeStructureMasterAndDetailsDTO.InstallmentAmount = value;
            }
        } 
    }
}
