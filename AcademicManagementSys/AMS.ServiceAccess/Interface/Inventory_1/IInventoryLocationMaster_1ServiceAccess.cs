using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IInventoryLocationMaster_1ServiceAccess
    {
        IBaseEntityResponse<InventoryLocationMaster_1> InsertInventoryLocationMaster_1(InventoryLocationMaster_1 item);
        IBaseEntityResponse<InventoryLocationMaster_1> UpdateInventoryLocationMaster_1(InventoryLocationMaster_1 item);
        IBaseEntityResponse<InventoryLocationMaster_1> DeleteInventoryLocationMaster_1(InventoryLocationMaster_1 item);
        IBaseEntityCollectionResponse<InventoryLocationMaster_1> GetBySearch(InventoryLocationMaster_1SearchRequest searchRequest);
        IBaseEntityResponse<InventoryLocationMaster_1> SelectByID(InventoryLocationMaster_1 item);
        IBaseEntityCollectionResponse<InventoryLocationMaster_1> GetInventoryLocationMaster_1List(InventoryLocationMaster_1SearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryLocationMaster_1> GetInventoryLocationMasterSearchList(InventoryLocationMaster_1SearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryLocationMaster_1> GetInventoryLocationMasterlistCenterCodeWise(InventoryLocationMaster_1SearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryLocationMaster_1> GetInventoryLocationMasterlistByAdminRole(InventoryLocationMaster_1SearchRequest searchRequest); 
    }
}
