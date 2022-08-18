using AMS.Base.DTO;
using AMS.Business.BusinessRules;
using AMS.Common;
using AMS.DataProvider;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public class InventoryReportBA : IInventoryReportBA
    {
          IInventoryReportDataProvider _InventoryReportDataProvider;
        private ILogger _logException;
        public InventoryReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryReportDataProvider = new InventoryReportDataProvider();
        }

        public IBaseEntityCollectionResponse<InventoryReport> GetInventoryReportBySearch_PriceList(InventoryReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryReport> InventoryReportCollection = new BaseEntityCollectionResponse<InventoryReport>();
            try
            {
                if (_InventoryReportDataProvider != null)
                    InventoryReportCollection = _InventoryReportDataProvider.GetInventoryReportBySearch_PriceList(searchRequest);
                else
                {
                    InventoryReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryReportCollection;
        }
       //Item Master Missing Exaception Report
        public IBaseEntityCollectionResponse<InventoryReport> GetInventoryReportBySearch_ItemList(InventoryReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryReport> InventoryReportCollection = new BaseEntityCollectionResponse<InventoryReport>();
            try
            {
                if (_InventoryReportDataProvider != null)
                    InventoryReportCollection = _InventoryReportDataProvider.GetInventoryReportBySearch_ItemList(searchRequest);
                else
                {
                    InventoryReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryReportCollection;
        }
        //for Inventory Article Expiry  Report
        public IBaseEntityCollectionResponse<InventoryReport> GetInventoryReportBySearch_ArticleList(InventoryReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryReport> InventoryReportCollection = new BaseEntityCollectionResponse<InventoryReport>();
            try
            {
                if (_InventoryReportDataProvider != null)
                    InventoryReportCollection = _InventoryReportDataProvider.GetInventoryReportBySearch_ArticleList(searchRequest);
                else
                {
                    InventoryReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryReportCollection;
        }
    }
}
