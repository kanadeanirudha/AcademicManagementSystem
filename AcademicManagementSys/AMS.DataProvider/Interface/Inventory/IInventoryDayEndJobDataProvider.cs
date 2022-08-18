using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IInventoryDayEndJobDataProvider
    {
        IBaseEntityResponse<InventoryDayEndJob> InsertInventoryDayEndJob(InventoryDayEndJob item);
        IBaseEntityResponse<InventoryDayEndJob> UpdateInventoryDayEndJob(InventoryDayEndJob item);
        IBaseEntityResponse<InventoryDayEndJob> DeleteInventoryDayEndJob(InventoryDayEndJob item);
        IBaseEntityCollectionResponse<InventoryDayEndJob> GetInventoryDayEndJobBySearch(InventoryDayEndJobSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryDayEndJob> GetInventoryDayEndJobList(InventoryDayEndJobSearchRequest searchRequest);
        IBaseEntityResponse<InventoryDayEndJob> GetInventoryDayEndJobByID(InventoryDayEndJob item);
        IBaseEntityResponse<InventoryDayEndJob> GetDayEndJob(InventoryDayEndJob item);
        IBaseEntityResponse<InventoryDayEndJob> GetTimeZone(InventoryDayEndJob item);
    }
}
