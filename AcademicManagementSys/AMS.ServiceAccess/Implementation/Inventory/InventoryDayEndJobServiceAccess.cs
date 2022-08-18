using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryDayEndJobServiceAccess : IInventoryDayEndJobServiceAccess
    {
        IInventoryDayEndJobBA _InventoryDayEndJobBA = null;
        public InventoryDayEndJobServiceAccess()
        {
            _InventoryDayEndJobBA = new InventoryDayEndJobBA();
        }
        public IBaseEntityResponse<InventoryDayEndJob> InsertInventoryDayEndJob(InventoryDayEndJob item)
        {
            return _InventoryDayEndJobBA.InsertInventoryDayEndJob(item);
        }
        public IBaseEntityResponse<InventoryDayEndJob> UpdateInventoryDayEndJob(InventoryDayEndJob item)
        {
            return _InventoryDayEndJobBA.UpdateInventoryDayEndJob(item);
        }
        public IBaseEntityResponse<InventoryDayEndJob> DeleteInventoryDayEndJob(InventoryDayEndJob item)
        {
            return _InventoryDayEndJobBA.DeleteInventoryDayEndJob(item);
        }
        public IBaseEntityCollectionResponse<InventoryDayEndJob> GetBySearch(InventoryDayEndJobSearchRequest searchRequest)
        {
            return _InventoryDayEndJobBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryDayEndJob> GetInventoryDayEndJobList(InventoryDayEndJobSearchRequest searchRequest)
        {
            return _InventoryDayEndJobBA.GetInventoryDayEndJobList(searchRequest);
        }
        public IBaseEntityResponse<InventoryDayEndJob> SelectByID(InventoryDayEndJob item)
        {
            return _InventoryDayEndJobBA.SelectByID(item);
        }
        public IBaseEntityResponse<InventoryDayEndJob> GetDayEndJob(InventoryDayEndJob item)
        {
            return _InventoryDayEndJobBA.GetDayEndJob(item);
        }
        public IBaseEntityResponse<InventoryDayEndJob> GetTimeZone(InventoryDayEndJob item)
        {
            return _InventoryDayEndJobBA.GetTimeZone(item);
        }
    }
}
