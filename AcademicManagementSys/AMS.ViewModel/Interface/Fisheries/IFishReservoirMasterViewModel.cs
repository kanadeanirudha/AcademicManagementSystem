using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IFishReservoirMasterViewModel
    {
        FishReservoirMaster FishReservoirMasterDTO { get; set; }
        int ID { get; set; }
        string ReservoirName { get; set; }
        string ReservoirCode { get; set; }
        string Address { get; set; }
        int LocationId { get; set; }
        decimal Latitude { get; set; }
        decimal Logitude { get; set; }
        decimal Area { get; set; }
        decimal MinProductCapacity { get; set; }

        bool IsDeleted { get; set; }
        Nullable<int> CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        Nullable<int> ModifiedBy { get; set; }
        Nullable<DateTime> ModifiedDate { get; set; }
        Nullable<int> DeletedBy { get; set; }
        Nullable<DateTime> DeletedDate { get; set; }

        int BalancesheetID { get; set; }
        string BalancesheetName { get; set; }
    }
}
