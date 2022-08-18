using AMS.DTO;
using System;
namespace AMS.ViewModel
{
    public interface IGeneralTimeZoneMasterViewModel
    {
        GeneralTimeZoneMaster GeneralTimeZoneMasterDTO { get; set; }
        Int32 ID { get; set; }
        string TimeZone { get; set; }
        string Coordinates { get; set; }
        string CountryCode { get; set; }
        string Comments { get; set; }
        string UTCoffset { get; set; }
        string UTCDSToffset { get; set; }
        string Notes { get; set; }
        Int32 CreatedBy { get; set; }
        string CreatedDate { get; set; }
        Int32 ModifiedBy { get; set; }
        string ModifiedDate { get; set; }
        Int32 DeletedBy { get; set; }
        string DeletedDate { get; set; }
        bool IsDeleted { get; set; }
    }
}
