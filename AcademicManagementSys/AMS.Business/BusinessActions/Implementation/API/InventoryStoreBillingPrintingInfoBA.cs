using AMS.Base.DTO;
using AMS.Common;
using AMS.DataProvider;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
namespace AMS.Business.BusinessAction
{
    public class InventoryStoreBillingPrintingInfoBA : IInventoryStoreBillingPrintingInfoBA
    {
        IInventoryStoreBillingPrintingInfoDataProvider _InventoryStoreBillingPrintingInfoDataProvider;
        private ILogger _logException;
        public InventoryStoreBillingPrintingInfoBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryStoreBillingPrintingInfoDataProvider = new InventoryStoreBillingPrintingInfoDataProvider();
        }
        /// <summary>
        /// Create new record of InventoryStoreBillingPrintingInfo.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <summary>
        /// Select all record from InventoryStoreBillingPrintingInfo table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryStoreBillingPrintingInfo> GetInventoryStoreBillingPrintingInfo(InventoryStoreBillingPrintingInfoSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryStoreBillingPrintingInfo> InventoryStoreBillingPrintingInfoCollection = new BaseEntityCollectionResponse<InventoryStoreBillingPrintingInfo>();
            try
            {
                if (_InventoryStoreBillingPrintingInfoDataProvider != null)
                    InventoryStoreBillingPrintingInfoCollection = _InventoryStoreBillingPrintingInfoDataProvider.GetInventoryStoreBillingPrintingInfo(searchRequest);
                else
                {
                    InventoryStoreBillingPrintingInfoCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryStoreBillingPrintingInfoCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryStoreBillingPrintingInfoCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryStoreBillingPrintingInfoCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryStoreBillingPrintingInfoCollection;
        }
    }
}
