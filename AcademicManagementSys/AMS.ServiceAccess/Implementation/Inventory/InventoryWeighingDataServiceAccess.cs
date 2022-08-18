using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryWeighingDataServiceAccess : IInventoryWeighingDataServiceAccess
    {
        IInventoryWeighingDataBA _InventoryWeighingDataBA = null;
        public InventoryWeighingDataServiceAccess()
        {
            _InventoryWeighingDataBA = new InventoryWeighingDataBA();
        }
        public IBaseEntityResponse<InventoryWeighingData> InsertInventoryWeighingData(InventoryWeighingData item)
        {
            return _InventoryWeighingDataBA.InsertInventoryWeighingData(item);
        }
        public IBaseEntityResponse<InventoryWeighingData> UpdateInventoryWeighingData(InventoryWeighingData item)
        {
            return _InventoryWeighingDataBA.UpdateInventoryWeighingData(item);
        }
        public IBaseEntityResponse<InventoryWeighingData> DeleteInventoryWeighingData(InventoryWeighingData item)
        {
            return _InventoryWeighingDataBA.DeleteInventoryWeighingData(item);
        }
        public IBaseEntityCollectionResponse<InventoryWeighingData> GetBySearch(InventoryWeighingDataSearchRequest searchRequest)
        {
            return _InventoryWeighingDataBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryWeighingData> GetInventoryItemSearchList(InventoryWeighingDataSearchRequest searchRequest)
        {
            return _InventoryWeighingDataBA.GetInventoryItemSearchList(searchRequest);
        }
        public IBaseEntityResponse<InventoryWeighingData> SelectByID(InventoryWeighingData item)
        {
            return _InventoryWeighingDataBA.SelectByID(item);
        }
    }
}
