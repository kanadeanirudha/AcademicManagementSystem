using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class Sync : BaseDTO
    {
        public int ID { get; set; }
        public int CreatedBy { get; set; }
        public string LastSyncDate { get; set; }
        public string SyncType { get; set; }
        public bool IsValidUserCount { get; set; }
        public int BalancesheetID { get; set; }
        public string XmlString { get; set; }
        public string errorMessage { get; set; }
    }
}
