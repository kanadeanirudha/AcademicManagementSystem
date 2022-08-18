using AMS.Base.DTO;

namespace AMS.DTO
{
    public class InventoryStoreBillingPrintingInfoSearchRequest : Request
    {
       
        public int GeneralUnitsID
        {
            get;
            set;
        }
        public string LastSyncDate
        {
            get;
            set;
        }
    }
}

