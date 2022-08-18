using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryOpeningBalanceServiceAccess : IInventoryOpeningBalanceServiceAccess
    {
        IInventoryOpeningBalanceBA _InventoryOpeningBalanceBA = null;
        public InventoryOpeningBalanceServiceAccess()
        {
            _InventoryOpeningBalanceBA = new InventoryOpeningBalanceBA();
        }
        public IBaseEntityResponse<InventoryOpeningBalance> InsertInventoryOpeningBalance(InventoryOpeningBalance item)
        {
            return _InventoryOpeningBalanceBA.InsertInventoryOpeningBalance(item);
        }
        public IBaseEntityResponse<InventoryOpeningBalance> UpdateInventoryOpeningBalance(InventoryOpeningBalance item)
        {
            return _InventoryOpeningBalanceBA.UpdateInventoryOpeningBalance(item);
        }
        public IBaseEntityResponse<InventoryOpeningBalance> DeleteInventoryOpeningBalance(InventoryOpeningBalance item)
        {
            return _InventoryOpeningBalanceBA.DeleteInventoryOpeningBalance(item);
        }
        public IBaseEntityCollectionResponse<InventoryOpeningBalance> GetBySearch(InventoryOpeningBalanceSearchRequest searchRequest)
        {
            return _InventoryOpeningBalanceBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryOpeningBalance> GetInventoryOpeningBalanceList(InventoryOpeningBalanceSearchRequest searchRequest)
        {
            return _InventoryOpeningBalanceBA.GetInventoryOpeningBalanceList(searchRequest);
        }
        public IBaseEntityResponse<InventoryOpeningBalance> SelectByID(InventoryOpeningBalance item)
        {
            return _InventoryOpeningBalanceBA.SelectByID(item);
        }
    }
}
