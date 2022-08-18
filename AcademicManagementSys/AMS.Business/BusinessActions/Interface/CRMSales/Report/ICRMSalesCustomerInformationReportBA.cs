using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessActions
{
    public interface ICRMSalesCustomerInformationReportBA
    {
        IBaseEntityCollectionResponse<CRMSalesCustomerInformationReport> GetCRMSalesCustomerInformationReportBySearch_Account(CRMSalesCustomerInformationReportSearchRequest searchRequest);
       
    }
}
