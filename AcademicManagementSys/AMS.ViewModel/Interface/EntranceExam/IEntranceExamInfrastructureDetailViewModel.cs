using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IEntranceExamInfrastructureDetailViewModel
    {
        EntranceExamInfrastructureDetail EntranceExamInfrastructureDetailDTO { get; set; }

        // EntranceExamAvailableCentres Table Property. 
        int EntranceExamAvailableCentresID { get; set; }         
        string CentreName { get; set; }
        int GenLocationID { get; set; }
        int TotalRoom { get; set; }
        string Address { get; set; }
        string ActiveFrom { get; set; }
        string ActiveUpto { get; set; }

        // EntranceExamInfrastructureDetail Table Property.
        int EntranceExamInfrastructureDetailID { get; set; }
       // int EntranceExamAvailbleCentreID { get; set; }
        string RoomName { get; set; }
        int RoomNumber { get; set; }
        string ExtraDescription { get; set; }
        int RoomCapacity { get; set; }

        bool IsDeleted { get; set; }
        int CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        Nullable<int> ModifiedBy { get; set; }
        Nullable<DateTime> ModifiedDate { get; set; }
        Nullable<int> DeletedBy { get; set; }
        Nullable<DateTime> DeletedDate { get; set; }
    }
}
