using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface ICRMSaleJobCreationMasterAndJobAllocationDetailsViewModel
    {
        CRMSaleJobCreationMasterAndJobAllocationDetails CRMSaleJobCreationMasterAndAllocationDetailsDTO { get; set; }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~CRMSaleJobCreationMaster Table ~~~~~~~~~~~~~~~~~~~~~~
        int CRMSaleJobCreationMasterID { get; set; }
        string JobName { get; set; }
        string JobCode { get; set; }
        string JobStartDate { get; set; }
        string JobEndDate { get; set; }
        Int16 CallTypeID { get; set; }
        Int16 JobAllocationStatus { get; set; }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~CRMSaleJobCreationAllocation Table~~~~~~~~~~~~~~~~~~~~~~~
        int CRMSaleJobCreationAllocationID { get; set; }
        int CallEnquiryMasterID { get; set; }
        int AdminRoleMasterID { get; set; }
        int EmployeeID { get; set; }
        string TransactionDate { get; set; }
        Int16 CallerJobStatus { get; set; }
        Int64 JobAllocationOldID { get; set; }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~CRMSaleCallMaster Table~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        int CRMSaleCallMasterID { get; set; }
        Int16 CallStatus { get; set; }
        string CallAnswerXML { get; set; }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Common Property~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        bool IsDeleted { get; set; }
        int CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        int? ModifiedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
        int? DeletedBy { get; set; }
        DateTime? DeletedDate { get; set; }
        string errorMessage { get; set; }
    }
}
