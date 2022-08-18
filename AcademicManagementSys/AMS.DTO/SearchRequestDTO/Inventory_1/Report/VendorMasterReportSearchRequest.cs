using System;
using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class VendorMasterReportSearchRequest : BaseDTO
    {
        
        public String  VendorName
        { get; 
          set; 
        }
        public string ContactPerson
        { 
            get; 
            set; 
        }


        public string ReportFor { get; set; }
    }
}


       
       
    
