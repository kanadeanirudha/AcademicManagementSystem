using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IInventoryLocationMaster_1DataProvider
    {
        IBaseEntityResponse<InventoryLocationMaster_1> InsertInventoryLocationMaster_1(InventoryLocationMaster_1 item);
        IBaseEntityResponse<InventoryLocationMaster_1> UpdateInventoryLocationMaster_1(InventoryLocationMaster_1 item);
        IBaseEntityResponse<InventoryLocationMaster_1> DeleteInventoryLocationMaster_1(InventoryLocationMaster_1 item);
        IBaseEntityCollectionResponse<InventoryLocationMaster_1> GetInventoryLocationMaster_1BySearch(InventoryLocationMaster_1SearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryLocationMaster_1> GetInventoryLocationMaster_1List(InventoryLocationMaster_1SearchRequest searchRequest);
        IBaseEntityResponse<InventoryLocationMaster_1> GetInventoryLocationMaster_1ByID(InventoryLocationMaster_1 item);
        IBaseEntityCollectionResponse<InventoryLocationMaster_1> GetInventoryLocationMasterSearchList(InventoryLocationMaster_1SearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryLocationMaster_1> GetInventoryLocationMasterlistCenterCodeWise(InventoryLocationMaster_1SearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryLocationMaster_1> GetInventoryLocationMasterlistByAdminRole(InventoryLocationMaster_1SearchRequest searchRequest); 
    }
}
