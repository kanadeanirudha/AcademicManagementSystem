
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IInventoryCounterApplicableDetailsBA
    {
        IBaseEntityResponse<InventoryCounterApplicableDetails> InsertInventoryCounterApplicableDetails(InventoryCounterApplicableDetails item);
        IBaseEntityResponse<InventoryCounterApplicableDetails> UpdateInventoryCounterApplicableDetails(InventoryCounterApplicableDetails item);
        IBaseEntityResponse<InventoryCounterApplicableDetails> DeleteInventoryCounterApplicableDetails(InventoryCounterApplicableDetails item);
        IBaseEntityCollectionResponse<InventoryCounterApplicableDetails> GetBySearch(InventoryCounterApplicableDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryCounterApplicableDetails> GetInventoryCounterApplicableDetailsList(InventoryCounterApplicableDetailsSearchRequest searchRequest);
        IBaseEntityResponse<InventoryCounterApplicableDetails> SelectByID(InventoryCounterApplicableDetails item);
    }
}
