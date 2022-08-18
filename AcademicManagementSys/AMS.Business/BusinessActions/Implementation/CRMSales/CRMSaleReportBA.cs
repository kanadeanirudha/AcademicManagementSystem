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
    public class CRMSaleReportBA : ICRMSaleReportBA
    {
        ICRMSaleReportDataProvider CRMSaleReportDataProvider;

        private ILogger _logException;

        public CRMSaleReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            CRMSaleReportDataProvider = new CRMSaleReportDataProvider();
        }

        //CRMSaleReport

        public IBaseEntityCollectionResponse<CRMSaleReport> GetCRMSaleTopFiveAccountReport(CRMSaleReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleReport> cRMSaleBillingTransactionCollection = new BaseEntityCollectionResponse<CRMSaleReport>();
            try
            {
                if (CRMSaleReportDataProvider != null)
                    cRMSaleBillingTransactionCollection = CRMSaleReportDataProvider.GetCRMSaleTopFiveAccountReport(searchRequest);
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

        public IBaseEntityCollectionResponse<CRMSaleReport> GetCRMSaleMonthlyRevenueReport(CRMSaleReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleReport> cRMSaleBillingTransactionCollection = new BaseEntityCollectionResponse<CRMSaleReport>();
            try
            {
                if (CRMSaleReportDataProvider != null)
                    cRMSaleBillingTransactionCollection = CRMSaleReportDataProvider.GetCRMSaleMonthlyRevenueReport(searchRequest);
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
        public IBaseEntityCollectionResponse<CRMSaleReport> GetCRMSaleWicklyStatusDetailsInDateRangeReport(CRMSaleReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleReport> cRMSaleBillingTransactionCollection = new BaseEntityCollectionResponse<CRMSaleReport>();
            try
            {
                if (CRMSaleReportDataProvider != null)
                    cRMSaleBillingTransactionCollection = CRMSaleReportDataProvider.GetCRMSaleWicklyStatusDetailsInDateRangeReport(searchRequest);
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

        public IBaseEntityResponse<CRMSaleReport> CRMSaleDashboardSparklineChartsReportByEmployeeID(CRMSaleReport item)
        {
            IBaseEntityResponse<CRMSaleReport> entityResponse = new BaseEntityResponse<CRMSaleReport>();
            try
            {
                entityResponse = CRMSaleReportDataProvider.CRMSaleDashboardSparklineChartsReportByEmployeeID(item);
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

        public IBaseEntityCollectionResponse<CRMSaleReport> GetListTodaysMeetingSchedule(CRMSaleReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleReport> meetingCollection = new BaseEntityCollectionResponse<CRMSaleReport>();
            try
            {
                if (CRMSaleReportDataProvider != null)
                    meetingCollection = CRMSaleReportDataProvider.GetListTodaysMeetingSchedule(searchRequest);
                else
                {
                    meetingCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    meetingCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                meetingCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                meetingCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return meetingCollection;
        }


        public IBaseEntityCollectionResponse<CRMSaleReport> GetListTodaysEnquiryDetails(CRMSaleReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleReport> enquiryCollection = new BaseEntityCollectionResponse<CRMSaleReport>();
            try
            {
                if (CRMSaleReportDataProvider != null)
                    enquiryCollection = CRMSaleReportDataProvider.GetListTodaysEnquiryDetails(searchRequest);
                else
                {
                    enquiryCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    enquiryCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                enquiryCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                enquiryCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return enquiryCollection;
        }

        public IBaseEntityCollectionResponse<CRMSaleReport> GetListSalesCallSchedule(CRMSaleReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleReport> enquiryCollection = new BaseEntityCollectionResponse<CRMSaleReport>();
            try
            {
                if (CRMSaleReportDataProvider != null)
                    enquiryCollection = CRMSaleReportDataProvider.GetListSalesCallSchedule(searchRequest);
                else
                {
                    enquiryCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    enquiryCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                enquiryCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                enquiryCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return enquiryCollection;
        }

        public IBaseEntityCollectionResponse<CRMSaleReport> GetListReminders(CRMSaleReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleReport> enquiryCollection = new BaseEntityCollectionResponse<CRMSaleReport>();
            try
            {
                if (CRMSaleReportDataProvider != null)
                    enquiryCollection = CRMSaleReportDataProvider.GetListReminders(searchRequest);
                else
                {
                    enquiryCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    enquiryCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                enquiryCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                enquiryCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return enquiryCollection;
        }

    }
}
