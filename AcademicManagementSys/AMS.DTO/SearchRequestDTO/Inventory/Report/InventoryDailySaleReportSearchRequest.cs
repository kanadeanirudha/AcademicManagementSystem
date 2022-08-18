using AMS.Base.DTO;

namespace AMS.DTO
{
    public class InventoryDailySaleReportSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public string FromDate { get; set; }
        public string UptoDate { get; set; }
        public int BalanceSheetID { get; set; }
    }
}