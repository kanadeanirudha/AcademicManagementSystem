using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class GeneralTimeZoneMaster : BaseDTO
    {
        public Int32 ID { get; set; }
        public string TimeZone { get; set; }
        public string Coordinates { get; set; }
        public string CountryCode { get; set; }
        public string Comments { get; set; }
        public string UTCoffset { get; set; }
        public string UTCDSToffset { get; set; }
        public string Notes { get; set; }
        public Int32 CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public Int32 ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public Int32 DeletedBy { get; set; }
        public string DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool Flag { get; set; }
        public string LastSyncDate { get; set; }
        
    }
}
