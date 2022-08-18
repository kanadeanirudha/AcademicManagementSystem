using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IInventorySalesMasterAndTransactionBA
    {
        IBaseEntityResponse<InventorySalesMasterAndTransaction> InsertInventorySalesMasterAndTransaction(InventorySalesMasterAndTransaction item);
        IBaseEntityResponse<InventorySalesMasterAndTransaction> InsertInventoryHoldBill(InventorySalesMasterAndTransaction item);
        IBaseEntityResponse<InventorySalesMasterAndTransaction> UpdateInventorySalesMasterAndTransaction(InventorySalesMasterAndTransaction item);
        IBaseEntityResponse<InventorySalesMasterAndTransaction> DeleteInventorySalesMasterAndTransaction(InventorySalesMasterAndTransaction item);
        IBaseEntityCollectionResponse<InventorySalesMasterAndTransaction> GetBySearch(InventorySalesMasterAndTransactionSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventorySalesMasterAndTransaction> GetBillDetailsByID(InventorySalesMasterAndTransactionSearchRequest searchRequest);
        IBaseEntityResponse<InventorySalesMasterAndTransaction> SelectByID(InventorySalesMasterAndTransaction item);
        IBaseEntityResponse<InventorySalesMasterAndTransaction> SelectHoldBillCount(InventorySalesMasterAndTransaction item);
        IBaseEntityResponse<InventorySalesMasterAndTransaction> GetInventoryItemQuantity(InventorySalesMasterAndTransaction item);
        IBaseEntityCollectionResponse<InventorySalesMasterAndTransaction> GetInventorySalesMasterAndTransactionBillPrintList(InventorySalesMasterAndTransactionSearchRequest searchRequest);
        
        //For Inventory Sale Report To operator
        IBaseEntityCollectionResponse<InventorySalesMasterAndTransaction> GetInventorySalesReportToOperator(InventorySalesMasterAndTransactionSearchRequest searchRequest);

        IBaseEntityResponse<InventorySalesMasterAndTransaction> CheckFocusOnAction(InventorySalesMasterAndTransaction item);
    }
}
