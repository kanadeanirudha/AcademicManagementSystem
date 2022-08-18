using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface ISyncViewModel
    {
          Sync SyncDTO
        {
            get;
            set;
        }
          int ID { get; set; }
          int CreatedBy { get; set; }
          int BalancesheetID { get; set; }
          bool IsValidUserCount { get; set; }
          string errorMessage { get; set; }
    }
}
