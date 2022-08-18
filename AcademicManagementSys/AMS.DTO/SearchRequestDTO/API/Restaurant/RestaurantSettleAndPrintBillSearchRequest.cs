using AMS.Base.DTO;

namespace AMS.DTO
{
    public class RestaurantSettleAndPrintBillSearchRequest : Request
    {
        public int InventorySaleMasterID { get; set; }
        public int RestaurantTableOrderID { get; set; }
        public int GeneralUnitsID { get; set; }
        public string BillNumber { get; set; }
        public int CounterID { get; set; }
        public int PaidUnpaidFlag { get; set; }
    }
}

