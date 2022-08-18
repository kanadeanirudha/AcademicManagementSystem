using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryDatewiseItemTransactionServiceAccess : IInventoryDatewiseItemTransactionServiceAccess
    {
		IInventoryDatewiseItemTransactionBA _InventoryDatewiseItemTransactionBA = null;
		public InventoryDatewiseItemTransactionServiceAccess()
		{
			_InventoryDatewiseItemTransactionBA = new InventoryDatewiseItemTransactionBA();
		}
		public IBaseEntityResponse<InventoryDatewiseItemTransaction> InsertInventoryDatewiseItemTransaction(InventoryDatewiseItemTransaction item)
		{
			return _InventoryDatewiseItemTransactionBA.InsertInventoryDatewiseItemTransaction(item);
		}
		public IBaseEntityResponse<InventoryDatewiseItemTransaction> UpdateInventoryDatewiseItemTransaction(InventoryDatewiseItemTransaction item)
		{
			return _InventoryDatewiseItemTransactionBA.UpdateInventoryDatewiseItemTransaction(item);
		}
		public IBaseEntityResponse<InventoryDatewiseItemTransaction> DeleteInventoryDatewiseItemTransaction(InventoryDatewiseItemTransaction item)
		{
			return _InventoryDatewiseItemTransactionBA.DeleteInventoryDatewiseItemTransaction(item);
		}
		public IBaseEntityCollectionResponse<InventoryDatewiseItemTransaction> GetBySearch(InventoryDatewiseItemTransactionSearchRequest searchRequest)
		{
			return _InventoryDatewiseItemTransactionBA.GetBySearch(searchRequest);
		}
        public IBaseEntityCollectionResponse<InventoryDatewiseItemTransaction> GetInventoryItemSearchList(InventoryDatewiseItemTransactionSearchRequest searchRequest)
        {
            return _InventoryDatewiseItemTransactionBA.GetInventoryItemSearchList(searchRequest);
        }
		public IBaseEntityResponse<InventoryDatewiseItemTransaction> SelectByID(InventoryDatewiseItemTransaction item)
		{
			return _InventoryDatewiseItemTransactionBA.SelectByID(item);
		}
    }
}
