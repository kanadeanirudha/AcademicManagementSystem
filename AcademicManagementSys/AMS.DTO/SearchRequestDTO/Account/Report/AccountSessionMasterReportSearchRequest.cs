using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class AccountSessionMasterReportSearchRequest : Request
    {
        public Int16 ID
        {
            get;
            set;
        }

        public bool IsActive
        {
            get;
            set;
        }
     
    }
}

