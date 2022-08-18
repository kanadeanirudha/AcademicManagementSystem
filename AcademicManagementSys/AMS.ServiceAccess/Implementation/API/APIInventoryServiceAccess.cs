using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class APIInventoryServiceAccess : IAPIInventoryServiceAccess 
    {
        IAPIInventoryBA _apiInventoryBA = null;

        public APIInventoryServiceAccess()
        {
            _apiInventoryBA = new APIInventoryBA();
        }

        public IBaseEntityResponse<APIInventory> InventoryCounterLogin(APIInventory item)
        {
            return _apiInventoryBA.InventoryCounterLogin(item);
        }
        public IBaseEntityResponse<APIInventory> PostOnline(APIInventory item)
        {
            return _apiInventoryBA.PostOnline(item);
        }
        public IBaseEntityResponse<APIInventory> SingleBillPostOnline(APIInventory item)
        {
            return _apiInventoryBA.SingleBillPostOnline(item);
        }
        public IBaseEntityResponse<APIInventory> GetLocalInvoiceNo(APIInventory item)
        {
            return _apiInventoryBA.GetLocalInvoiceNo(item);
        }
        public IBaseEntityCollectionResponse<APIInventory> InventoryGetOnline(APIInventorySearchRequest searchRequest)
        {
            return _apiInventoryBA.InventoryGetOnline(searchRequest);
        }
        public IBaseEntityResponse<APIInventory> PostSaleReturnOnline(APIInventory item)
        {
            return _apiInventoryBA.PostSaleReturnOnline(item);
        }
    }
}
