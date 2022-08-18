using AMS.DTO;
using System;

namespace AMS.ViewModel
{
    public interface IFeeCriteriaMasterAndDetailsViewModel
    {
        FeeCriteriaMasterAndDetails FeeCriteriaMasterAndDetailsDTO { get; set; }
        //-----------------------------Fee Criteria Master-----------------------------
         int ID { get; set; }
         string FeeCriteriaDescription { get; set; }
         string FeeCriteriaCode { get; set; }
         short FeeTypeID { get; set; }
         short AccBalanceSheetID { get; set; }
         bool IsActive { get; set; }
         string CentreCode { get; set; }
         int CreatedBy { get; set; }
         DateTime CreatedDate { get; set; }
         int ModifiedBy { get; set; }
         DateTime ModifiedDate { get; set; }
         int DeletedBy { get; set; }
         DateTime DeletedDate { get; set; }
         bool IsDeleted { get; set; }

        //----------------------------Fee Criteria Details -------------------------------

         int FeeCriteriaDetailsID { get; set; }
          string FeeCriteriaParametersName { get; set; }
         int FeeCriteriaParametersID { get; set; }

         string errorMessage { get; set; }
         bool IsFeeCriteriaMasterTransaction { get; set; }
         string AccBalanceSheetName { get; set; }
    }
}
