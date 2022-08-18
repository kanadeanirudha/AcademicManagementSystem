using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class EnterpriseDrillThroughReportServiceAccess : IEnterpriseDrillThroughReportServiceAccess
    {
        IEnterpriseDrillThroughReportBA _EnterpriseDrillThroughReportBA = null;
        public EnterpriseDrillThroughReportServiceAccess()
        {
            _EnterpriseDrillThroughReportBA = new EnterpriseDrillThroughReportBA();
        }

        public IBaseEntityCollectionResponse<EnterpriseDrillThroughReport> GetEnterpriseDrillThroughReportBySearch_Centre(EnterpriseDrillThroughReportSearchRequest searchRequest)
         {
             return _EnterpriseDrillThroughReportBA.GetEnterpriseDrillThroughReportBySearch_Centre(searchRequest);
         }
        public IBaseEntityCollectionResponse<EnterpriseDrillThroughReport> GetEnterpriseDrillThroughReportBySearch_Department(EnterpriseDrillThroughReportSearchRequest searchRequest)
        {
            return _EnterpriseDrillThroughReportBA.GetEnterpriseDrillThroughReportBySearch_Department(searchRequest);
        }
        public IBaseEntityCollectionResponse<EnterpriseDrillThroughReport> GetEnterpriseDrillThroughReportBySearch_Employee(EnterpriseDrillThroughReportSearchRequest searchRequest)
        {
            return _EnterpriseDrillThroughReportBA.GetEnterpriseDrillThroughReportBySearch_Employee(searchRequest);
        }
    }
}
