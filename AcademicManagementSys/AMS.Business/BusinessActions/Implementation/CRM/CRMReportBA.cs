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
    public class CRMReportBA : ICRMReportBA
    {
        ICRMReportDataProvider CRMReportDataProvider;

        private ILogger _logException;

        public CRMReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            CRMReportDataProvider = new CRMReportDataProvider();
        }

        //CRMReport

        public IBaseEntityCollectionResponse<CRMReport> GetConvertedCallDetails(CRMReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMReport> ConvertedCallCollection = new BaseEntityCollectionResponse<CRMReport>();
            try
            {
                if (CRMReportDataProvider != null)
                    ConvertedCallCollection = CRMReportDataProvider.GetConvertedCallDetails(searchRequest);
                else
                {
                    ConvertedCallCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ConvertedCallCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ConvertedCallCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ConvertedCallCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ConvertedCallCollection;
        }
        public IBaseEntityCollectionResponse<CRMReport> GetCRMConversionReport(CRMReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMReport> ConversionReportCollection = new BaseEntityCollectionResponse<CRMReport>();
            try
            {
                if (CRMReportDataProvider != null)
                    ConversionReportCollection = CRMReportDataProvider.GetCRMConversionReport(searchRequest);
                else
                {
                    ConversionReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ConversionReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ConversionReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ConversionReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ConversionReportCollection;
        }

        public IBaseEntityCollectionResponse<CRMReport> GetCRMCallAverageDetails(CRMReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMReport> AverageCollection = new BaseEntityCollectionResponse<CRMReport>();
            try
            {
                if (CRMReportDataProvider != null)
                    AverageCollection = CRMReportDataProvider.GetCRMCallAverageDetails(searchRequest);
                else
                {
                    AverageCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AverageCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AverageCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AverageCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AverageCollection;
        }
        public IBaseEntityCollectionResponse<CRMReport> GetCRMCallbackReport(CRMReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMReport> CallbackReportCollection = new BaseEntityCollectionResponse<CRMReport>();
            try
            {
                if (CRMReportDataProvider != null)
                    CallbackReportCollection = CRMReportDataProvider.GetCRMCallbackReport(searchRequest);
                else
                {
                    CallbackReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CallbackReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CallbackReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CallbackReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CallbackReportCollection;
        }
        public IBaseEntityCollectionResponse<CRMReport> GetCRMWicklyStatusDetailsInDateRangeReport(CRMReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMReport> CRMBillingTransactionCollection = new BaseEntityCollectionResponse<CRMReport>();
            try
            {
                if (CRMReportDataProvider != null)
                    CRMBillingTransactionCollection = CRMReportDataProvider.GetCRMWicklyStatusDetailsInDateRangeReport(searchRequest);
                else
                {
                    CRMBillingTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMBillingTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMBillingTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMBillingTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMBillingTransactionCollection;
        }

        public IBaseEntityCollectionResponse<CRMReport> GetCRMDashboardSparklineChartsReportforPendingCalls(CRMReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMReport> Pendingcollection = new BaseEntityCollectionResponse<CRMReport>();
       
            try
            {
                if (CRMReportDataProvider != null)
                    Pendingcollection = CRMReportDataProvider.GetCRMDashboardSparklineChartsReportforPendingCalls(searchRequest);
                else
                {
                    Pendingcollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    Pendingcollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                Pendingcollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                Pendingcollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return Pendingcollection;
        }
        public IBaseEntityCollectionResponse<CRMReport> GetCRMTotalAllocatedCall(CRMReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMReport> TotalAllocatedCallcollection = new BaseEntityCollectionResponse<CRMReport>();

            try
            {
                if (CRMReportDataProvider != null)
                    TotalAllocatedCallcollection = CRMReportDataProvider.GetCRMTotalAllocatedCall(searchRequest);
                else
                {
                    TotalAllocatedCallcollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    TotalAllocatedCallcollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                TotalAllocatedCallcollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                TotalAllocatedCallcollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return TotalAllocatedCallcollection;
        }
        public IBaseEntityCollectionResponse<CRMReport> GetListTodaysMeetingSchedule(CRMReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMReport> meetingCollection = new BaseEntityCollectionResponse<CRMReport>();
            try
            {
                if (CRMReportDataProvider != null)
                    meetingCollection = CRMReportDataProvider.GetListTodaysMeetingSchedule(searchRequest);
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
 
           public IBaseEntityCollectionResponse<CRMReport> GetCRMDashboardSparklineChartsReportforCallbackCalls(CRMReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMReport> CallbackCallsCollection = new BaseEntityCollectionResponse<CRMReport>();
            try
            {
                if (CRMReportDataProvider != null)
                    CallbackCallsCollection = CRMReportDataProvider.GetCRMDashboardSparklineChartsReportforCallbackCalls(searchRequest);
                else
                {
                    CallbackCallsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CallbackCallsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CallbackCallsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CallbackCallsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CallbackCallsCollection;
        }
           public IBaseEntityCollectionResponse<CRMReport> GetCRMTotalCallbackCall(CRMReportSearchRequest searchRequest)
           {
               IBaseEntityCollectionResponse<CRMReport> TotalCallbackCallCollection = new BaseEntityCollectionResponse<CRMReport>();
               try
               {
                   if (CRMReportDataProvider != null)
                       TotalCallbackCallCollection = CRMReportDataProvider.GetCRMTotalCallbackCall(searchRequest);
                   else
                   {
                       TotalCallbackCallCollection.Message.Add(new MessageDTO
                       {
                           ErrorMessage = Resources.Null_Object_Exception,
                           MessageType = MessageTypeEnum.Error
                       });
                       TotalCallbackCallCollection.CollectionResponse = null;
                   }
               }
               catch (Exception ex)
               {
                   TotalCallbackCallCollection.Message.Add(new MessageDTO
                   {
                       ErrorMessage = ex.Message,
                       MessageType = MessageTypeEnum.Error
                   });
                   TotalCallbackCallCollection.CollectionResponse = null;
                   if (_logException != null)
                   {
                       _logException.Error(ex.Message);
                   }
               }
               return TotalCallbackCallCollection;
           }
        //public IBaseEntityCollectionResponse<CRMReport> GetListTodaysMeetingSchedule(CRMReportSearchRequest searchRequest)
        //{
        //    IBaseEntityCollectionResponse<CRMReport> meetingCollection = new BaseEntityCollectionResponse<CRMReport>();
        //    try
        //    {
        //        if (CRMReportDataProvider != null)
        //            meetingCollection = CRMReportDataProvider.GetListTodaysMeetingSchedule(searchRequest);
        //        else
        //        {
        //            meetingCollection.Message.Add(new MessageDTO
        //            {
        //                ErrorMessage = Resources.Null_Object_Exception,
        //                MessageType = MessageTypeEnum.Error
        //            });
        //            meetingCollection.CollectionResponse = null;ss
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        meetingCollection.Message.Add(new MessageDTO
        //        {
        //            ErrorMessage = ex.Message,
        //            MessageType = MessageTypeEnum.Error
        //        });
        //        meetingCollection.CollectionResponse = null;
        //        if (_logException != null)
        //        {
        //            _logException.Error(ex.Message);
        //        }
        //    }
        //    return meetingCollection;
        //}


        public IBaseEntityCollectionResponse<CRMReport> GetListTodaysEnquiryDetails(CRMReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMReport> enquiryCollection = new BaseEntityCollectionResponse<CRMReport>();
            try
            {
                if (CRMReportDataProvider != null)
                    enquiryCollection = CRMReportDataProvider.GetListTodaysEnquiryDetails(searchRequest);
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

        public IBaseEntityCollectionResponse<CRMReport> GetListSalesCallSchedule(CRMReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMReport> enquiryCollection = new BaseEntityCollectionResponse<CRMReport>();
            try
            {
                if (CRMReportDataProvider != null)
                    enquiryCollection = CRMReportDataProvider.GetListSalesCallSchedule(searchRequest);
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

        public IBaseEntityCollectionResponse<CRMReport> GetListReminders(CRMReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMReport> enquiryCollection = new BaseEntityCollectionResponse<CRMReport>();
            try
            {
                if (CRMReportDataProvider != null)
                    enquiryCollection = CRMReportDataProvider.GetListReminders(searchRequest);
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
