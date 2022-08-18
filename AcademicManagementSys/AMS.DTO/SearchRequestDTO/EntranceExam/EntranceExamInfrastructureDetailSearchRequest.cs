using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class EntranceExamInfrastructureDetailSearchRequest : Request
    {
        // EntranceExamAvailableCentres Table Property. 
        public int ID { get; set; }         // this ID is Foreign Key of EntranceExamInfrastructureDetail Table.
        public string CentreName { get; set; }
        public int GenLocationID { get; set; }
        public int TotalRoom { get; set; }
        public string Address { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime ActiveUpto { get; set; }
        public string EntranceExamAvailableCentresSearchWord { get; set; }

        // EntranceExamInfrastructureDetail Table Property.
        public int EntranceExamInfrastructureDetailID { get; set; }
        public int EntranceExamAvailbleCentreID { get; set; }        
        public string RoomName { get; set; }
        public int RoomNumber { get; set; }
        public string ExtraDescription { get; set; }
        public int RoomCapacity { get; set; }
        public string EntranceExamInfrastructureDetailSearchWord { get; set; }

        //Common Property.
        public string SortOrder { get; set; }
        public string SortBy { get; set; }
        public int StartRow { get; set; }
        public int RowLength { get; set; }
        public int EndRow { get; set; }

        //Extra Property.
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
    }
}
