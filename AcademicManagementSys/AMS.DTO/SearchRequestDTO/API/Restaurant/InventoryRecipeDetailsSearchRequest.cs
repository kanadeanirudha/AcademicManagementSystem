using AMS.Base.DTO;

namespace AMS.DTO
{
    public class InventoryRecipeDetailsSearchRequest : Request
    {
        public int MenuCategoryID { get; set; }
        public int GeneralUnitsID { get; set; }
        public string LastSyncDate { get; set; }
    }
}
