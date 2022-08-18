using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IInventoryProductionMasterAndTransactionServiceAccess
    {
        IBaseEntityResponse<InventoryProductionMasterAndTransaction> InsertInventoryProductionMasterAndTransaction(InventoryProductionMasterAndTransaction item);
        IBaseEntityResponse<InventoryProductionMasterAndTransaction> UpdateInventoryProductionMasterAndTransaction(InventoryProductionMasterAndTransaction item);
        IBaseEntityResponse<InventoryProductionMasterAndTransaction> DeleteInventoryProductionMasterAndTransaction(InventoryProductionMasterAndTransaction item);
        IBaseEntityCollectionResponse<InventoryProductionMasterAndTransaction> GetBySearch(InventoryProductionMasterAndTransactionSearchRequest searchRequest);
        IBaseEntityResponse<InventoryProductionMasterAndTransaction> SelectByID(InventoryProductionMasterAndTransaction item);
        IBaseEntityCollectionResponse<InventoryProductionMasterAndTransaction> GetInventoryProductionMasterAndTransactionSearchList(InventoryProductionMasterAndTransactionSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryProductionMasterAndTransaction> SelectIngridentsByVarients(InventoryProductionMasterAndTransactionSearchRequest searchRequest);
        //IBaseEntityCollectionResponse<InventoryProductionMasterAndTransaction> GetUnitsByItemNumber(InventoryProductionMasterAndTransactionSearchRequest searchRequest);
    }
}
