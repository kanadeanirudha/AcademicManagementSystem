using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IInventoryWeighingDataDataProvider
    {
        IBaseEntityResponse<InventoryWeighingData> InsertInventoryWeighingData(InventoryWeighingData item);
        IBaseEntityResponse<InventoryWeighingData> UpdateInventoryWeighingData(InventoryWeighingData item);
        IBaseEntityResponse<InventoryWeighingData> DeleteInventoryWeighingData(InventoryWeighingData item);
        IBaseEntityCollectionResponse<InventoryWeighingData> GetInventoryWeighingDataBySearch(InventoryWeighingDataSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryWeighingData> GetInventoryItemSearchList(InventoryWeighingDataSearchRequest searchRequest);
        IBaseEntityResponse<InventoryWeighingData> GetInventoryWeighingDataByID(InventoryWeighingData item);
    }
}
