using AMS.Base.DTO;

namespace AMS.DTO
{
    public class SalePromotionGetOfflineSearchRequest : Request
    {

        public int GeneralUnitsID
        {
            get;
            set;
        }
        public string LastSyncDate { get; set; }
    }
}
