using AMS.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AMS.DTO
{
    public class AccountCentreWiseBalanceSheetReport: BaseDTO
    {
        public int AccBalsheetTypeID { get; set; }
        public string CentreName { get; set; }
        public string CentreCode { get; set; }
        public string CentreSpecialization { get; set; }
        public string AccBalsheetCode { get; set; }
        public string AccBalsheetHeadDesc { get; set; }
        public string AccBalsheetTypeCode { get; set; }
        public string AccBalsheetTypeDesc { get; set; }
        
    }
}
