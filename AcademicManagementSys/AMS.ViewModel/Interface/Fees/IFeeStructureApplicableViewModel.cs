using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IFeeStructureApplicableViewModel
    {
        FeeStructureApplicable FeeStructureApplicableDTO { get; set; }
        //--------------------------------------Properties of FeeStructureSessionMaster table---------------------------------
         int ID
        {
            get;
            set;
        }
         int FeeStructureMasterID
        {
            get;
            set;
        }
         string ApplicableFromDate
        {
            get;
            set;
        }
         string ApplicableToDate
        {
            get;
            set;
        }
         string CentreCode
        {
            get;
            set;
        }
         bool IsActive
        {
            get;
            set;
        }
         bool IsDeleted
        {
            get;
            set;
        }
         int CreatedBy
        {
            get;
            set;
        }
         DateTime CreatedDate
        {
            get;
            set;
        }
         int? ModifiedBy
        {
            get;
            set;
        }
         DateTime? ModifiedDate
        {
            get;
            set;
        }
         int? DeletedBy
        {
            get;
            set;
        }
         DateTime? DeletedDate
        {
            get;
            set;
        }

        //--------------------------------------Properties of FeeStructureSessionInstallmentDetails table---------------------------------
         int FeeStructureSessionInstallmentDetailsID
        {
            get;
            set;
        }
         int FeeStructureSessionMasterID
        {
            get;
            set;
        }
         int FeeStructureInstallmentMasterID
        {
            get;
            set;
        }
         string InstallmentFromDate
        {
            get;
            set;
        }
         string InstallmentToDate
        {
            get;
            set;
        }

        //--------------------------------------Properties of FeeStructureApplicableDetails table---------------------------------
         int FeeStructureApplicableDetailsID
        {
            get;
            set;
        }
         string EntityType
        {
            get;
            set;
        }
         int EntityID
        {
            get;
            set;
        }

        //--------------------------------------Extra properties-------------------------------------------------------
         string errorMessage { get; set; }
         string AccBalanceSheetName { get; set; }
         string CentreName { get; set; }
         List<FeeCriteriaMasterAndDetails> ListGetFeeCriteria
         {
             get;
             set;
         }
         List<FeeStructureMasterAndDetails> FeeStructureMasterList
         {
             get;
             set;
         }
         List<FeeStructureMasterAndDetails> FeeStructureInstallmentList
         {
             get;
             set;
         }
         List<FeeStructureApplicable> StructureApplicableStudentList
         {
             get;
             set;
         }
         string SelectedFeeCriteriaMasterID { get; set; }
         decimal TotalFeeAmount { get; set; }
         bool IsInstallmentApplicable { get; set; }
         bool StatusFlag { get; set; }
         string FeeCriteriaValueCombinationDescription { get; set; }
         string Category { get; set; }
         string AdmitAcademicYear { get; set; }
         string BranchName { get; set; }
         string SectionName { get; set; }
         string DomicileState { get; set; }
         string StudentName { get; set; }
         int AccountID { get; set; }
         int FeeReceivableVoucherStructureID { get; set; }
         string AccountType { get; set; }
         decimal Amount { get; set; }
         bool CrDrStatus { get; set; }
         string FeeSubShortDesc { get; set; }
         Int16 Source { get; set; }
         int SubTypeMasterID { get; set; }
    }
}
