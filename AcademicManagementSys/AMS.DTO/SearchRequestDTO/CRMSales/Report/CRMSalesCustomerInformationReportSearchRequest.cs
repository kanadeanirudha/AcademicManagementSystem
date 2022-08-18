using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class CRMSalesCustomerInformationReportSearchRequest : BaseDTO
    {
        //CRMSaleEnquiryAccountMaster
        public Int32 CRMSaleEnquiryAccountMasterID 
        { get; 
          set; 
        }
        public string AccountName 
        { 
            get; 
            set; 
        }
        public Int16 AccountType
        { 
            get; 
            set; 
        }
        //CRMSaleEnquiryMaster
        public Int64 CRMSaleEnquiryMasterID 
        { get; 
          set;
        }
        public string EnquiryDesription 
        { 
            get; 
            set; 
        }

       
       
    }
}
