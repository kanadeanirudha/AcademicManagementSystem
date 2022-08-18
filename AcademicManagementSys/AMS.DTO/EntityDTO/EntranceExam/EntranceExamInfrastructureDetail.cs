using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class EntranceExamInfrastructureDetail : BaseDTO
    {
        // EntranceExamAvailableCentres Table Property. 
        public int EntranceExamAvailableCentresID { get; set; }         // this ID is Foreign Key of EntranceExamInfrastructureDetail Table.
        public string CentreName { get; set; }
        public int GenLocationID { get; set; }
        public string LocationAddress { get; set; }
        public int TotalRoom { get; set; }
        public string Address { get; set; }
        public string ActiveFrom { get; set; }
        public string ActiveUpto { get; set; }
        

        // EntranceExamInfrastructureDetail Table Property.
        public int EntranceExamInfrastructureDetailID { get; set; }
       // public int EntranceExamAvailbleCentreID { get; set; }
        public string RoomName { get; set; }
        public int RoomNumber { get; set; }
        public string ExtraDescription { get; set; }
        public int RoomCapacity { get; set; }
        public bool IsActive { get; set; }

        //Common Property.
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set;}
        public DateTime? ModifiedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string errorMessage { get; set; }
    }
}
