using AMS.Base.DTO;

namespace AMS.DTO
{
    public class GetIngredientsListSearchRequest : Request
    {
      
        public int GeneralUnitsID
        {
            get;
            set;
        }
        public string DeviceToken
        {
            get;
            set;
        }
        public int InventoryVariationMasterID
        {
            get;
            set;
        }
    }
}
