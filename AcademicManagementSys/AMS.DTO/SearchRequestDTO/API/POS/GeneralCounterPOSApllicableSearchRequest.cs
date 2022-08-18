using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class GeneralCounterPOSApllicableSearchRequest : Request
    {
        public Int32 ID { get; set; }
        public Int16 GeneralUnitsID { get; set; }
        public Int16 GeneralCounterMasterID { get; set; }
        public Int16 GeneralPOSMasterID { get; set; }
        public string SortBy { get; set; }
        public int StartRow { get; set; }
        public int EndRow { get; set; }
        public string LastSyncDate { get; set; }
        public string DeviceCode { get; set; }
        
    }
}
