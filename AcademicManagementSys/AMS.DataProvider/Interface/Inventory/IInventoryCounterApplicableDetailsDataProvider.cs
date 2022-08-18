using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IInventoryCounterApplicableDetailsDataProvider
    {
        IBaseEntityResponse<InventoryCounterApplicableDetails> InsertInventoryCounterApplicableDetails(InventoryCounterApplicableDetails item);
        IBaseEntityResponse<InventoryCounterApplicableDetails> UpdateInventoryCounterApplicableDetails(InventoryCounterApplicableDetails item);
        IBaseEntityResponse<InventoryCounterApplicableDetails> DeleteInventoryCounterApplicableDetails(InventoryCounterApplicableDetails item);
        IBaseEntityCollectionResponse<InventoryCounterApplicableDetails> GetInventoryCounterApplicableDetailsBySearch(InventoryCounterApplicableDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryCounterApplicableDetails> GetInventoryCounterApplicableDetailsList(InventoryCounterApplicableDetailsSearchRequest searchRequest);
        IBaseEntityResponse<InventoryCounterApplicableDetails> GetInventoryCounterApplicableDetailsByID(InventoryCounterApplicableDetails item);
    }
}
