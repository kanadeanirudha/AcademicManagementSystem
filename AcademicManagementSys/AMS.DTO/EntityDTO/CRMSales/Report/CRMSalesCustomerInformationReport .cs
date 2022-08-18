using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class CRMSalesCustomerInformationReport : BaseDTO
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

        //CRMSaleJobUserJobScheduleSheet
        public Int64 CRMJobUserJobScheduleParentID 
        { 
            get; 
            set; 
        }
        public string ScheduleDescription 
        { 
            get; 
            set;
        }
        public string FromTime 
        { 
            get; 
            set; 
        }
        public string UpToTime 
        { 
            get; 
            set; 
        }
        //Other Fields
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; } 
        public string MobileNumber { get; set; }
        public string ContactPersonName { get; set; }
        public string EmailId { get; set; }
		public string City { get; set; }	
	    public string Country { get; set; }
        public string IsVisitingCardUploaded { get; set; }
    }
}
