using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class AccountCentreWiseBalanceSheetReportSearchRequest : Request
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

