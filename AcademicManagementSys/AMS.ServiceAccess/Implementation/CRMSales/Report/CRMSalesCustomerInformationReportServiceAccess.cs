using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class CRMSalesCustomerInformationReportServiceAccess : ICRMSalesCustomerInformationReportServiceAccess
    {
        ICRMSalesCustomerInformationReportBA _CRMSalesCustomerInformationReportBA = null;
        public CRMSalesCustomerInformationReportServiceAccess()
        {
            _CRMSalesCustomerInformationReportBA = new CRMSalesCustomerInformationReportBA();
        }

        public IBaseEntityCollectionResponse<CRMSalesCustomerInformationReport> GetCRMSalesCustomerInformationReportBySearch_Account(CRMSalesCustomerInformationReportSearchRequest searchRequest)
         {
             return _CRMSalesCustomerInformationReportBA.GetCRMSalesCustomerInformationReportBySearch_Account(searchRequest);
         }
        //public IBaseEntityCollectionResponse<CRMSalesCustomerInformationReport> GetCustomerInformationReportBySearch_Enquiry(CRMSalesCustomerInformationReportSearchRequest searchRequest)
        //{
        //    return _CRMSalesCustomerInformationReportBA.GetCustomerInformationReportBySearch_Enquiry(searchRequest);
        //}
        //public IBaseEntityCollectionResponse<CRMSalesCustomerInformationReport> GetCustomerInformationReportBySearch_Schedule(CRMSalesCustomerInformationReportSearchRequest searchRequest)
        //{
        //    return _CRMSalesCustomerInformationReportBA.GetCustomerInformationReportBySearch_Schedule(searchRequest);
        //}
    }
}
