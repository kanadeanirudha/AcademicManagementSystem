﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IInventoryPurchaseMasterAndTransactionDataProvider
	{
		IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> InsertInventoryPurchaseMasterAndTransaction(InventoryPurchaseMasterAndTransaction item);
		IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> UpdateInventoryPurchaseMasterAndTransaction(InventoryPurchaseMasterAndTransaction item);
		IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> DeleteInventoryPurchaseMasterAndTransaction(InventoryPurchaseMasterAndTransaction item);
		IBaseEntityCollectionResponse<InventoryPurchaseMasterAndTransaction> GetInventoryPurchaseMasterAndTransactionBySearch(InventoryPurchaseMasterAndTransactionSearchRequest searchRequest);
		IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> GetInventoryPurchaseMasterAndTransactionByID(InventoryPurchaseMasterAndTransaction item);
        IBaseEntityCollectionResponse<InventoryPurchaseMasterAndTransaction> GetPurchaseMasterAndTransaction(InventoryPurchaseMasterAndTransactionSearchRequest searchRequest);
        IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> CheckFocusOnAction(InventoryPurchaseMasterAndTransaction item);
	}
}

