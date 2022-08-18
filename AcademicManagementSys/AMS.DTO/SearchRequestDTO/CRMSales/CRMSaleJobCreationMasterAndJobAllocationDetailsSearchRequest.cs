using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class CRMSaleJobCreationMasterAndJobAllocationDetailsSearchRequest : Request
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
        public string TransactionDate { get; set; }
        public Int16 CallerJobStatus { get; set; }
        public Int64 JobAllocationOldID { get; set; }


        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~CRMSaleCallMaster Table~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public int CRMSaleCallMasterID { get; set; }
        public Int16 CallStatus { get; set; }
        public string CallAnswerXML { get; set; }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Common Type~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public string SortOrder { get; set; }
        public string SortBy { get; set; }
        public int StartRow { get; set; }
        public int RowLength { get; set; }
        public int EndRow { get; set; }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }



        public string JobType { get; set; }
    }
}
