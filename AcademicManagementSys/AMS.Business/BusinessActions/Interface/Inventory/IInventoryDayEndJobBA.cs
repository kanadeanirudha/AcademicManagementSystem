using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IInventoryDayEndJobBA
    {
        IBaseEntityResponse<InventoryDayEndJob> InsertInventoryDayEndJob(InventoryDayEndJob item);
        IBaseEntityResponse<InventoryDayEndJob> UpdateInventoryDayEndJob(InventoryDayEndJob item);
        IBaseEntityResponse<InventoryDayEndJob> DeleteInventoryDayEndJob(InventoryDayEndJob item);
        IBaseEntityCollectionResponse<InventoryDayEndJob> GetBySearch(InventoryDayEndJobSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryDayEndJob> GetInventoryDayEndJobList(InventoryDayEndJobSearchRequest searchRequest);
        IBaseEntityResponse<InventoryDayEndJob> SelectByID(InventoryDayEndJob item);
        IBaseEntityResponse<InventoryDayEndJob> GetDayEndJob(InventoryDayEndJob item);
        IBaseEntityResponse<InventoryDayEndJob> GetTimeZone(InventoryDayEndJob item);
    }
}
