using AMS.DTO;
using System;

namespace AMS.ViewModel
{
   public  interface IFeeStructureMasterAndDetailsViewModel
    {
        //-------------------------------FeeStructureMaster ------------------------------------
         int FeeStructureMasterID { get; set; }
         decimal TotalFeeAmount { get; set; }
         int FeeCriteriaValueCombinationMasterID { get; set; }
         Int16 NumberOfInstallment { get; set; }
         bool IsInstallmentApplicable { get; set; }
         bool IsActive { get; set; }
         bool IsRevised { get; set; }
         int ParentID { get; set; }
         bool IsLastRecord { get; set; }

        //-------------------------------FeeStructureDetails---------------------------------
         int FeeStructureDetailID { get; set; }
         Int16 FeeSubTypeID { get; set; }
         decimal FeeSubTypeAmount { get; set; }

        //-------------------------------FeeStructureInstallmentMaster---------------------------------
         int FeeStructureInstallmentMasterID { get; set; }
         Int16 FeeInstallmentNumber { get; set; }
         decimal FeeInstallmentAmount { get; set; }
         bool IsLateFeeApplicable { get; set; }
         int LateFeeID { get; set; }

        //-------------------------------FeeStructureDetailsInstallmentWise---------------------------------
         int FeeStructureDetailsInstallmentWiseID { get; set; }
        //-------------------------------Other---------------------------------
         int CreatedBy { get; set; }
         DateTime CreatedDate { get; set; }
         int ModifiedBy { get; set; }
         DateTime ModifiedDate { get; set; }
         int DeletedBy { get; set; }
         DateTime DeletedDate { get; set; }
         bool IsDeleted { get; set; }
         string errorMessage { get; set; }
         string SelectedBalanceSheet { get; set; }
    }
}
