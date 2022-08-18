using System;
using System.Collections.Generic;
using System.Linq;
using AMS.Base.DTO;
using AMS.DTO;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessActions
{
    public interface ICRMSalesCustomerInformationReportServiceAccess
    {
        IBaseEntityCollectionResponse<CRMSalesCustomerInformationReport> GetCRMSalesCustomerInformationReportBySearch_Account(CRMSalesCustomerInformationReportSearchRequest searchRequest);
        //IBaseEntityCollectionResponse<CRMSalesCustomerInformationReport> GetCRMSalesCustomerInformationReportBySearch_Enquiry(CRMSalesCustomerInformationReportSearchRequest searchRequest);
        //IBaseEntityCollectionResponse<CRMSalesCustomerInformationReport> GetCRMSalesCustomerInformationReportBySearch_Schedule(CRMSalesCustomerInformationReportSearchRequest searchRequest);
    }
}
