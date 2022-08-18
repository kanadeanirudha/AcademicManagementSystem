using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryProductionMasterAndTransactionServiceAccess : IInventoryProductionMasterAndTransactionServiceAccess
    {
        IInventoryProductionMasterAndTransactionBA _InventoryProductionMasterAndTransactionBA = null;
        public InventoryProductionMasterAndTransactionServiceAccess()
        {
            _InventoryProductionMasterAndTransactionBA = new InventoryProductionMasterAndTransactionBA();
        }
        public IBaseEntityResponse<InventoryProductionMasterAndTransaction> InsertInventoryProductionMasterAndTransaction(InventoryProductionMasterAndTransaction item)
        {
            return _InventoryProductionMasterAndTransactionBA.InsertInventoryProductionMasterAndTransaction(item);
        }
        public IBaseEntityResponse<InventoryProductionMasterAndTransaction> UpdateInventoryProductionMasterAndTransaction(InventoryProductionMasterAndTransaction item)
        {
            return _InventoryProductionMasterAndTransactionBA.UpdateInventoryProductionMasterAndTransaction(item);
        }
        public IBaseEntityResponse<InventoryProductionMasterAndTransaction> DeleteInventoryProductionMasterAndTransaction(InventoryProductionMasterAndTransaction item)
        {
            return _InventoryProductionMasterAndTransactionBA.DeleteInventoryProductionMasterAndTransaction(item);
        }
        public IBaseEntityCollectionResponse<InventoryProductionMasterAndTransaction> GetBySearch(InventoryProductionMasterAndTransactionSearchRequest searchRequest)
        {
            return _InventoryProductionMasterAndTransactionBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryProductionMasterAndTransaction> GetInventoryProductionMasterAndTransactionSearchList(InventoryProductionMasterAndTransactionSearchRequest searchRequest)
        {
            return _InventoryProductionMasterAndTransactionBA.GetInventoryProductionMasterAndTransactionSearchList(searchRequest);
        }
        public IBaseEntityResponse<InventoryProductionMasterAndTransaction> SelectByID(InventoryProductionMasterAndTransaction item)
        {
            return _InventoryProductionMasterAndTransactionBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<InventoryProductionMasterAndTransaction> SelectIngridentsByVarients(InventoryProductionMasterAndTransactionSearchRequest searchRequest)
        {
            return _InventoryProductionMasterAndTransactionBA.SelectIngridentsByVarients(searchRequest);
        }
        //public IBaseEntityCollectionResponse<InventoryProductionMasterAndTransaction> GetUnitsByItemNumber(InventoryProductionMasterAndTransactionSearchRequest searchRequest)
        //{
        //    return _InventoryProductionMasterAndTransactionBA.GetUnitsByItemNumber(searchRequest);
        //}
    }
}
