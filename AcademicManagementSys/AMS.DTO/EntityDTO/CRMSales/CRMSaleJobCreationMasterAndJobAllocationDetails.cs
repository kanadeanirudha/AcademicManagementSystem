using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class CRMSaleJobCreationMasterAndJobAllocationDetails : BaseDTO
    {
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~CRMSaleJobCreationMaster Table ~~~~~~~~~~~~~~~~~~~~~~
        public int CRMSaleJobCreationMasterID { get; set; }
        public string JobName { get; set; }
        public string JobCode { get; set; }
        public string JobStartDate { get; set; }
        public string JobEndDate { get; set; }
        public Int16 CallTypeID { get; set; }
        public Int16 JobAllocationStatus { get; set; }


        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~CRMSaleJobCreationAllocation Table~~~~~~~~~~~~~~~~~~~~~~~
        public int CRMSaleJobCreationAllocationID { get; set; }
        public int CallEnquiryMasterID { get; set; }
        public int AdminRoleMasterID { get; set; }
        public int EmployeeID { get; set; }
        public string TransactionaDate { get; set; }
        public Int16 CallerJobStatus { get; set; }
        public Int64 JobAllocationOldID { get; set; }


        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~CRMSaleCallMaster Table~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public int CRMSaleCallMasterID { get; set; }
        public string TransactionDate { get; set; }
        public Int16 CallStatus { get; set; }
        public string CallAnswerXML { get; set; }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~Common Property~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string errorMessage { get; set; }
    }
}
