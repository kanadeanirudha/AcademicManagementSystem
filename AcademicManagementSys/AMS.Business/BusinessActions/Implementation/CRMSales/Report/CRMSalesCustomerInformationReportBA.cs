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
    public class CRMSalesCustomerInformationReportBA : ICRMSalesCustomerInformationReportBA
    {
          ICRMSalesCustomerInformationReportDataProvider _CRMSalesCustomerInformationReportDataProvider;
        private ILogger _logException;
        public CRMSalesCustomerInformationReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _CRMSalesCustomerInformationReportDataProvider = new CRMSalesCustomerInformationReportDataProvider();
        }

        public IBaseEntityCollectionResponse<CRMSalesCustomerInformationReport> GetCRMSalesCustomerInformationReportBySearch_Account(CRMSalesCustomerInformationReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSalesCustomerInformationReport> CRMSalesCustomerInformationReportCollection = new BaseEntityCollectionResponse<CRMSalesCustomerInformationReport>();
            try
            {
                if (_CRMSalesCustomerInformationReportDataProvider != null)
                    CRMSalesCustomerInformationReportCollection = _CRMSalesCustomerInformationReportDataProvider.GetCRMSalesCustomerInformationReportBySearch_Account(searchRequest);
                else
                {
                    CRMSalesCustomerInformationReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMSalesCustomerInformationReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMSalesCustomerInformationReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMSalesCustomerInformationReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMSalesCustomerInformationReportCollection;
        }
       
    }
}
