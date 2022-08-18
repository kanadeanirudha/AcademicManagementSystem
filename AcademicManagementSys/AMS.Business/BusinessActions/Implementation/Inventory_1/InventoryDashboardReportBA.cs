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
    public class InventoryDashboardReportBA : IInventoryDashboardReportBA
    {
        IInventoryDashboardReportDataProvider InventoryDashboardReportDataProvider;

        private ILogger _logException;

        public InventoryDashboardReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            InventoryDashboardReportDataProvider = new InventoryDashboardReportDataProvider();
        }

        //InventoryDashboardReport

        public IBaseEntityCollectionResponse<InventoryDashboardReport> GetMonthlySaleReport(InventoryDashboardReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryDashboardReport> cRMSaleBillingTransactionCollection = new BaseEntityCollectionResponse<InventoryDashboardReport>();
            try
            {
                if (InventoryDashboardReportDataProvider != null)
                    cRMSaleBillingTransactionCollection = InventoryDashboardReportDataProvider.GetMonthlySaleReport(searchRequest);
                else
                {
                    cRMSaleBillingTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    cRMSaleBillingTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                cRMSaleBillingTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                cRMSaleBillingTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return cRMSaleBillingTransactionCollection;
        }


        public IBaseEntityCollectionResponse<InventoryDashboardReport> GetDailySaleReport(InventoryDashboardReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryDashboardReport> cRMSaleBillingTransactionCollection = new BaseEntityCollectionResponse<InventoryDashboardReport>();
            try
            {
                if (InventoryDashboardReportDataProvider != null)
                    cRMSaleBillingTransactionCollection = InventoryDashboardReportDataProvider.GetDailySaleReport(searchRequest);
                else
                {
                    cRMSaleBillingTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    cRMSaleBillingTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                cRMSaleBillingTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                cRMSaleBillingTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return cRMSaleBillingTransactionCollection;
        }


        public IBaseEntityResponse<InventoryDashboardReport> InventoryDashboardReportSparkLineChartReport(InventoryDashboardReport item)
        {
            IBaseEntityResponse<InventoryDashboardReport> entityResponse = new BaseEntityResponse<InventoryDashboardReport>();
            try
            {
                entityResponse = InventoryDashboardReportDataProvider.InventoryDashboardReportSparkLineChartReport(item);
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }

        public IBaseEntityCollectionResponse<InventoryDashboardReport> GetTotalSaleAndPromotionReport(InventoryDashboardReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryDashboardReport> cRMSaleBillingTransactionCollection = new BaseEntityCollectionResponse<InventoryDashboardReport>();
            try
            {
                if (InventoryDashboardReportDataProvider != null)
                    cRMSaleBillingTransactionCollection = InventoryDashboardReportDataProvider.GetTotalSaleAndPromotionReport(searchRequest);
                else
                {
                    cRMSaleBillingTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    cRMSaleBillingTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                cRMSaleBillingTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                cRMSaleBillingTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return cRMSaleBillingTransactionCollection;
        }

        public IBaseEntityCollectionResponse<InventoryDashboardReport> GetTopFivePromotionReport(InventoryDashboardReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryDashboardReport> cRMSaleBillingTransactionCollection = new BaseEntityCollectionResponse<InventoryDashboardReport>();
            try
            {
                if (InventoryDashboardReportDataProvider != null)
                    cRMSaleBillingTransactionCollection = InventoryDashboardReportDataProvider.GetTopFivePromotionReport(searchRequest);
                else
                {
                    cRMSaleBillingTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    cRMSaleBillingTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                cRMSaleBillingTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                cRMSaleBillingTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return cRMSaleBillingTransactionCollection;
        }

        public IBaseEntityCollectionResponse<InventoryDashboardReport> GetFineDineTakeAwayPieChartReport(InventoryDashboardReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryDashboardReport> cRMSaleBillingTransactionCollection = new BaseEntityCollectionResponse<InventoryDashboardReport>();
            try
            {
                if (InventoryDashboardReportDataProvider != null)
                    cRMSaleBillingTransactionCollection = InventoryDashboardReportDataProvider.GetFineDineTakeAwayPieChartReport(searchRequest);
                else
                {
                    cRMSaleBillingTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    cRMSaleBillingTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                cRMSaleBillingTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                cRMSaleBillingTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return cRMSaleBillingTransactionCollection;
        }

        public IBaseEntityResponse<InventoryDashboardReport> InventoryDashboardStockAmountSparkLineChartReportForCafe(InventoryDashboardReport item)
        {
            IBaseEntityResponse<InventoryDashboardReport> entityResponse = new BaseEntityResponse<InventoryDashboardReport>();
            try
            {
                entityResponse = InventoryDashboardReportDataProvider.InventoryDashboardStockAmountSparkLineChartReportForCafe(item);
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }

        public IBaseEntityResponse<InventoryDashboardReport> InventoryDashboardStockAmountSparkLineChartReportForRetail(InventoryDashboardReport item)
        {
            IBaseEntityResponse<InventoryDashboardReport> entityResponse = new BaseEntityResponse<InventoryDashboardReport>();
            try
            {
                entityResponse = InventoryDashboardReportDataProvider.InventoryDashboardStockAmountSparkLineChartReportForRetail(item);
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }
    }
}
