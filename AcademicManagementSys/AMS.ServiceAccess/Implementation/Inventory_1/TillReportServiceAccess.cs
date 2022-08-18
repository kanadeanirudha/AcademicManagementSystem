
using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class TillReportServiceAccess : ITillReportServiceAccess
    {
        ITillReportBA _TillReportBA = null;
        public TillReportServiceAccess()
        {
            _TillReportBA = new TillReportBA();
        }

        public IBaseEntityCollectionResponse<TillReport> GetTillReport(TillReportSearchRequest searchRequest)
        {
            return _TillReportBA.GetTillReport(searchRequest);
        }
        public IBaseEntityResponse<TillReport> TillReportGetData(TillReport item)
        {
            return _TillReportBA.TillReportGetData(item);
        }
        public IBaseEntityResponse<TillReport> TillReportSaveData(TillReport item)
        {
            return _TillReportBA.TillReportSaveData(item);
        }
    }
}
