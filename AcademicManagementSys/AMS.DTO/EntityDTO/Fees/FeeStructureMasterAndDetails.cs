using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class FeeStructureMasterAndDetails : BaseDTO 
    {
        //-------------------------------FeeStructureMaster ------------------------------------
        public int FeeStructureMasterID { get; set; }
        public decimal TotalFeeAmount { get; set; }
        public int FeeCriteriaValueCombinationMasterID { get; set; }
        public string FeeCriteriaCombinationName { get; set; }
        public Int16 NumberOfInstallment { get; set; }
        public bool IsInstallmentApplicable { get; set; }
        public bool IsActive { get; set; }
        public bool IsRevised { get; set; }
        public int ParentID { get; set; }
        public bool IsLastRecord { get; set; }

        //-------------------------------FeeStructureDetails---------------------------------
        public int FeeStructureDetailID { get; set; }
        public Int16 FeeSubTypeID { get; set; }
        public string FeeSubTypeName { get; set; }
        public decimal FeeSubTypeAmount { get; set; }

        //-------------------------------FeeStructureInstallmentMaster---------------------------------
        public int FeeStructureInstallmentMasterID { get; set; }
        public Int16 FeeInstallmentNumber { get; set; }
        public decimal FeeInstallmentAmount { get; set; }
        public bool IsLateFeeApplicable { get; set; }
        public int LateFeeID { get; set; }

        //-------------------------------FeeStructureDetailsInstallmentWise---------------------------------
        public int FeeStructureDetailsInstallmentWiseID { get; set; }

        //------------------------------FeeAccountTypeMaster Table--------------
        public int FeeAccountTypeMasterID { get; set; }
        public string FeeAccountTypeDesc { get; set; }
        public Int16 FeeAccountTypeCode { get; set; }

        //------------------------------FeeAccountSubTypeMaster Table-----------------
        public int FeeAccountSubTypeMasterID { get; set; }
        public string FeeAccountSubTypeDesc { get; set; }
        public string FeeAccountSubTypeCode { get; set; }
        public int AccountID { get; set; }

        //-------------------------------Other---------------------------------

        public bool StatusFlag { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string errorMessage { get; set; }
        public string SelectedBalanceSheet { get; set; }
        public int FeeCriteriaMasterID { get; set; }
        public string PaymentMode { get; set; }
        public string XMLFeeStructureDetailsIDs { get; set; }
        public string XMLFeeStructureInstallmentMasterIDs { get; set; }
        public string XMLFeeStructureDetailsInstallmentWiseIDs { get; set; }
        public string FeeStructureApplicableFromDate{ get; set; }
        public int FeeStructureSessionMasterID { get; set; }    
        public int FeeStructureSessionInstallmentDetailsID{ get; set; }    
        public string InstallmentFromDate { get; set; }
        public string InstallmentToDate { get; set; }
        public bool CrDrStatus { get; set; }
        public string AccountType { get; set; }
        public decimal TotalAmount { get; set; }
        public int AccountIDForFeeAccountSubTypeMaster { get; set; }
        public string InstallmentAmount { get; set; }
    }
}
